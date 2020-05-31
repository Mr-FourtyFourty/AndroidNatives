using UnityEngine;

public static class AndroidVibrator 
{

    #region AndroidCode
#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif
    #endregion

    public static bool IsAndroid()
    {
#if UNITY_ANDROID
        return true;
#else
        return false;
#endif
    }

    #region Vibrator Functions
    public static void vibrate(long milliseconds =250)//Override for longer vibration time
    {
        if(IsAndroid())
        {
            vibrator.Call("vibrate", milliseconds);
        }
        else
        {
            Handheld.Vibrate();
        }
    }

    public static void CancelVibrate()//Stop Phone vibration Immediatly
    {
        if (IsAndroid())
         vibrator.Call("cancel");
    }
    #endregion
}
