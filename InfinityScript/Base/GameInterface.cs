﻿namespace InfinityScript
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    internal static class GameInterface
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Script_PushString(string str);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_PushInt")]
        public static extern void Script_PushInt(int value);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_PushFloat")]
        public static extern void Script_PushFloat(float value);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_PushEntRef")]
        public static extern void Script_PushEntRef(int value);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_PushVector")]
        public static extern void Script_PushVector(float x, float y, float z);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_Call")]
        public static extern void Script_Call(int functionID, int entref, int numParams);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_GetType")]
        public static extern VariableType Script_GetType(int index);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string Script_GetString(int index);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_GetInt")]
        public static extern int Script_GetInt(int index);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_GetFloat")]
        public static extern float Script_GetFloat(int index);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_GetEntRef")]
        public static extern int Script_GetEntRef(int index);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_GetVector")]
        public static extern void Script_GetVector(int index, out Vector3 vector);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_NotifyNumArgs")]
        public static extern int Notify_NumArgs();

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_CleanReturnStack")]
        public static extern void Script_CleanReturnStack();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string Notify_Type();

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_GetObjectType")]
        public static extern int Script_GetObjectType(int obj);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_ToEntRef")]
        public static extern int Script_ToEntRef(int obj);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_GetField")]
        public static extern int Script_GetField(int entref, int field);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_SetField")]
        public static extern int Script_SetField(int entref, int field);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Script_NotifyNum(int entref, string notify, int numArgs);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Print(string s);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_SetDropItemEnabled")]
        public static extern bool SetDropItemEnabled(bool enabled);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string Dvar_InfoString_Big(int flag);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_AddTestClient")]
        public static extern int AddTestClient();

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_Cmd_Argc")]
        public static extern int Cmd_Argc();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string Cmd_Argv(int arg);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_Cmd_Argc_sv")]
        public static extern int Cmd_Argc_sv();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string Cmd_Argv_sv(int arg);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Cbuf_AddText(string command);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_GetPing")]
        public static extern int GetPing(int entref);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_GetClientAddress")]
        public static extern long GetClientAddress(int entref);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string GetEntrefHWID(int entid);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Cmd_TokenizeString(string tokens);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_Cmd_EndTokenizedString")]
        public static extern void Cmd_EndTokenizedString();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Script_NotifyLevel(string notify, int numArgs);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SV_GameSendServerCommand(int entid, int id, string message);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_GetTempEntRef")]
        public static extern int Script_GetTempEntRef();

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_SetConnectErrorMsg")]
        public static extern void SetConnectErrorMsg(string error);

        [DllImport("TeknoMW3S.dll", EntryPoint = "GI_TempFunc")]
        public static extern void TempFunc();
    }
}
