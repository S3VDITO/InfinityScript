using System;
using System.Collections;
using System.Collections.Generic;

using static InfinityScript.ThreadScript;

namespace InfinityScript
{
    public abstract class BaseScript : Notifiable
    {
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

            Thread(ConnectingEventHandler());
            Thread(ConnectedEventHandler());
        }

        private IEnumerator ConnectingEventHandler()
        {
            Entity player = null;

            while (true)
            {
                yield return WaitTill("connecting", new Action<Parameter[]>(param => player = param[0].As<Entity>()));
                PlayerConnecting?.Invoke(player);
            }
        }

        private IEnumerator ConnectedEventHandler()
        {
            Entity player = null;
            while (true)
            {
                yield return WaitTill("connected", new Action<Parameter[]>(param => player = param[0].As<Entity>()));
                PlayerConnected?.Invoke(player);
            }
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

        public virtual void OnServerFrame()
        {
            
        }

        public virtual void OnVehicleDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc, int timeOffset, int modelIndex, string partName)
        {
        }

        public virtual void OnPlayerLastStand(Entity player,Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc, int timeOffset, int deathAnimDuration)
        {
        }

        public virtual bool OnServerCommand(string command, string[] args)
        {
            return false;
        }
        public virtual bool OnClientCommand(Entity entSender, string command, string[] args)
        {
            return false;
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
            OnServerFrame();
            ProcessTimers();
            ProcessNotifications();
        }

        /// <summary>
        /// Print messgae for all players
        /// </summary>
        /// <param name="message">Message</param>
        public static void AllClientPrint(string message) => GSCFunctions.AllClientsPrint(message);

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
