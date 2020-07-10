using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace InfinityScript
{
    public class ScriptThread : Notifiable
    {
        private IEnumerator Routine { get; }
        private bool isActive { get; set; } = true;

        private void Notified(int entRef, string notify, Parameter[])

        public ScriptThread(IEnumerator routine)
        {
            Routine = routine;
            BaseScript.OnInterval(50, () => StepForward());
        }
        private bool StepForward()
        {
            try
            {
                if (isActive)
                    return true;

                if ((!(Routine.Current is IEnumerator enumerator) || !MoveNext(enumerator)) && !Routine.MoveNext())
                    return false;

                return false;
            }
            catch
            {
                
            }

            return false;
        }
        private bool MoveNext(IEnumerator routine) =>
            routine.Current is IEnumerator enumerator && MoveNext(enumerator) || routine.MoveNext();

        public void SetEndon(Entity entity, params string[] endonNotifys)
        {
            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (!isActive)
                {
                    Notifiable.Notified -= NotifyWaiter;
                    return;
                }

                if (entity.EntRef != entRef)
                    return;

                foreach (string notify in endonNotifys)
                {
                    if (notify == message)
                    {
                        isActive = false;
                        Notifiable.Notified -= NotifyWaiter;
                    }
                }
            }

            Notifiable.Notified += NotifyWaiter;
        }

        public void SetEndon(params string[] endonNotifys)
        {
            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (!isActive)
                {
                    Notifiable.Notified -= NotifyWaiter;
                    return;
                }

                foreach (string notify in endonNotifys)
                {
                    if (notify == message)
                    {
                        isActive = false;
                        Notifiable.Notified -= NotifyWaiter;
                    }
                }
            }
            Notifiable.Notified += NotifyWaiter;
        }

        public static IEnumerator Wait(float time)
        {
            Stopwatch watch = Stopwatch.StartNew();

            while (watch.Elapsed.TotalSeconds < time)
                yield return 0;
        }

        public static IEnumerator WaitForFrame()
        {
            Stopwatch watch = Stopwatch.StartNew();

            while (watch.Elapsed.TotalSeconds < 0.0500000007450581)
                yield return 0;
        }
    }


        public static IEnumerator WaitTill(string notify)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (message == notify)
                    isWait = false;
            }

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
                yield return 0;

            Notifiable.Notified -= NotifyWaiter;
        }

        public static IEnumerator WaitTill(Action<string> resultAction, params string[] notifies)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                foreach (string notify in notifies)
                {
                    if (!isWait)
                        return;

                    if (message == notify)
                    {
                        resultAction?.Invoke(notify);
                        isWait = false;
                    }
                }
            }

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
                yield return 0;

            Notifiable.Notified -= NotifyWaiter;
        }

        public static IEnumerator WaitTill(string notify, int time, Action<string> resultAction = null)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (message == notify)
                    isWait = false;
            }

            Stopwatch watch = Stopwatch.StartNew();
            TimeSpan elapsed;

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
            {
                elapsed = watch.Elapsed;
                if (elapsed.TotalSeconds < time)
                    yield return 0;
                else
                    break;
            }

            if (watch.IsRunning)
                watch.Stop();

            Notifiable.Notified -= NotifyWaiter;
            elapsed = watch.Elapsed;
            if (elapsed.TotalSeconds >= time)
            {
                resultAction?.Invoke("timeout");
                yield return "timeout";
            }
            else
            {
                resultAction?.Invoke(notify);
                yield return notify;
            }
        }

        public static IEnumerator WaitTill(string notify, Action<Parameter[]> resultAction = null)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (message == notify)
                {
                    isWait = false;
                    resultAction?.Invoke(parameters);
                }
            }

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
                yield return 0;

            Notifiable.Notified -= NotifyWaiter;
        }

        public static IEnumerator WaitTill(this Entity entity, string notify)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (entity.EntRef != entRef)
                    return;

                if (message == notify)
                    isWait = false;
            }

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
                yield return 0;

            Notifiable.Notified -= NotifyWaiter;
        }

        public static IEnumerator WaitTill(this Entity entity, params string[] notifies)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (entity.EntRef != entRef)
                    return;

                foreach (string notify in notifies)
                {
                    if (message == notify)
                        isWait = false;
                }
            }

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
                yield return 0;

            Notifiable.Notified -= NotifyWaiter;
        }

        public static IEnumerator WaitTill(this Entity entity, Action<string> resultAction, params string[] notifies)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                foreach (string notify in notifies)
                {

                    if (entity.EntRef != entRef)
                        return;

                    if (!isWait)
                        return;

                    if (message == notify)
                    {
                        resultAction?.Invoke(notify);
                        isWait = false;
                    }
                }
            }

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
                yield return 0;

            Notifiable.Notified -= NotifyWaiter;
        }

        public static IEnumerator WaitTill(this Entity entity, string notify, int time, Action<string> resultAction = null)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (entity.EntRef != entRef)
                    return;

                if (message == notify)
                    isWait = false;
            }

            Stopwatch watch = Stopwatch.StartNew();
            TimeSpan elapsed;

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
            {
                elapsed = watch.Elapsed;
                if (elapsed.TotalSeconds < time)
                    yield return 0;
                else
                    break;
            }

            if (watch.IsRunning)
                watch.Stop();

            Notifiable.Notified -= NotifyWaiter;
            elapsed = watch.Elapsed;
            if (elapsed.TotalSeconds >= time)
            {
                resultAction?.Invoke("timeout");
                yield return "timeout";
            }
            else
            {
                resultAction?.Invoke(notify);
                yield return notify;
            }
        }

        public static IEnumerator WaitTill(this Entity entity, string notify, Action<Parameter[]> resultAction = null)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (entity.EntRef != entRef)
                    return;

                if (message == notify)
                {
                    isWait = false;
                    resultAction?.Invoke(parameters);
                }
            }

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
                yield return 0;

            Notifiable.Notified -= NotifyWaiter;
        }
    }
}
