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

        /// <summary>
        /// In game tick event
        /// </summary>
        protected event Action Tick;

        /// <summary>
        /// Player connecting event
        /// </summary>
        protected event Action<Entity> PlayerConnecting;

        /// <summary>
        /// Player connected event
        /// </summary>
        protected event Action<Entity> PlayerConnected;

        /// <summary>
        /// Player disconnected event
        /// </summary>
        protected event Action<Entity> PlayerDisconnected;

        /// <summary>
        /// Players list
        /// </summary>
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

        /// <summary>
        /// Handling StartGameType event 
        /// </summary>
        public virtual void OnStartGameType()
        {
        }

        /// <summary>
        /// Handling player request connect event
        /// </summary>
        /// <param name="playerName">Player name</param>
        /// <param name="playerHWID">Player Hardware ID</param>
        /// <param name="playerXUID">Player XUID</param>
        /// <param name="playerIP">Player IP</param>
        /// <param name="playerSteamID">Player Steam ID</param>
        /// <param name="playerXNAddress">Player XNAddress</param>
        /// <returns></returns>
        public virtual string OnPlayerRequestConnection(string playerName, string playerHWID, string playerXUID, string playerIP, string playerSteamID, string playerXNAddress) =>
            null;

        /// <summary>
        /// Handling player connecting event
        /// </summary>
        /// <param name="player">Player</param>
        public virtual void OnPlayerConnecting(Entity player)
        {
        }

        /// <summary>
        /// Handling player disconnect event
        /// </summary>
        /// <param name="player">Player</param>
        public virtual void OnPlayerDisconnect(Entity player)
        {
            Players.Remove(player);
            PlayerDisconnected?.Invoke(player);
        }

        /// <summary>
        /// Handling player damage event
        /// </summary>
        /// <param name="player">Victim</param>
        /// <param name="inflictor">Assistant</param>
        /// <param name="attacker">Attacker</param>
        /// <param name="damage">Damage point</param>
        /// <param name="dFlags"></param>
        /// <param name="mod">Damage modificator</param>
        /// <param name="weapon">Weapon name</param>
        /// <param name="point"></param>
        /// <param name="dir"></param>
        /// <param name="hitLoc"></param>
        public virtual void OnPlayerDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc)
        {

        }

        /// <summary>
        /// Handling player killed event
        /// </summary>
        /// <param name="player">Victim</param>
        /// <param name="inflictor">Assistant</param>
        /// <param name="attacker">Attacker</param>
        /// <param name="damage">Damage point</param>
        /// <param name="mod">Kill modificator</param>
        /// <param name="weapon">Weapon name</param>
        /// <param name="dir"></param>
        /// <param name="hitLoc"></param>
        public virtual void OnPlayerKilled(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc)
        {

        }

        public virtual void OnVehicleDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc, int timeOffset, int modelIndex, string partName)
        {
        }

        public virtual void OnPlayerLastStand(Entity player,Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc, int timeOffset, int deathAnimDuration)
        {
        }

        /// <summary>
        /// Chat handling
        /// </summary>
        /// <param name="player">Player sent message</param>
        /// <param name="name">Player name</param>
        /// <param name="message">Message</param>
        public virtual void OnSay(Entity player, string name, string message)
        {
        }

        /// <summary>
        /// Chat handling
        /// </summary>
        /// <param name="player">Player sent message</param>
        /// <param name="name">Player name</param>
        /// <param name="message">Message</param>
        /// <returns></returns>
        public virtual EventEat OnSay2(Entity player, string name, string message) =>
            EventEat.EatNone;

        /// <summary>
        /// Chat handling
        /// </summary>
        /// <param name="player">Player sent message</param>
        /// <param name="type">Chat type</param>
        /// <param name="name">Player name</param>
        /// <param name="message">Message</param>
        /// <returns></returns>
        public virtual EventEat OnSay3(Entity player, ChatType type, string name, ref string message) =>
            EventEat.EatNone;

        /// <summary>
        /// Handling post-endgame event
        /// </summary>
        public virtual void OnExitLevel()
        {
        }

        /// <summary>
        /// Handling notify (can not unsubscribe)
        /// </summary>
        /// <param name="type">Notify</param>
        /// <param name="handler">Function with parameters</param>
        public void OnNotify(string type, Action handler) =>
            OnNotifyInternal(type, handler);

        /// <summary>
        /// Handling notify (can not unsubscribe)
        /// </summary>
        /// <param name="type">Notify</param>
        /// <param name="handler">Function with parameters</param>
        public void OnNotify(string type, Action<Parameter> handler) =>
            OnNotifyInternal(type, handler);

        /// <summary>
        /// Handling notify (can not unsubscribe)
        /// </summary>
        /// <param name="type">Notify</param>
        /// <param name="handler">Function with parameters</param>
        public void OnNotify(string type, Action<Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        /// <summary>
        /// Handling notify (can not unsubscribe)
        /// </summary>
        /// <param name="type">Notify</param>
        /// <param name="handler">Function with parameters</param>
        public void OnNotify(string type, Action<Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        /// <summary>
        /// Handling notify (can not unsubscribe)
        /// </summary>
        /// <param name="type">Notify</param>
        /// <param name="handler">Function with parameters</param>
        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        /// <summary>
        /// Handling notify (can not unsubscribe)
        /// </summary>
        /// <param name="type">Notify</param>
        /// <param name="handler">Function with parameters</param>
        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        /// <summary>
        /// Handling notify (can not unsubscribe)
        /// </summary>
        /// <param name="type">Notify</param>
        /// <param name="handler">Function with parameters</param>
        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        /// <summary>
        /// Handling notify (can not unsubscribe)
        /// </summary>
        /// <param name="type">Notify</param>
        /// <param name="handler">Function with parameters</param>
        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        /// <summary>
        /// Handling notify (can not unsubscribe)
        /// </summary>
        /// <param name="type">Notify</param>
        /// <param name="handler">Function with parameters</param>
        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        /// <summary>
        /// Handling notify (can not unsubscribe)
        /// </summary>
        /// <param name="type">Notify</param>
        /// <param name="handler">Function with parameters</param>
        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        /// <summary>
        /// Handling notify (can not unsubscribe)
        /// </summary>
        /// <param name="type">Notify</param>
        /// <param name="handler">Function with parameters</param>
        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        /// <summary>
        /// Start coroutine
        /// </summary>
        /// <param name="routine">Сoroutine method</param>
        public static void StartAsync(IEnumerator routine)
        {
            Coroutine.Routines.Add(routine);
            OnInterval(50, () => Coroutine.StepForward(routine));
        }

        /// <summary>
        /// Start coroutine with early termination (handling a specific notify)
        /// </summary>
        /// <param name="routine">Сoroutine method</param>
        /// <param name="endonNotifies">Endon notifies for early termination</param>
        public static void StartAsync(IEnumerator routine, params string[] endonNotifies)
        {
            Coroutine.Routines.Add(routine);

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                foreach (string notify in endonNotifies)
                {
                    if (message == notify && Coroutine.Routines.Contains(routine))
                    {
                        Coroutine.Routines.Remove(routine);
                        Notified -= NotifyWaiter;
                    }
                }
            }

            Notified += NotifyWaiter;

            OnInterval(50, () => Coroutine.StepForward(routine));
        }

        /// <summary>
        /// Makes a delay in seconds
        /// </summary>
        /// <param name="time">Time delay in seconds (1.5f = 1.5 seconds or 1500 milliseconds)</param>
        /// <returns></returns>
        public static IEnumerator Wait(float time)
        {
            Stopwatch watch = Stopwatch.StartNew();

            while (watch.Elapsed.TotalSeconds < time)
                yield return 0;
        }

        /// <summary>
        /// Just a delay...
        /// </summary>
        /// <returns></returns>
        public static IEnumerator WaitForFrame()
        {
            Stopwatch watch = Stopwatch.StartNew();

            while (watch.Elapsed.TotalSeconds < 0.0500000007450581)
                yield return 0;
        }

        /// <summary>
        /// Wait notify
        /// </summary>
        /// <param name="notify"></param>
        /// <returns></returns>
        public static IEnumerator WaitTill(string notify)
        {
            bool isWait = true;

            void NotifyWaiter(int entRef, string message, Parameter[] parameters)
            {
                if (message == notify) 
                    isWait = false;
            }

            Notified += NotifyWaiter;

            while (isWait)
                yield return 0;

            Notified -= NotifyWaiter;
        }

        /// <summary>
        /// Wait notify from "notifies"
        /// </summary>
        /// <param name="notifies">Notifies list to wait</param>
        /// <returns></returns>
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

            Notified += NotifyWaiter;

            while (isWait)
                yield return 0;

            Notified -= NotifyWaiter;
        }

        /// <summary>
        /// Wait notify or timeout
        /// </summary>
        /// <param name="notify">Notify to wait</param>
        /// <param name="time">Milliseconds timeout</param>
        /// <param name="returnReasonAction">Return result work WaitTill: notify or timeout</param>
        /// <returns></returns>
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

            Notified += NotifyWaiter;

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

            Notified -= NotifyWaiter;
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

        /// <summary>
        /// Wait notify with return parameters
        /// </summary>
        /// <param name="notify">Notify to wait</param>
        /// <param name="resultAction">Returns parameters</param>
        /// <returns></returns>
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

            Notified += NotifyWaiter;

            while (isWait)
                yield return 0;

            Notified -= NotifyWaiter;
        }


        /// <summary>
        /// Method calls a function or evaluates an expression at specified intervals (in milliseconds)
        /// </summary>
        /// <param name="interval">Interval in milliseconds (1000ms = 1s)</param>
        /// <param name="function">Function code</param>
        public static void OnInterval(int interval, Func<bool> function)
        {
            _timers.Add(new ScriptTimer()
            {
                func = function,
                triggerTime = 0,
                interval = interval
            });
        }

        /// <summary>
        /// Method calls a function or evaluates an expression after a specified number of milliseconds.
        /// </summary>
        /// <param name="delay">Delay in milliseconds (1000ms = 1s)</param>
        /// <param name="function">Function code</param>
        public static void AfterDelay(int delay, Action function)
        {
            _timers.Add(new ScriptTimer()
            {
                func = function,
                triggerTime = _currentTime + delay,
                interval = -1
            });
        }

        /// <summary>
        /// Sends notify to gameplay
        /// </summary>
        /// <param name="notify">Notify name</param>
        /// <param name="parameters">Sent parameters</param>
        public static void Notify(string notify, params Parameter[] parameters)
        {
            for (int index = parameters.Length - 1; index >= 0; --index)
                parameters[index].PushValue();
            GameInterface.Script_NotifyLevel(notify, parameters.Length);
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
                    Log.Write(LogLevel.Error, "Exception during Tick on script {0}: {1}", GetType().Name, ex.ToString());
                }
            }
            ProcessTimers();
            ProcessNotifications();
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

        /// <summary>
        /// Print messgae for all players
        /// </summary>
        /// <param name="message">Message</param>
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
