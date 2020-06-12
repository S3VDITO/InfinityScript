using System;
using System.Collections.Generic;

namespace InfinityScript
{
    internal static class ScriptProcessor
    {
        internal static List<BaseScript> _scripts = new List<BaseScript>();

        public static void AddScript(BaseScript script)
        {
            _scripts.Add(script);
        }

        public static void RunAll(Action<BaseScript> cb)
        {
            foreach (BaseScript baseScript in _scripts.ToArray())
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
