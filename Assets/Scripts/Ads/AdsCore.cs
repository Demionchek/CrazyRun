using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class AdsCore : MonoBehaviour
{
    [SerializeField] private bool _testMode = true;

    private string _gameId = "4617170";

    private string _video = "Interstitial_Android";
    private string _banner = "Banner_Android";

    private void Start()
    {
        Advertisement.Initialize(_gameId, _testMode);

        StartCoroutine(ShowBannerWhenInitialized());
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    public static void ShowAdsVideo(string placementId)
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(placementId);
        }
        else
        {
            Debug.Log("Advertisement not ready!");
        }
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(_banner);
    }
}
