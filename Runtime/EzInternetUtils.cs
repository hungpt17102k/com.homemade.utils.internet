using System.Runtime.InteropServices;

namespace com.homemade.utils.internet
{
    public static class EzInternetUtils
    {
        public static void OpenAndroidSetting()
        {
#if UNITY_ANDROID
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaObject settingsIntent = new AndroidJavaObject("android.content.Intent", "android.settings.SETTINGS");
                currentActivity.Call("startActivity", settingsIntent);
            }
#endif
        }

        public static void OpenIOS_Setting()
        {
#if UNITY_IOS          
            Application.OpenURL("app-settings:");
#endif
        }

        public static void OpenIOS_Setting_Native()
        {
#if UNITY_IOS          
            OpenIOSSettings();
#endif
        }

#if UNITY_IOS
        [DllImport("__Internal")]
        private static extern void OpenIOSSettings();
#endif
    }
}
