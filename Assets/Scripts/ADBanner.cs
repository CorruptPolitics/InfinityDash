using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADBanner : MonoBehaviour
{
    public string appleID = "3855560";
    public string bannerPlacement = "banner";
    public bool testMode = false;

    void Start()
    {
        Advertisement.Initialize(appleID, testMode);
        StartCoroutine(ShowBannerWhenInitialized());
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(bannerPlacement);
    }
}