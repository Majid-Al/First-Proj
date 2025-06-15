using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.Events;

public class ShowRewardAdScript : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] Button _showAdButton;
    [SerializeField] GameObject cannotLoadAdPanel;
    [SerializeField] Panel_Roles panelRoles;
    [SerializeField] UnityEvent adSuccessMethodCall;
    public bool _isAdLoaded = false;
    public bool adShownSuccess = false;

    [SerializeField] string androidAdRewardId = "Mafia-RewardAD1";
    string _adUnitId = null; // This will remain null for unsupported platforms

    void Awake()
    {
        _adUnitId = androidAdRewardId;

        // Disable the button until the ad is ready to show:

        _showAdButton.interactable = false;

    }

    private void Start()
    {
        LoadAd();

    }

    public void LoadAd()
    {       
        // custom flag to prevent redundant loads ---
        if (_isAdLoaded)
        {
            Debug.Log("Ad for " + _adUnitId + " is already loaded and ready.");
            _showAdButton.interactable = true; // Ensure button is enabled
            return;
        }

        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
        if (adUnitId.Equals(_adUnitId))
        {
            _isAdLoaded = true;

            // Configure the button to call the ShowAd() method when clicked:
            // Enable the button for users to click:
            _showAdButton.interactable = true;
        }
    }

    // Implement a method to execute when the user clicks the button:
    public void ShowAd()
    {
        if (!_isAdLoaded)
        {
            Debug.LogWarning("Attempted to show ad before it was loaded. Loading again...");
            LoadAd(); // Try to load it if not loaded
            return;
        }
        // ----------------------------------------

        _showAdButton.interactable = false;
        Advertisement.Show(_adUnitId, this);

        _isAdLoaded = false;
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.
        }
            LoadAd();
        adShownSuccess = true;
        //if (adSuccessMethodCall != null)
        //{
        //adSuccessMethodCall.Invoke();

        //}
            panelRoles.adShownSuccessfully();
    }

    // Implement Load and Show Listener error callbacks:

    [SerializeField] float _retryDelaySeconds = 3f;
    private int _maxRetries = 6; 
    private int _currentRetryCount = 0;
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        _isAdLoaded = false; // Ad is not loaded

        // --- MODIFIED: Implement retry logic ---
        _currentRetryCount++;
        if (_currentRetryCount <= _maxRetries)
        {
            Debug.Log($"Retrying ad load in {_retryDelaySeconds} seconds... (Attempt {_currentRetryCount}/{_maxRetries})");
            Invoke(nameof(LoadAd), _retryDelaySeconds);
        }
        else
        {
            _currentRetryCount = 0; 
            // You might want to disable the button permanently or show a "No Ad Available" message here
            _showAdButton.interactable = false;
            Instantiate(cannotLoadAdPanel);
        }
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        adShownSuccess = false;
        _isAdLoaded = false;
        LoadAd();
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        Debug.Log($" Majid Error showing Ad Unit {error.ToString()}");



        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Clean up the button listeners:
        _showAdButton.onClick.RemoveAllListeners();
    }
}
