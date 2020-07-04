﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace InfinityScript
{
    public abstract class Notifiable
    {
        private Dictionary<string, List<Delegate>> _notifyHandlers = new Dictionary<string, List<Delegate>>();
        private List<NotifyData> _pendingNotifys = new List<NotifyData>();
        private struct NotifyData
        {
            public int entity;
            public string type;
            public Parameter[] parameters;
        }

        public static event Action<int, string, Parameter[]> Notified;

        internal void ProcessNotifications()
        {
            // handle notify events
            var notifys = _pendingNotifys.ToArray();
            _pendingNotifys.Clear();

            foreach (var notify in notifys)
            {
                Notified?.Invoke(notify.entity, notify.type, notify.parameters);

                if (_notifyHandlers.ContainsKey(notify.type))
                {
                    var handlers = _notifyHandlers[notify.type];

                    foreach (var handler in handlers)
                    {
                        try
                        {
                            var parameters = handler.Method.GetParameters();

                            if (parameters.Length > 0 && parameters[0].ParameterType == typeof(Entity))
                            {
                                var newParameters = new object[notify.parameters.Length + 1];
                                newParameters[0] = (this is Entity) ? (Entity)this : null;
                                Array.Copy(notify.parameters, 0, newParameters, 1, notify.parameters.Length);

                                handler.DynamicInvoke(newParameters);
                            }
                            else
                            {
                                handler.DynamicInvoke(notify.parameters);
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Write(LogLevel.Error, "Exception during handling of notify event {0} on {1}: {2}", notify.type, this, (ex.InnerException != null) ? ex.InnerException.ToString() : ex.ToString());
                        }
                    }
                }
            }
        }

        internal void HandleNotify(int entity, string type, Parameter[] paras)
        {
            if (Notified == null && !_notifyHandlers.ContainsKey(type))
                return;

            _pendingNotifys.Add(new NotifyData()
            {
                entity = entity,
                type = type,
                parameters = paras
            });
        }


        #region ontimer
        internal static List<ScriptTimer> _timers = new List<ScriptTimer>();
        internal static int _currentTime;
        internal void ProcessTimers()
        {
            Function.SetEntRef(-1);
            _currentTime = GSCFunctions.GetTime();

            var timers = _timers.ToArray();

            foreach (var timer in timers)
            {
                if (_currentTime >= timer.triggerTime)
                {
                    try
                    {
                        var parameters = timer.func.Method.GetParameters();
                        var returnType = timer.func.Method.ReturnType;
                        object returnValue = null;

                        if (parameters.Length > 0 && parameters[0].ParameterType == typeof(Entity))
                            returnValue = timer.func.DynamicInvoke(this);
                        else
                            returnValue = timer.func.DynamicInvoke();

                        if (returnType == typeof(bool) && (bool)returnValue == false)
                        {
                            _timers.Remove(timer);
                            continue;
                        }

                        if (timer.interval != -1)
                            timer.triggerTime = _currentTime + timer.interval;
                        else
                            _timers.Remove(timer);
                    }
                    catch (Exception ex)
                    {
                        Log.Write(LogLevel.Error, "Error during handling timer in script {0}: {1}", GetType().Name, (ex.InnerException != null) ? ex.InnerException.ToString() : ex.ToString());

                        _timers.Remove(timer);
                    }
                }
            }
        }

        internal class ScriptTimer
        {
            public Delegate func;
            public int triggerTime;
            public int interval;
        }
        #endregion

    }
}
