
using UnityEngine;

public static class BatteryManager
{
    private static float percentage;
    private static string status;


    public static bool Charging()
    {
        status = SystemInfo.batteryStatus.ToString();
        if (status == "Charging")
        {
            return true;
        }
        else //if (status == "Discharging")
        {
            return false;
        }
    }
    public static float CurrentBatteryPercentage()

    {
        percentage = SystemInfo.batteryLevel * 100;
        return percentage;
    }
}

