using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InfinityScript
{
    public abstract class BaseScript : Notifiable
    {
        internal Dictionary<string, List<Func<string[], bool>>> _serverCommandHandlers = new Dictionary<string, List<Func<string[], bool>>>();
        internal Dictionary<string, List<Action<Entity, string[]>>> _clientCommandHandlers = new Dictionary<string, List<Action<Entity, string[]>>>();

        protected event Action Tick;
        protected event Action<Entity> PlayerConnecting;
        protected event Action<Entity> PlayerConnected;
        protected event Action<Entity> PlayerDisconnected;
        public static List<Entity> Players { get; private set; }

        public BaseScript()
        {
            Players = new List<Entity>();

            OnNotify("connecting", entity =>
            {
                if (!Players.Contains(entity.As<Entity>()))
                    Players.Add(entity.As<Entity>());

                if (PlayerConnecting == null)
                    return;

                PlayerConnecting(entity.As<Entity>());
            });
            OnNotify("connected", entity =>
            {
                if (PlayerConnected == null)
                    return;
                PlayerConnected(entity.As<Entity>());
            });
        }

        public virtual void OnStartGameType()
        {
        }

        public virtual string OnPlayerRequestConnection(string playerName, string playerHWID, string playerXUID, string playerIP, string playerSteamID, string playerXNAddress) =>
            null;

        public virtual void OnPlayerConnecting(Entity player)
        {
        }

        public virtual void OnPlayerDisconnect(Entity player)
        {
            Players.Remove(player);
            if (PlayerDisconnected == null)
                return;

            PlayerDisconnected(player);
        }

        public virtual void OnPlayerDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc)
        {

        }

        public virtual void OnPlayerKilled(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc)
        {

        }

        public virtual void OnVehicleDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc, int timeOffset, int modelIndex, string partName)
        {
        }

        public virtual void OnPlayerLastStand(Entity player,Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc, int timeOffset, int deathAnimDuration)
        {
        }

        public virtual void OnSay(Entity player, string name, string message)
        {
        }

        public virtual EventEat OnSay2(Entity player, string name, string message) =>
            EventEat.EatNone;

        public virtual EventEat OnSay3(Entity player, ChatType type, string name, ref string message) =>
            EventEat.EatNone;

        public virtual void OnExitLevel()
        {
        }

        public void OnNotify(string type, Action handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public static void StartAsync(IEnumerator routine, string[] endonNotifies = null)
        {
            bool coroutineIsRunning = true;

            Action<int, string, Parameter[]> notifyWaiter = new Action<int, string, Parameter[]>((entRef, notify, parameters) =>
            {
                foreach (string message in endonNotifies)
                {
                    if (message == notify)
                        coroutineIsRunning = false;
                }
            });

            if(endonNotifies != null)
                Notified += notifyWaiter;

            Coroutine.routines.Add(routine);

            OnInterval(50, () =>
            {
                if (coroutineIsRunning)
                {
                    return Coroutine.stepForward();
                }
                else
                {
                    Coroutine.routines.Remove(routine);

                    if (endonNotifies != null)
                        Notified -= notifyWaiter;

                    return false;
                }
            });
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

        public IEnumerator WaitTill(string type)
        {
            Action<string> notifyWaiter = Coroutine.addHandler(type);
            WaitTillEvents += notifyWaiter;

            while (!Coroutine.checkStatus(type))
                yield return 0;

            Coroutine.removeHandler(type);

            WaitTillEvents -= notifyWaiter;
        }

        public IEnumerator WaitTill_any(params string[] type)
        {
            Action<string> notifyWaiter = Coroutine.addGroupHandler(type);
            WaitTillEvents += notifyWaiter;

            while (!Coroutine.checkGroupStatus(type))
                yield return 0;

            Coroutine.removeGroupHandlers(type);
            WaitTillEvents -= notifyWaiter;
        }

        public IEnumerator WaitTill_notify_or_timeout(string type, int time, Action<string> returnString = null)
        {
            Action<string> notifyWaiter = Coroutine.addHandler(type);
            Stopwatch watch = Stopwatch.StartNew();
            WaitTillEvents += notifyWaiter;
            TimeSpan elapsed;
            while (!Coroutine.checkStatus(type))
            {
                elapsed = watch.Elapsed;
                if (elapsed.TotalSeconds < time)
                    yield return 0;
                else
                    break;
            }

            Coroutine.removeHandler(type);

            if (watch.IsRunning)
                watch.Stop();

            WaitTillEvents -= notifyWaiter;
            elapsed = watch.Elapsed;
            if (elapsed.TotalSeconds >= time)
            {
                returnString?.Invoke("timeout");
                yield return "timeout";
            }
            else
            {
                returnString?.Invoke(type);
                yield return type;
            }
        }

        public static void OnInterval(int interval, Func<bool> function)
        {
            _timers.Add(new ScriptTimer()
            {
                func = function,
                triggerTime = 0,
                interval = interval
            });
        }

        public static void AfterDelay(int delay, Action function)
        {
            _timers.Add(new ScriptTimer()
            {
                func = function,
                triggerTime = _currentTime + delay,
                interval = -1
            });
        }

        internal void RunFrame()
        {
            if (Tick != null)
            {
                try
                {
                    Tick();
                }
                catch (Exception ex)
                {
                    Log.Write(LogLevel.Error, "Exception during Tick on script {0}: {1}", (object)this.GetType().Name, (object)ex.ToString());
                }
            }
            ProcessTimers();
            ProcessNotifications();
        }

        public static void Notify(string type, params Parameter[] parameters)
        {
            for (int index = parameters.Length - 1; index >= 0; --index)
                parameters[index].PushValue();
            GameInterface.Script_NotifyLevel(type, parameters.Length);
        }

        internal bool ProcessServerCommand(string command, string[] args)
        {
            bool flag = false;
            if (_serverCommandHandlers.ContainsKey(command))
            {
                foreach (var _ in _serverCommandHandlers[command].Where(func => func(args)).Select(func => new { }))
                {
                    flag = true;
                }
            }
            return flag;
        }

        internal bool ProcessClientCommand(string command, Entity entity, string[] args)
        {
            bool flag = false;
            if (_clientCommandHandlers.ContainsKey(command))
            {
                foreach (Action<Entity, string[]> action in _clientCommandHandlers[command])
                {
                    action(entity, args);
                    flag = true;
                }
            }
            return flag;
        }

        public void OnServerCommand(string command, Func<string[], bool> func)
        {
            if (!_serverCommandHandlers.ContainsKey(command))
                _serverCommandHandlers[command] = new List<Func<string[], bool>>();
            _serverCommandHandlers[command].Add(func);
        }

        public void OnServerCommand(string command, Action<string[]> func) =>
            OnServerCommand(command, args =>
            {
                func(args);
                return true;
            });


        public void OnServerCommand(string command, Action func) =>
            OnServerCommand(command, args =>
            {
                func();
                return true;
            });

        public void OnClientCommand(string command, Action<Entity, string[]> func)
        {
            if (!_clientCommandHandlers.ContainsKey(command))
                _clientCommandHandlers[command] = new List<Action<Entity, string[]>>();
            _clientCommandHandlers[command].Add(func);
        }

        public void OnClientCommand(string command, Action<Entity> func) => 
            OnClientCommand(command, (entity, args) => func(entity));

        public void OnClientCommand(string command, Action func) =>
            OnClientCommand(command, (entity, args) => func());

        public static void AllClientPrint(string message) =>
            GSCFunctions.AllClientsPrint(message);

        public enum EventEat
        {
            EatNone,
            EatScript,
            EatGame,
        }

        public enum ChatType
        {
            All,
            Team,
        }
    }
}
