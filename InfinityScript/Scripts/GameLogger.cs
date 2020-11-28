using System;
using System.IO;

namespace InfinityScript
{
    public class GameLogger : BaseScript
    {
        private static string _logPathName;
        private static Stream _fileStream;
        private static StreamWriter _writer;
        private static DateTime _startTime;

        public GameLogger()
        {
            _logPathName = $"scripts/{GSCFunctions.GetDvar("g_log").Replace("/", "").Replace("\\", "")}";
            _fileStream = File.Open(_logPathName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            _writer = new StreamWriter(_fileStream);
            _startTime = DateTime.Now;

            Write("------------------------------------------------------------");
            Write("InitGame: {0}", (object)GameInterface.Dvar_InfoString_Big(1024));

            PlayerConnected += player => Write("J;{0};{1};{2}", player.HWID, player.EntRef, player.Name);
        }

        public static void Write(string format, params object[] args)
        {
            _writer.Write(FormatTime(DateTime.Now - _startTime));
            _writer.Write(" ");
            _writer.WriteLine(string.Format(format, args));
            _writer.Flush();
        }

        private static string FormatTime(TimeSpan duration)
        {
            int totalSeconds = (int)duration.TotalSeconds;
            return string.Format("{0}:{1}", totalSeconds / 60, (totalSeconds % 60).ToString().PadLeft(2, '0')).PadLeft(6, ' ');
        }

        public override void OnExitLevel() =>
            Write("OnExitLevel: executed");

        public override void OnPlayerDisconnect(Entity player) =>
            Write("Q;{0};{1};{2}", player.HWID, player.EntRef, player.Name);

        public override void OnPlayerDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc) =>
            Write("D;{0};{1};{2};{3};{4};{5}", GetDamageDetails(player), GetDamageDetails(attacker), weapon, damage, mod, hitLoc);

        public override void OnPlayerKilled(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc)
            => Write("K;{0};{1};{2};{3};{4};{5}", GetDamageDetails(player), GetDamageDetails(attacker), weapon, damage, mod, hitLoc);

        public override void OnSay(Entity player, string name, string message)
        {
            if (message.StartsWith("/"))
                message = message.Substring(1);

            Write("say;{0};{1};{2};{3}", player.HWID, player.EntRef, name, message);
        }

        private string GetDamageDetails(Entity player)
        {
            if (player == null || !player.IsPlayer)
                return ";-1;world;world";

            return string.Format("{0};{1};{2};{3}", player.HWID, player.EntRef, player.SessionTeam, player.Name);
        }
    }
}
