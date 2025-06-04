using AdiveryUnity;
using UnityEditor.PackageManager;
using UnityEngine;

public class AdiveryAdHandler : MonoBehaviour
{
    AdiveryListener listener;

    public void Start()
    {
        // test App-ID : 59c36ce3-7125-40a7-bd34-144e6906c796
        Adivery.Configure("c93025c2-35cd-4922-bdb6-5dc56b54b33f");


        // test Placement-Id : 38b301f2-5e0c-4776-b671-c6b04a612311
        Adivery.PrepareInterstitialAd("f7afb488-063d-4d6e-9d0a-6971cb0b6e07");
        listener = new AdiveryListener();

        listener.OnError += OnError;
        listener.OnInterstitialAdLoaded += OnInterstitialAdLoaded;



        Adivery.PrepareRewardedAd("e85a1120-2d94-4922-b31b-28c7f100404e");
        listener.OnRewardedAdLoaded += OnRewardedLoaded;
        listener.OnRewardedAdClosed += OnRewardedClosed;


        Adivery.AddListener(listener);

    }

    public void OnError(object caller, AdiveryError error)
    {
        Debug.Log("placement: " + error.PlacementId + " error: " + error.Reason);
    }

    #region---InterstaitialAd

    public void OnInterstitialAdLoaded(object caller, string placementId)
    {
        Debug.Log("Interstitial Ad Loaded for: " + placementId);
        //proceed
    }

    public void ShowInterstitialAd()
    {
        if (Adivery.IsLoaded("f7afb488-063d-4d6e-9d0a-6971cb0b6e07"))
        {
            Adivery.Show("f7afb488-063d-4d6e-9d0a-6971cb0b6e07");
        }
        else
        {
            // there is a problem with adding the new roll please try again later - message on a PopUp
            Debug.Log("there is a problem with adding the new roll please try again later");
        }
    }

    #endregion


    #region---RewardAd
    public void OnRewardedLoaded(object caller, string placementId)
    {
        Debug.Log("Rewarded Ad Loaded for: " + placementId);
    }
    public void OnRewardedClosed(object caller, AdiveryReward reward)
    {
        // Check if User should receive the reward
        if (reward.IsRewarded)
        {
             // Implement getRewardAmount yourself

        }else
        {
            // there is a problem with adding the new roll please try again later - message
        }
    }
    public bool ShowRewardAd()
    {
        if (Adivery.IsLoaded("e85a1120-2d94-4922-b31b-28c7f100404e"))
        {
            Adivery.Show("e85a1120-2d94-4922-b31b-28c7f100404e");
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

}
