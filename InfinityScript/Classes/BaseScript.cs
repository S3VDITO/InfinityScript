namespace InfinityScript
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using static InfinityScript.ThreadScript;

    public abstract class BaseScript : Notifiable
    {
        public BaseScript()
        {
            Players = new List<Entity>();

            Thread(ConnectingEventHandler());
            Thread(ConnectedEventHandler());
        }

        protected event Action<Entity> PlayerConnecting;

        protected event Action<Entity> PlayerConnected;

        protected event Action<Entity> PlayerDisconnected;

        public static List<Entity> Players { get; private set; }

        public static void AllClientPrint(string message) => GSCFunctions.AllClientsPrint(message);

        public static void OnInterval(int interval, Func<bool> function)
        {
            _timers.Add(new ScriptTimer()
            {
                Func = function,
                TriggerTime = 0,
                Interval = interval,
            });
        }

        public static void AfterDelay(int delay, Action function)
        {
            _timers.Add(new ScriptTimer()
            {
                Func = function,
                TriggerTime = GSCFunctions.GetTime() + delay,
                Interval = -1,
            });
        }

        public static void Notify(string notify, params Parameter[] parameters)
        {
            for (int index = parameters.Length - 1; index >= 0; --index)
            {
                parameters[index].PushValue();
            }

            GameInterface.Script_NotifyLevel(notify, parameters.Length);
        }

        public virtual void OnStartGameType()
        {
        }

        public virtual string OnPlayerRequestConnection(string playerName, string playerHWID, string playerXUID, string playerIP, string playerSteamID, string playerXNAddress) =>
            null;

        public virtual void OnPlayerConnecting(Entity player)
        {
            Players.Add(player);
        }

        public virtual void OnPlayerDisconnect(Entity player)
        {
            Players.Remove(player);
            PlayerDisconnected?.Invoke(player);
        }

        public virtual void OnPlayerDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc)
        {
        }

        public virtual void OnPlayerKilled(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc)
        {
        }

        public virtual void OnServerFrame()
        {
        }

        public virtual void OnVehicleDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc, int timeOffset, int modelIndex, string partName)
        {
        }

        public virtual void OnPlayerLastStand(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc, int timeOffset, int deathAnimDuration)
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

        internal void RunFrame()
        {
            OnServerFrame();
            ProcessTimers();
            ProcessNotifications();
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
    }
}
