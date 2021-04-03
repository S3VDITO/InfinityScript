#pragma warning disable SA1310 // Field names should not contain underscore

namespace InfinityScript
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    using static InfinityScript.GSCFunctions;

    public static class Utilities
    {
        private const string FACTION_STRING_TABLE = "mp/factionTable.csv";
        private const string KILLSTREAK_STRING_TABLE = "mp/killstreakTable.csv";
        private const string PERKS_STRING_TABLE = "mp/perktable.csv";

        private const byte FACTION_REF_COL = 0;
        private const byte FACTION_NAME_COL = 1;
        private const byte FACTION_SHORT_NAME_COL = 2;
        private const byte FACTION_ELIMINATED_COL = 3;
        private const byte FACTION_FORFEITED_COL = 4;
        private const byte FACTION_ICON_COL = 5;
        private const byte FACTION_HUD_ICON_COL = 6;
        private const byte FACTION_VOICE_PREFIX_COL = 7;
        private const byte FACTION_SPAWN_MUSIC_COL = 8;
        private const byte FACTION_WIN_MUSIC_COL = 9;
        private const byte FACTION_FLAG_MODEL_COL = 10;
        private const byte FACTION_FLAG_CARRY_MODEL_COL = 11;
        private const byte FACTION_FLAG_ICON_COL = 12;
        private const byte FACTION_FLAG_FX_COL = 13;
        private const byte FACTION_COLOR_R_COL = 14;
        private const byte FACTION_COLOR_G_COL = 15;
        private const byte FACTION_COLOR_B_COL = 16;
        private const byte FACTION_HEAD_ICON_COL = 17;
        private const byte FACTION_CRATE_MODEL_COL = 18;
        private const byte FACTION_DEPLOY_MODEL_COL = 19;

        private const byte STREAKCOUNT_MAX_COUNT = 3;
        private const byte KILLSTREAK_NAME_COLUMN = 1;
        private const byte KILLSTREAK_KILLS_COLUMN = 4;
        private const byte KILLSTREAK_EARNED_HINT_COLUMN = 6;
        private const byte KILLSTREAK_SOUND_COLUMN = 7;
        private const byte KILLSTREAK_EARN_DIALOG_COLUMN = 8;
        private const byte KILLSTREAK_ENEMY_USE_DIALOG_COLUMN = 11;
        private const byte KILLSTREAK_WEAPON_COLUMN = 12;
        private const byte KILLSTREAK_ICON_COLUMN = 14;
        private const byte KILLSTREAK_OVERHEAD_ICON_COLUMN = 15;
        private const byte KILLSTREAK_DPAD_ICON_COLUMN = 16;

        public static unsafe int Gravity
        {
            get => *(int*)(IntPtr)4679878;
            set => *(int*)(IntPtr)4679878 = value;
        }

        public static unsafe int Speed
        {
            get => *(int*)(IntPtr)4677866;
            set => *(int*)(IntPtr)4677866 = value;
        }

        public static unsafe float JumpHeight
        {
            get => *(float*)(IntPtr)7186184;
            set => *(float*)(IntPtr)7186184 = value;
        }

        public static bool FallDamage
        {
            set
            {
                switch (value)
                {
                    case true:
                        for (int i = 0; i < BitConverter.GetBytes((float)128f).Length; i++)
                        {
                            Marshal.WriteByte((IntPtr)0x6D9634, i, BitConverter.GetBytes((float)128f)[i]);
                        }

                        break;

                    case false:
                        for (int i = 0; i < BitConverter.GetBytes((float)999999f).Length; i++)
                        {
                            Marshal.WriteByte((IntPtr)0x6D9634, i, BitConverter.GetBytes((float)999999f)[i]);
                        }

                        break;
                }
            }
        }

        public static string GetTeamName(string team) => TableLookupIString(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_NAME_COL);

        public static string GetTeamShortName(string team) => TableLookupIString(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_SHORT_NAME_COL);

        public static string GetTeamForfeitedString(string team) => TableLookupIString(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_FORFEITED_COL);

        public static string GetTeamEliminatedString(string team) => TableLookupIString(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_ELIMINATED_COL);

        public static string GetTeamIcon(string team) => TableLookup(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_ICON_COL);

        public static string GetTeamHudIcon(string team) => TableLookup(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_HUD_ICON_COL);

        public static string GetTeamHeadIcon(string team) => TableLookup(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_HEAD_ICON_COL);

        public static string GetTeamVoicePrefix(string team) => TableLookup(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_VOICE_PREFIX_COL);

        public static string GetTeamSpawnMusic(string team) => TableLookup(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_SPAWN_MUSIC_COL);

        public static string GetTeamWinMusic(string team) => TableLookup(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_WIN_MUSIC_COL);

        public static string GetTeamFlagModel(string team) => TableLookup(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_FLAG_MODEL_COL);

        public static string GetTeamFlagCarryModel(string team) => TableLookup(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_FLAG_CARRY_MODEL_COL);

        public static string GetTeamFlagIcon(string team) => TableLookup(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_FLAG_ICON_COL);

        public static string GetTeamFlagFX(string team) => TableLookup(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_FLAG_FX_COL);

        public static Vector3 GetTeamColor(string team) =>
            new Vector3(
                Convert.ToSingle(TableLookup(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_COLOR_R_COL)),
                Convert.ToSingle(TableLookup(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_COLOR_G_COL)),
                Convert.ToSingle(TableLookup(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_COLOR_B_COL)));

        public static string GetTeamCrateModel(string team) => TableLookup(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_CRATE_MODEL_COL);

        public static string GetTeamDeployModel(string team) => TableLookup(FACTION_STRING_TABLE, FACTION_REF_COL, GetMapCustom(team + "char"), FACTION_DEPLOY_MODEL_COL);

        public static string GetKillstreakHint(string streakName) => TableLookupIString(KILLSTREAK_STRING_TABLE, KILLSTREAK_NAME_COLUMN, streakName, KILLSTREAK_EARNED_HINT_COLUMN);

        public static bool GetKillstreakInformEnemy(string streakName) => Convert.ToInt32(TableLookup(KILLSTREAK_STRING_TABLE, KILLSTREAK_NAME_COLUMN, streakName, KILLSTREAK_ENEMY_USE_DIALOG_COLUMN)) > 0;

        public static string GetKillstreakSound(string streakName) => TableLookup(KILLSTREAK_STRING_TABLE, KILLSTREAK_NAME_COLUMN, streakName, KILLSTREAK_SOUND_COLUMN);

        public static string GetKillstreakDialog(string streakName) => TableLookup(KILLSTREAK_STRING_TABLE, KILLSTREAK_NAME_COLUMN, streakName, KILLSTREAK_EARN_DIALOG_COLUMN);

        public static string GetKillstreakWeapon(string streakName) => TableLookup(KILLSTREAK_STRING_TABLE, KILLSTREAK_NAME_COLUMN, streakName, KILLSTREAK_WEAPON_COLUMN);

        public static string GetKillstreakIcon(string streakName) => TableLookup(KILLSTREAK_STRING_TABLE, KILLSTREAK_NAME_COLUMN, streakName, KILLSTREAK_ICON_COLUMN);

        public static string GetKillstreakCrateIcon(string streakName) => TableLookup(KILLSTREAK_STRING_TABLE, KILLSTREAK_NAME_COLUMN, streakName, KILLSTREAK_OVERHEAD_ICON_COLUMN);

        public static string GetKillstreakDpadIcon(string streakName) => TableLookup(KILLSTREAK_STRING_TABLE, KILLSTREAK_NAME_COLUMN, streakName, KILLSTREAK_DPAD_ICON_COLUMN);

        public static int GetKillstreakIndex(string streakName) => TableLookupRowNum(KILLSTREAK_STRING_TABLE, KILLSTREAK_NAME_COLUMN, streakName) - 1;

        public static string GetKillstreakEnemySound(string streakName) => System.Text.RegularExpressions.Regex.Replace(GetKillstreakDialog(streakName), "achieve", "enemy");

        public static string UpgradePerk(string perkName) => TableLookup(PERKS_STRING_TABLE, 1, perkName, 8);

        public static void ExecuteCommand(string command) => GameInterface.Cbuf_AddText(command + "\n");

        public static void ExecuteCommand(string format, params object[] args) => ExecuteCommand(string.Format(format, args));

        public static void SayTo(Entity ent, string message) => SayTo(ent.EntRef, message);

        public static void SayTo(int entref, string message) => SayTo(entref, "console", message);

        public static void SayTo(Entity ent, string name, string message) => SayTo(ent.EntRef, name, message);

        public static void SayTo(int entref, string name, string message) => RawSayTo(entref, name + ": " + message);

        public static void SayAll(string message) => SayAll("console", message);

        public static void SayAll(string name, string message) => RawSayAll(name + ": " + message);

        public static void RawSayAll(string message) => GameInterface.SV_GameSendServerCommand(-1, -1, message);

        public static void RawSayTo(Entity ent, string message) => RawSayTo(ent.EntRef, message);

        public static void RawSayTo(int entref, string message) => GameInterface.SV_GameSendServerCommand(entref, -1, message);

        public static void GameSendServerCommand(this Entity ent, int id, string message) => GameInterface.SV_GameSendServerCommand(ent.EntRef, id, message);

        public static bool IsEntityDefined(Entity ent) => ent != null && GetEntByNum(ent.EntRef) != null;

        public static void PrintToConsole(string text) => GameInterface.Print(text + "\n");

        public static void ChangeLeaderVoice(string team, string prefix)
        {
            switch (prefix)
            {
                case "RU_":
                case "AF_":
                case "IC_":
                case "US_":
                case "FR_":
                case "UK_":
                case "PC_":
                    // all ok, going next
                    break;
                default:
                    throw new ArgumentException("Invalid prefix voice");
            }

            byte[] bytePrefix = new ASCIIEncoding().GetBytes(prefix);

            switch (team)
            {
                case "axis":
                    for (int i = 0; i < bytePrefix.Length; i++)
                    {
                        Marshal.WriteByte((IntPtr)0x22A6A665, i, bytePrefix[i]); // RU_ (Russian wariors, lol)
                        Marshal.WriteByte((IntPtr)0x22A6A783, i, bytePrefix[i]); // AF_ (Africa militia)
                        Marshal.WriteByte((IntPtr)0x22A6A881, i, bytePrefix[i]); // IC_ (Makarov)
                    }

                    return;
                case "allies":
                    for (int i = 0; i < bytePrefix.Length; i++)
                    {
                        Marshal.WriteByte((IntPtr)0x22A6AB66, i, bytePrefix[i]); // US_ (Delta)
                        Marshal.WriteByte((IntPtr)0x22A6AC61, i, bytePrefix[i]); // FR_ (GIGN)
                        Marshal.WriteByte((IntPtr)0x22A6A95E, i, bytePrefix[i]); // UK_ (SAS)
                        Marshal.WriteByte((IntPtr)0x22A6AA5E, i, bytePrefix[i]); // PC_ (PMC)
                    }

                    return;
                default:
                    throw new ArgumentException("Invalid team");
            }
        }
    }
}
