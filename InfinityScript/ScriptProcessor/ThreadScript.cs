﻿namespace InfinityScript
{
    using System;
    using System.Collections;
    using System.Diagnostics;

    public static class ThreadScript
    {
        public static void Thread(IEnumerator routine)
        {
            Func<bool> stepForward = new Func<bool>(() =>
            {
                try
                {
                    if (!routine.Update())
                    {
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    return false;
                }
            });

            BaseScript.OnInterval(50, stepForward);
        }

        public static void Thread(IEnumerator routine, Func<int, string, Parameter[], bool> endonFunc)
        {
            bool threadActive = true;

            Func<bool> stepForward = new Func<bool>(() =>
            {
                if (!threadActive)
                {
                    return false;
                }

                try
                {
                    if (!routine.Update())
                    {
                        threadActive = false;
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    return false;
                }
            });

            BaseScript.OnInterval(50, stepForward);

            void NotifyWaiter(int entRef, string notify, Parameter[] paras)
            {
                if (!threadActive)
                {
                    Notifiable.Notified -= NotifyWaiter;
                    return;
                }

                var returnType = endonFunc.Method.ReturnType;

                if (!(bool)endonFunc.DynamicInvoke(entRef, notify, paras))
                {
                    Notifiable.Notified -= NotifyWaiter;
                    threadActive = false;
                    return;
                }
            }

            Notifiable.Notified += NotifyWaiter;
        }

        public static IEnumerator Wait(float time)
        {
            Stopwatch watch = Stopwatch.StartNew();

            while (watch.Elapsed.TotalSeconds < time)
            {
                yield return 0;
            }
        }

        public static IEnumerator WaitForFrame()
        {
            Stopwatch watch = Stopwatch.StartNew();

            while (watch.Elapsed.TotalSeconds < 0.0500000007450581)
            {
                yield return 0;
            }
        }

        public static IEnumerator WaitTill(string notify)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (message == notify)
                {
                    Notifiable.Notified -= NotifyWaiter;
                    isWait = false;
                    return;
                }
            }

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
            {
                yield return 0;
            }
        }

        public static IEnumerator WaitTill(params string[] notifies)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                foreach (string notify in notifies)
                {
                    if (message == notify)
                    {
                        Notifiable.Notified -= NotifyWaiter;
                        isWait = false;
                        return;
                    }
                }
            }

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
            {
                yield return 0;
            }
        }

        public static IEnumerator WaitTill(string notify, Action<Parameter[]> result)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (message == notify)
                {
                    Notifiable.Notified -= NotifyWaiter;
                    result?.Invoke(parameters);
                    isWait = false;
                    return;
                }
            }

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
            {
                yield return 0;
            }
        }

        public static IEnumerator WaitTill(Action<string> result, params string[] notifies)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                foreach (string notify in notifies)
                {
                    if (message == notify)
                    {
                        Notifiable.Notified -= NotifyWaiter;
                        result?.Invoke(message);
                        isWait = false;
                        return;
                    }
                }
            }

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
            {
                yield return 0;
            }
        }

        public static IEnumerator WaitTill(string notify, int time, Action<string> result = null)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (message == notify)
                {
                    Notifiable.Notified -= NotifyWaiter;
                    isWait = false;
                    return;
                }
            }

            Stopwatch watch = Stopwatch.StartNew();
            TimeSpan elapsed;

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
            {
                elapsed = watch.Elapsed;
                if (elapsed.TotalSeconds < time)
                {
                    yield return 0;
                }
                else
                {
                    break;
                }
            }

            elapsed = watch.Elapsed;

            if (elapsed.TotalSeconds >= time)
            {
                result?.Invoke("timeout");
            }
            else
            {
                result?.Invoke(notify);
            }
        }

        public static IEnumerator WaitTill(this Entity entity, string notify)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (entity.EntRef != entRef)
                {
                    return;
                }

                if (message == notify)
                {
                    Notifiable.Notified -= NotifyWaiter;
                    isWait = false;
                    return;
                }
            }

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
            {
                yield return 0;
            }
        }

        public static IEnumerator WaitTill(this Entity entity, params string[] notifies)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (entity.EntRef != entRef)
                {
                    return;
                }

                foreach (string notify in notifies)
                {
                    if (message == notify)
                    {
                        Notifiable.Notified -= NotifyWaiter;
                        isWait = false;
                        return;
                    }
                }
            }

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
            {
                yield return 0;
            }
        }

        public static IEnumerator WaitTill(this Entity entity, string notify, Action<Parameter[]> result)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (entity.EntRef != entRef)
                {
                    return;
                }

                if (message == notify)
                {
                    Notifiable.Notified -= NotifyWaiter;
                    result?.Invoke(parameters);
                    isWait = false;
                    return;
                }
            }

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
            {
                yield return 0;
            }
        }

        public static IEnumerator WaitTill(this Entity entity, Action<string> result, params string[] notifies)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (entity.EntRef != entRef)
                {
                    return;
                }

                foreach (string notify in notifies)
                {
                    if (message == notify)
                    {
                        Notifiable.Notified -= NotifyWaiter;
                        result?.Invoke(message);
                        isWait = false;
                        return;
                    }
                }
            }

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
            {
                yield return 0;
            }
        }

        public static IEnumerator WaitTill(this Entity entity, string notify, int time, Action<string> result = null)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (entity.EntRef != entRef)
                {
                    return;
                }

                if (message == notify)
                {
                    Notifiable.Notified -= NotifyWaiter;
                    isWait = false;
                    return;
                }
            }

            Stopwatch watch = Stopwatch.StartNew();
            TimeSpan elapsed;

            Notifiable.Notified += NotifyWaiter;

            while (isWait)
            {
                elapsed = watch.Elapsed;
                if (elapsed.TotalSeconds < time)
                {
                    yield return 0;
                }
                else
                {
                    break;
                }
            }

            elapsed = watch.Elapsed;

            if (elapsed.TotalSeconds >= time)
            {
                result?.Invoke("timeout");
            }
            else
            {
                result?.Invoke(notify);
            }
        }

        private static bool Update(this IEnumerator routine)
        {
            if ((!(routine.Current is IEnumerator enumerator) || !MoveNext(enumerator)) && !routine.MoveNext())
            {
                return false;
            }

            return true;
        }

        private static bool MoveNext(IEnumerator routine) =>
            (routine.Current is IEnumerator enumerator && MoveNext(enumerator)) || routine.MoveNext();
    }
}