using System;
using System.Collections;
using System.Collections.Generic;

namespace InfinityScript
{
    internal class Coroutine : Notifiable
    {
        public static List<IEnumerator> Routines = new List<IEnumerator>();

        public static bool StepForward(IEnumerator routine)
        {
            if (!Running)
                return false;

            if (!Routines.Contains(routine))
                return false;

            try
            {
                Update(routine);
            }
            catch(Exception ex)
            {
                Utilities.PrintToConsole($"[InfinityScript] Exception coroutine: {ex.Message}");
                return false;
            }

            return true;
        }

        private static void StopAll() =>
            Routines.Clear();

        private static void Update(IEnumerator routine)
        {
            if ((!(routine.Current is IEnumerator enumerator) || !MoveNext(enumerator)) && !routine.MoveNext())
                Routines.Remove(routine);
        }

        private static bool MoveNext(IEnumerator routine) =>
            routine.Current is IEnumerator enumerator && MoveNext(enumerator) || routine.MoveNext();

        internal static int Count =>
            Routines.Count;

        internal static bool Running =>
            Routines.Count > 0;
    }
}
