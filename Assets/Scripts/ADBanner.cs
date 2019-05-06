using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADBanner : MonoBehaviour
{

    public string bannerPlacement = "banner";
    public bool testMode = false;


#if UNITY_IOS
    public const string gameID = "3139932";
#elif UNITY_ANDROID
    public const string gameID = "3139933";
#elif UNITY_EDITOR
    public const string gameID = "1111111";
#endif

    void Start()
    {
        Advertisement.Initialize(gameID, testMode);
        Advertisement.Banner.Show(bannerPlacement);
    }
}