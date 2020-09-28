using System;
using System.IO;

namespace InfinityScript.Scripts
{
    public class InternalScript : BaseScript
    {
        /// Jump/Speed/Gravity control and logging

        private static string LogPathName;
        private static Stream FileStream;
        private static StreamWriter Writer;
        private static DateTime StartTime;

        public InternalScript()
        {
            InitDvars();
            InitLogger();
        }

        private void InitDvars()
        {
            GSCFunctions.SetDvarIfUninitialized("g_log", "games_mp.log");

            GSCFunctions.SetDvarIfUninitialized("is_jumpheight", Utilities.JumpHeight);
            GSCFunctions.SetDvarIfUninitialized("is_gravity", Utilities.Gravity);
            GSCFunctions.SetDvarIfUninitialized("is_speed", Utilities.Speed);

            GSCFunctions.SetDvarIfUninitialized("is_falldamage", "1");

            Utilities.JumpHeight = float.Parse(GSCFunctions.GetDvar("is_jumpheight"));
            Utilities.Gravity = int.Parse(GSCFunctions.GetDvar("is_gravity"));
            Utilities.Speed = int.Parse(GSCFunctions.GetDvar("is_speed"));


        }
        #region Game Logger
        private void InitLogger()
        {
            LogPathName = $"scripts/{GSCFunctions.GetDvar("g_log").Replace("/", "").Replace("\\", "")}";
            FileStream = File.Open(LogPathName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            Writer = new StreamWriter(FileStream);
            StartTime = DateTime.Now;
            Write("------------------------------------------------------------");
            Write("InitGame: {0}", (object)GameInterface.Dvar_InfoString_Big(1024));

            PlayerConnected += LoggerPlayerConnected;
        }

        private static void Write(string format, params object[] args)
        {
            Writer.Write(FormatTime(DateTime.Now - StartTime));
            Writer.Write(" ");
            Writer.WriteLine(string.Format(format, args));
            Writer.Flush();
        }

        private static string FormatTime(TimeSpan duration)
        {
            int totalSeconds = (int)duration.TotalSeconds;
            return string.Format("{0}:{1}", totalSeconds / 60, (totalSeconds % 60).ToString().PadLeft(2, '0')).PadLeft(6, ' ');
        }

        private void LoggerPlayerConnected(Entity player) =>
            Write("J;{0};{1};{2}", player.GUID, player.EntRef, player.Name);

        public override void OnPlayerDisconnect(Entity player) =>
            Write("Q;{0};{1};{2}", player.GUID, player.EntRef, player.Name);

        public override void OnPlayerDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc) =>
            Write("D;{0};{1};{2};{3};{4};{5}", GetDamageDetails(player), GetDamageDetails(attacker), weapon, damage, mod, hitLoc);

        public override void OnPlayerKilled(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc) 
            => Write("K;{0};{1};{2};{3};{4};{5}", GetDamageDetails(player), GetDamageDetails(attacker), weapon, damage, mod, hitLoc);

        public override void OnSay(Entity player, string name, string message)
        {
            if (message.StartsWith("/"))
                message = message.Substring(1);

            Write("say;{0};{1};{2};{3}", player.GUID, player.EntRef, name, message);
        }

        public override void OnExitLevel()
        {
            Write("OnExitLevel: executed");
        }

        private string GetDamageDetails(Entity player)
        {
            if (player == null || !player.IsPlayer)
                return ";-1;world;world";
            return string.Format("{0};{1};{2};{3}", player.GUID, player.EntRef, player.SessionTeam, player.Name);
        }
        #endregion

        public override bool OnServerCommand(string command, string[] args)
        {
            if (command == "set")
            {
                AfterDelay(500, () => 
                {
                    Utilities.JumpHeight = float.Parse(GSCFunctions.GetDvar("is_jumpheight"));
                    Utilities.Gravity = int.Parse(GSCFunctions.GetDvar("is_gravity"));
                    Utilities.Speed = int.Parse(GSCFunctions.GetDvar("is_speed"));

                    Utilities.FallDamage = Convert.ToInt32(GSCFunctions.GetDvar("is_falldamage")) > 0;
                });
            }
            return false;
        }


    }
}
