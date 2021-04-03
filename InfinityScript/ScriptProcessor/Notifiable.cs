namespace InfinityScript
{
    using System;
    using System.Collections.Generic;

    public abstract class Notifiable
    {
        internal static readonly List<ScriptTimer> _timers = new List<ScriptTimer>();

        private Dictionary<string, List<Delegate>> _notifyHandlers = new Dictionary<string, List<Delegate>>();
        private List<NotifyData> _pendingNotifys = new List<NotifyData>();
        private int _currentTime;

        public static event Action<int, string, Parameter[]> Notified;

        internal void ProcessNotifications()
        {
            // handle notify events
            var notifys = _pendingNotifys.ToArray();
            _pendingNotifys.Clear();

            foreach (var notify in notifys)
            {
                Notified?.Invoke(notify.Ent, notify.Type, notify.Parameters);

                if (_notifyHandlers.ContainsKey(notify.Type))
                {
                    var handlers = _notifyHandlers[notify.Type];

                    foreach (var handler in handlers)
                    {
                        try
                        {
                            var parameters = handler.Method.GetParameters();

                            if (parameters.Length > 0 && parameters[0].ParameterType == typeof(Entity))
                            {
                                var newParameters = new object[notify.Parameters.Length + 1];
                                newParameters[0] = (this is Entity) ? (Entity)this : null;
                                Array.Copy(notify.Parameters, 0, newParameters, 1, notify.Parameters.Length);

                                handler.DynamicInvoke(newParameters);
                            }
                            else
                            {
                                handler.DynamicInvoke(notify.Parameters);
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Write(LogLevel.Error, "Exception during handling of notify event {0} on {1}: {2}", notify.Type, this, (ex.InnerException != null) ? ex.InnerException.ToString() : ex.ToString());
                        }
                    }
                }
            }
        }

        internal void HandleNotify(int entity, string type, Parameter[] paras)
        {
            if (Notified == null && !_notifyHandlers.ContainsKey(type))
            {
                return;
            }

            _pendingNotifys.Add(new NotifyData()
            {
                Ent = entity,
                Type = type,
                Parameters = paras,
            });
        }

        internal void ProcessTimers()
        {
            Function.SetEntRef(-1);
            _currentTime = GSCFunctions.GetTime();

            var timers = _timers.ToArray();

            foreach (var timer in timers)
            {
                if (_currentTime >= timer.TriggerTime)
                {
                    try
                    {
                        var parameters = timer.Func.Method.GetParameters();
                        var returnType = timer.Func.Method.ReturnType;
                        object returnValue = null;

                        if (parameters.Length > 0 && parameters[0].ParameterType == typeof(Entity))
                        {
                            returnValue = timer.Func.DynamicInvoke(this);
                        }
                        else
                        {
                            returnValue = timer.Func.DynamicInvoke();
                        }

                        if (returnType == typeof(bool) && (bool)returnValue == false)
                        {
                            _timers.Remove(timer);
                            continue;
                        }

                        if (timer.Interval != -1)
                        {
                            timer.TriggerTime = _currentTime + timer.Interval;
                        }
                        else
                        {
                            _timers.Remove(timer);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Write(LogLevel.Error, "Error during handling timer in script {0}: {1}", GetType().Name, (ex.InnerException != null) ? ex.InnerException.ToString() : ex.ToString());

                        _timers.Remove(timer);
                    }
                }
            }
        }

        private struct NotifyData
        {
            public int Ent;
            public string Type;
            public Parameter[] Parameters;
        }

        internal class ScriptTimer
        {
            public Delegate Func { get; set; }

            public int TriggerTime { get; set; }

            public int Interval { get; set; }
        }
    }
}
