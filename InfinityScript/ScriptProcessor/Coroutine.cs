using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InfinityScript
{
    internal class Coroutine : Notifiable
    {
        public static List<IEnumerator> routines = new List<IEnumerator>();
        private static Dictionary<string, bool> Notifies = new Dictionary<string, bool>();
        private static Dictionary<string[], bool> GroupedNotifies = new Dictionary<string[], bool>();

        public static bool stepForward()
        {
            if (!Running)
                return false;
            try
            {
                Update();
            }
            catch
            {
                return false;
            }
            return true;
        }

        private static void StopAll() =>
            routines.Clear();

        private static void InternalWait(string notifyCheck, string notify, params Parameter[] par)
        {
            if (notify != notifyCheck)
                return;
            Notifies[notify] = true;
        }

        private static void InternalWaitAll(string[] notifyCheck, string notify, params Parameter[] pars)
        {
            foreach (var _ in notifyCheck.Where(str => notify == str).Select(str => new { }))
                GroupedNotifies[notifyCheck] = true;
        }

        internal static Action<string> addHandler(string notify)
        {
            Notifies.Add(notify, false);
            return m => InternalWait(notify, m);
        }

        internal static void removeHandler(string notify) => 
            Notifies.Remove(notify);

        internal static void removeGroupHandlers(string[] notify) =>
            GroupedNotifies.Remove(notify);

        internal static Action<string> addGroupHandler(string[] notify)
        {
            GroupedNotifies.Add(notify, false);
            return m => InternalWaitAll(notify, m);
        }

        public static bool checkStatus(string notify)
        {
            if (!Notifies[notify])
                return false;
            Notifies.Remove(notify);
            return true;
        }

        public static bool checkGroupStatus(string[] notify)
        {
            if (!GroupedNotifies[notify])
                return false;

            GroupedNotifies.Remove(notify);
            return true;
        }

        internal static IEnumerator WaitTill(Entity ent, string notify)
        {
            Notifies.Add(notify, false);
            Action<int, string, Parameter[]> notifyWaiter = new Action<int, string, Parameter[]>((entRef, message, parameters) =>
            {
                if(entRef == ent.EntRef)
                    InternalWait(notify, message, parameters);
            });

            Notified += notifyWaiter;

            while (!Notifies[notify])
                yield return 0;

            removeHandler(notify);

            Notified -= notifyWaiter;
        }

        public static IEnumerator WaitTill_any(Entity ent, params string[] notify)
        {
            GroupedNotifies.Add(notify, false);
            Action<int, string, Parameter[]> notifyWaiter = new Action<int, string, Parameter[]>((entRef, message, parameters) =>
            {
                if (entRef == ent.EntRef)
                    InternalWaitAll(notify, message, parameters);
            });
            Notified += notifyWaiter;
            while (!GroupedNotifies[notify])
                yield return 0;
            removeGroupHandlers(notify);
            Notified -= notifyWaiter;
        }

        public static IEnumerator WaitTill_notify_or_timeout(Entity ent, string notify, int time, Action<string> returnString = null)
        {
            Notifies.Add(notify, false);
            Stopwatch watch = Stopwatch.StartNew();
            Action<int, string, Parameter[]> notifyWaiter = new Action<int, string, Parameter[]>((entRef, message, parameters) =>
            {
                if (entRef == ent.EntRef)
                    InternalWait(notify, message, parameters);
            });
            Notified += notifyWaiter;
            TimeSpan elapsed;
            while (!Notifies[notify])
            {
                elapsed = watch.Elapsed;
                if (elapsed.TotalSeconds < time)
                    yield return 0;
                else
                    break;
            }
            removeHandler(notify);
            if (watch.IsRunning)
                watch.Stop();
            Notified -= notifyWaiter;
            elapsed = watch.Elapsed;

            if (elapsed.TotalSeconds >= time)
                returnString?.Invoke("timeout");
            else
                returnString?.Invoke(notify);
        }

        private static void Update()
        {
            for (int index = 0; index < routines.Count; ++index)
            {
                if ((!(routines[index].Current is IEnumerator enumerator) || !MoveNext(enumerator)) && !routines[index].MoveNext())
                    routines.RemoveAt(index--);
            }
        }

        private static bool MoveNext(IEnumerator routine) =>
            routine.Current is IEnumerator enumerator && MoveNext(enumerator) || routine.MoveNext();

        internal static int Count =>
            routines.Count;

        internal static bool Running =>
            routines.Count > 0;
    }
}
