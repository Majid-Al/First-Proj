using UnityEngine;

public class BazaarReview : MonoBehaviour
{
#if UNITY_ANDROID && !UNITY_EDITOR
    public static void OpenReviewPage()
    {
        try
        {
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

                using (AndroidJavaClass reviewHelper = new AndroidJavaClass("com.ingenesis.mafia.ReviewHelper"))
                {
                    string packageName = currentActivity.Call<string>("getPackageName");
                    reviewHelper.CallStatic("openBazaarReview", currentActivity, packageName);
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error opening Bazaar review page: " + e.Message);
        }
    }
#else
    public static void OpenReviewPage()
    {
        Debug.Log("Bazaar review is only available on Android device.");
    }
#endif
    public void OpenDeveloperPage()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            using (AndroidJavaClass reviewHelper = new AndroidJavaClass("com.ingenesis.mafia.ReviewHelper"))
            {
                reviewHelper.CallStatic("openBazaarDeveloperPage", activity, "381042783663");
            }
        }
#endif
    }



}
