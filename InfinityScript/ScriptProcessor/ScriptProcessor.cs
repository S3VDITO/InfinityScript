using System;
using System.Collections.Generic;

namespace InfinityScript
{
    internal static class ScriptProcessor
    {
        internal static List<BaseScript> Scripts = new List<BaseScript>();

        public static void AddScript(BaseScript script) => 
            Scripts.Add(script);

        public static void RunAll(Action<BaseScript> cb)
        {
            foreach (BaseScript baseScript in Scripts.ToArray())
            {
                try
                {
                    cb(baseScript);
                }
                catch (Exception ex)
                {
                    Utilities.PrintToConsole($"[InfinityScript] Exception during RunAll call: {ex.Message}");
                }
            }
        }
    }
}
