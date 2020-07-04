using System;
using System.Collections.Generic;
using System.Linq;

namespace InfinityScript
{
    internal static class SHManager
    {
        public static void Initialize()
        {
            Log.Initialize(LogLevel.All);
            Log.AddListener(new FileLogListener("InfinityScript.log", false));
            Log.AddListener(new TraceLogListener());
            Log.AddListener(new GameLogListener());
            try
            {
                ScriptLoader.Initialize();
            }
            catch (Exception ex)
            {
                Log.Write(LogLevel.Critical, ex.ToString());
                Environment.Exit(0);
            }
        }

        public static void RunFrame()
        {
            try
            {
                ScriptProcessor.RunAll(script => script.RunFrame());
            }
            catch (Exception ex)
            {
                Log.Write(LogLevel.Critical, ex.ToString());
                Environment.Exit(0);
            }
        }

        public static void Shutdown() =>
            ScriptProcessor.RunAll(script => script.OnExitLevel());

        public static void LoadScript(string scriptName) =>
            ScriptLoader.LoadAssemblies("scripts", scriptName);

        public static bool HandleSay(int clientNum, string clientName, ref string message, int team)
        {
            Entity entity = Entity.GetEntity(clientNum);
            bool eatgame = false;
            bool eatscript = false;
            string messageTemp = message;

            ScriptProcessor.RunAll(script =>
            {

                // Run Script.OnSay3 (by reference, with team and eat)
                if (eatscript)
                    return;

                BaseScript.EventEat handled = script.OnSay3(entity, team == 0 ? BaseScript.ChatType.All : BaseScript.ChatType.Team, clientName, ref messageTemp);

                eatgame = eatgame || handled.HasFlag(BaseScript.EventEat.EatGame);
                eatscript = handled.HasFlag(BaseScript.EventEat.EatScript);

                // Run Script.OnSay2 (normal, with eat)
                if (eatscript)
                    return;

                handled = script.OnSay2(entity, clientName, messageTemp);
                eatgame = eatgame || handled.HasFlag(BaseScript.EventEat.EatGame);
                eatscript = handled.HasFlag(BaseScript.EventEat.EatScript);

                // Run Script.OnSay (normal, without eat)
                if (eatscript)
                    return;

                script.OnSay(entity, clientName, messageTemp);
            });

            message = messageTemp;

            return eatgame;
        }

        public static void HandleCall(int entityRef, CallType funcID)
        {
            Entity entity = Entity.GetEntity(entityRef);
            int numArgs = GameInterface.Notify_NumArgs();
            Parameter[] paras = CollectParameters(numArgs);

            switch (funcID)
            {
                case CallType.LastStand:
                    ScriptProcessor.RunAll(script => script.OnPlayerLastStand(entity, paras[0].As<Entity>(), paras[1].As<Entity>(), paras[2].As<int>(), paras[3].As<string>(), paras[4].As<string>(), paras[5].As<Vector3>(), paras[6].As<string>(), paras[7].As<int>(), paras[8].As<int>()));
                    break;
                case CallType.StartGameType:
                    ScriptProcessor.RunAll(script => script.OnStartGameType());
                    break;
                case CallType.PlayerConnect:
                    ScriptProcessor.RunAll(script => script.OnPlayerConnecting(entity));
                    break;
                case CallType.PlayerDisconnect:
                    ScriptProcessor.RunAll(script => script.OnPlayerDisconnect(entity));
                    break;
                case CallType.PlayerDamage:
                    if (paras[6].IsNull)
                        paras[6] = new Vector3(0.0f, 0.0f, 0.0f);
                    if (paras[7].IsNull)
                        paras[7] = new Vector3(0.0f, 0.0f, 0.0f);
                    ScriptProcessor.RunAll(script => script.OnPlayerDamage(entity, paras[0].As<Entity>(), paras[1].As<Entity>(), paras[2].As<int>(), paras[3].As<int>(), paras[4].As<string>(), paras[5].As<string>(), paras[6].As<Vector3>(), paras[7].As<Vector3>(), paras[8].As<string>()));
                    break;
                case CallType.PlayerKilled:
                    if (paras[5].IsNull)
                        paras[5] = new Vector3(0.0f, 0.0f, 0.0f);
                    ScriptProcessor.RunAll(script => script.OnPlayerKilled(entity, paras[0].As<Entity>(), paras[1].As<Entity>(), paras[2].As<int>(), paras[3].As<string>(), paras[4].As<string>(), paras[5].As<Vector3>(), paras[6].As<string>()));
                    break;
                case CallType.VehicleDamage:
                    ScriptProcessor.RunAll(script => script.OnVehicleDamage(entity, paras[0].As<Entity>(), paras[1].As<Entity>(), paras[2].As<int>(), paras[3].As<int>(), paras[4].As<string>(), paras[5].As<string>(), paras[6].As<Vector3>(), paras[7].As<Vector3>(), paras[8].As<string>(), paras[9].As<int>(), paras[10].As<int>(), paras[11].As<string>()));
                    break;
                case CallType.EndGame:
                    ScriptProcessor.RunAll(script => script.OnExitLevel());
                    break;
            } 
        }

        public static void HandleNotify(int entity)
        {
            string type = GameInterface.Notify_Type();
            int numArgs = GameInterface.Notify_NumArgs();
            Parameter[] paras = CollectParameters(numArgs);

            if (type == "touch")
                return;

            if (GameInterface.Script_GetObjectType(entity) == 21) // not an actual entity
            {
                var entRef = GameInterface.Script_ToEntRef(entity);
                var entObj = Entity.GetEntity(entRef);

                entObj.HandleNotify(entity, type, paras);
            }
            else if (GameInterface.Script_GetObjectType(entity) == 24) // not an actual entity
            {
                var entRef = GameInterface.Script_GetTempEntRef();
                var entObj = Entity.GetEntity(entRef);

                entObj.HandleNotify(entity, type, paras);
            }

            ScriptProcessor.RunAll(script => script.HandleNotify(GameInterface.Script_ToEntRef(entity), type, paras));
        }

        public static bool HandleServerCommand(string commandName)
        {
            string[] args = new string[GameInterface.Cmd_Argc()];

            for (int i = 0; i < args.Length; i++)
                args[i] = GameInterface.Cmd_Argv(i);

            bool eat = false;
            ScriptProcessor.RunAll(script =>
            {
                bool success = script.ProcessServerCommand(commandName.ToLowerInvariant(), args);

                if (success)
                    eat = true;
            });
            return eat;
        }

        public static bool HandleClientCommand(string commandName, int entity)
        {
            string[] args = new string[GameInterface.Cmd_Argc_sv()];

            for (int i = 0; i < args.Length; i++)
                args[i] = GameInterface.Cmd_Argv_sv(i);

            Entity entObj = Entity.GetEntity(entity);
            bool handled = false;

            ScriptProcessor.RunAll(script =>
            {
                bool success = script.ProcessClientCommand(commandName.ToLowerInvariant(), entObj, args);
                if (success)
                    handled = true;
            });

            return handled;
        }

        public static bool HandleClientConnect(string connectString)
        {
            bool eat = false;
            try
            {
                string playerName = connectString.Split(new[] { "name" }, StringSplitOptions.None)[1];
                string playerHWID = connectString.Split(new[] { "HWID" }, StringSplitOptions.None)[1];
                string playerXUID = connectString.Split(new[] { "XUID" }, StringSplitOptions.None)[1];
                string playerIP = connectString.Split(new[] { "IP-string" }, StringSplitOptions.None)[1];
                string playerSID = connectString.Split(new[] { "steamid" }, StringSplitOptions.None)[1];
                string playerXNA = connectString.Split(new[] { "xnaddr" }, StringSplitOptions.None)[1];

                ScriptProcessor.RunAll(script =>
                {
                    string error = script.OnPlayerRequestConnection(playerName, playerHWID, playerXUID, playerIP, playerSID, playerXNA);
                    if (string.IsNullOrEmpty(error))
                        return;
                    eat = true;
                    GameInterface.SetConnectErrorMsg(error);
                });
                return eat;
            }
            catch (Exception ex)
            {
                Utilities.PrintToConsole($"[InfinityScript] An error occurred during the handling of a client connecting!: {ex.Message}\nAdditional Info:{ex.Data}");
                return false;
            }
        }

        private static Parameter[] CollectParameters(int numArgs)
        {
            Parameter[] paras = new Parameter[numArgs];

            for (int i = 0; i < numArgs; ++i)
            {
                var ptype = GameInterface.Script_GetType(i);

                switch (ptype)
                {
                    case VariableType.Integer:
                        paras[i] = GameInterface.Script_GetInt(i);
                        break;
                    case VariableType.String:
                    case VariableType.IString:
                        paras[i] = GameInterface.Script_GetString(i);
                        break;
                    case VariableType.Float:
                        paras[i] = GameInterface.Script_GetFloat(i);
                        break;
                    case VariableType.Entity:
                        paras[i] = Entity.GetEntity(GameInterface.Script_GetEntRef(i));
                        break;
                    case VariableType.Vector:
                        GameInterface.Script_GetVector(i, out var value);
                        paras[i] = value;
                        break;
                    default:
                        paras[i] = null;
                        break;
                }
            }

            return paras.ToArray();
        }
    } 
}
