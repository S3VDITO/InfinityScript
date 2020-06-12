using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace InfinityScript
{
    public static class Utilities
    {
        public static void ExecuteCommand(string command) => 
            GameInterface.Cbuf_AddText(command + "\n");

        public static void ExecuteCommand(string format, params object[] args) =>
            ExecuteCommand(string.Format(format, args));

        public static void SayTo(Entity ent, string message) => 
            SayTo(ent.EntRef, message);

        public static void SayTo(int entref, string message) => 
            SayTo(entref, "console", message);

        public static void SayTo(Entity ent, string name, string message) =>
            SayTo(ent.EntRef, name, message);

        public static void SayTo(int entref, string name, string message) => 
            RawSayTo(entref, name + ": " + message);

        public static void SayAll(string message) => 
            SayAll("console", message);

        public static void SayAll(string name, string message) =>
            RawSayAll(name + ": " + message);

        public static void RawSayAll(string message) =>
            GameInterface.SV_GameSendServerCommand(-1, -1, message);

        public static void RawSayTo(Entity ent, string message) => 
            RawSayTo(ent.EntRef, message);

        public static void RawSayTo(int entref, string message) =>
            GameInterface.SV_GameSendServerCommand(entref, -1, message);

        public static void GameSendServerCommand(this Entity ent, int id, string message) =>
            GameInterface.SV_GameSendServerCommand(ent.EntRef, id, message);

        public static bool isEntDefined(Entity ent) =>
            ent != null && GSCFunctions.GetEntByNum(ent.EntRef) != null;

        public static void PrintToConsole(string text) =>
            GameInterface.Print(text + "\n");
    }
}
