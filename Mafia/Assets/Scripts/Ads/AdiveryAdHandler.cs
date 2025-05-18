using AdiveryUnity;
using UnityEngine;

public class AdiveryAdHandler : MonoBehaviour
{
    AdiveryListener listener;

    public void Start()
    {

        Adivery.Configure("59c36ce3-7125-40a7-bd34-144e6906c796");    /// change this with App-ID
        Adivery.PrepareInterstitialAd("38b301f2-5e0c-4776-b671-c6b04a612311");  /// change this with PLACEMENT_ID
        listener = new AdiveryListener();

        listener.OnError += OnError;
        listener.OnInterstitialAdLoaded += OnInterstitialAdLoaded;

        Adivery.AddListener(listener);
        Debug.Log("its called");
    }

    public void OnInterstitialAdLoaded(object caller, string placementId)
    {
        Debug.Log("Add Loaded");
        Debug.Log("Add Loaded for: " + placementId);
    }

    public void OnError(object caller, AdiveryError error)
    {
        Debug.Log("placement: " + error.PlacementId + " error: " + error.Reason);
    }


    public void ShowAdd()
    {
        if (Adivery.IsLoaded("38b301f2-5e0c-4776-b671-c6b04a612311"))
        {
            Adivery.Show("38b301f2-5e0c-4776-b671-c6b04a612311");
        }
    }

}
