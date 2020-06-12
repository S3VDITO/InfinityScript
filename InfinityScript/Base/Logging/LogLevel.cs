using System;

namespace InfinityScript
{
    [Flags]
    public enum LogLevel
    {
        None = 0,
        Trace = 1,
        Debug = 2,
        Info = 4,
        Warning = 8,
        Error = 16, // 0x00000010
        Critical = 32, // 0x00000020
        All = Critical | Error | Warning | Info | Debug | Trace, // 0x0000003F
    }
}
