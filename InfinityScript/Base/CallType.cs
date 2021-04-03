#pragma warning disable SA1300 // Element should begin with upper-case letter
#pragma warning disable SA1602 // Enumeration items should be documented

namespace InfinityScript
{
    internal enum CallType
    {
        LastStand = -1, // 0xFFFFFFFF
        StartGameType = 0,
        PlayerConnect = 1,
        PlayerDisconnect = 2,
        PlayerDamage = 3,
        PlayerKilled = 4,
        VehicleDamage = 5,
        EndGame = 6,
    }
}