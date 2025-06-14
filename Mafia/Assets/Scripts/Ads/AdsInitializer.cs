using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] bool _testMode = true;
    private string _gameId = "5876545";

    void Awake()
    {
        InitializeAds();
    }
    public void InitializeAds()
    {

        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Debug.Log(" Majid ad if is called ---");
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log(" Majid Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($" Majid Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
