#pragma warning disable SA1300 // Element should begin with upper-case letter
#pragma warning disable SA1602 // Enumeration items should be documented

namespace InfinityScript
{
    public enum ServerCommand
    {
        chatMessage = 84, // 0x00000054
        teamChatMessage = 85, // 0x00000055
        unknown = 86, // 0x00000056
        stopLocalSound = 87, // 0x00000057
        blur = 88, // 0x00000058
        clearBlur = 89, // 0x00000059
        mapRestart = 90, // 0x0000005A
        selectWeapon = 97, // 0x00000061
        parseScores = 98, // 0x00000062
        announcement = 99, // 0x00000063
        iPrintLn = 101, // 0x00000065
        iPrintLn2 = 102, // 0x00000066
        iPrintLnBold = 103, // 0x00000067
        openScriptMenu = 111, // 0x0000006F
        closeScriptMenu = 112, // 0x00000070
        setDvars = 113, // 0x00000071
        kickPlayer = 114, // 0x00000072
        openMenu = 115, // 0x00000073
        closeMenu = 116, // 0x00000074
        showHudSplash = 117, // 0x00000075
    }
}
