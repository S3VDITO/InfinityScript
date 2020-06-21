using System;
using System.Collections.Generic;
using System.Reflection;

namespace InfinityScript
{
    public abstract class Notifiable
    {
        internal static List<ScriptTimer> _timers = new List<ScriptTimer>();
        private Dictionary<string, List<Delegate>> _notifyHandlers = new Dictionary<string, List<Delegate>>();
        private List<NotifyData> _pendingNotifys = new List<NotifyData>();
        internal static int _currentTime;

        protected void OnNotifyInternal(string type, Delegate handler)
        {
            if (!_notifyHandlers.ContainsKey(type))
                _notifyHandlers[type] = new List<Delegate>();

            _notifyHandlers[type].Add(handler);
        }

        public static event Action<int, string, Parameter[]> Notified;

        internal void ProcessNotifications()
        {
            NotifyData[] array = _pendingNotifys.ToArray();
            _pendingNotifys.Clear();
            foreach (NotifyData notifyData in array)
            {
                Notified?.Invoke(notifyData.entity, notifyData.type, notifyData.parameters);

                if (_notifyHandlers.ContainsKey(notifyData.type))
                {
                    foreach (Delegate @delegate in _notifyHandlers[notifyData.type])
                    {
                        try
                        {
                            ParameterInfo[] parameters = @delegate.Method.GetParameters();
                            if (parameters.Length != 0 && parameters[0].ParameterType == typeof(Entity))
                            {
                                object[] objArray = new object[notifyData.parameters.Length + 1];
                                objArray[0] = this is Entity ? (Entity)this : null;
                                Array.Copy(notifyData.parameters, 0, objArray, 1, notifyData.parameters.Length);
                                @delegate.DynamicInvoke(objArray);
                            }
                            else
                                @delegate.DynamicInvoke(notifyData.parameters);
                        }
                        catch (Exception ex)
                        {
                            Log.Write(LogLevel.Error, "Exception during handling of notify event {0} on {1}: {2}", notifyData.type, this, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                        }
                    }
                }
            }
        }

        internal void ProcessTimers()
        {
            Function.SetEntRef(-1);
            _currentTime = GSCFunctions.GetTime();
            foreach (ScriptTimer scriptTimer in _timers.ToArray())
            {
                if (_currentTime >= scriptTimer.triggerTime)
                {
                    try
                    {
                        ParameterInfo[] parameters = scriptTimer.func.Method.GetParameters();
                        Type returnType = scriptTimer.func.Method.ReturnType;
                        object obj;
                        if (parameters.Length != 0 && parameters[0].ParameterType == typeof(Entity))
                            obj = scriptTimer.func.DynamicInvoke((object)this);
                        else
                            obj = scriptTimer.func.DynamicInvoke();
                        if (returnType == typeof(bool) && !(bool)obj)
                            _timers.Remove(scriptTimer);
                        else if (scriptTimer.interval != -1)
                            scriptTimer.triggerTime = _currentTime + scriptTimer.interval;
                        else
                            _timers.Remove(scriptTimer);
                    }
                    catch (Exception ex)
                    {
                        Log.Write(LogLevel.Error, "Error during handling timer in script {0}: {1}",
                            GetType().Name,
                            ex.InnerException != null ? ex.InnerException.Message : ex.Message);

                        _timers.Remove(scriptTimer);
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

        private struct NotifyData
        {
            public int entity;
            public string type;
            public Parameter[] parameters;
        }

        internal class ScriptTimer
        {
            public Delegate func;
            public int triggerTime;
            public int interval;
        }
    }
}
