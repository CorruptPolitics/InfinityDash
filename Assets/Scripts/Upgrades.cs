using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Upgrades : MonoBehaviour
{
    public Canvas Upgrade;
    public Canvas doublePoints;
    public Canvas coinMagnet;
    private MainMenu theMenu;
    private Scene sceneName;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene();
        if (sceneName.name == "Main Menu")
        {
            Debug.Log("Found Menu");
            theMenu = FindObjectOfType<MainMenu>();
        }
        Upgrade.enabled = false;
        doublePoints.enabled = false;
        coinMagnet.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenStore()
    {
        if (sceneName.name == "Main Menu")
        {
            theMenu.mainMenu.enabled = false;
            Upgrade.enabled = true;
        }
        else
        {
            Upgrade.enabled = true;
        }
    }

    public void BackToMenu()
    {
        theMenu.mainMenu.enabled = true;
        Upgrade.enabled = false;
    }

    public void DoublePointsUpgrade()
    {

        doublePoints.enabled = true;
        Upgrade.enabled = false;
    }

    public void CoinMagnetUpgrade()
    {

        theMenu.mainMenu.enabled = false;
        coinMagnet.enabled = true;
        Upgrade.enabled = false;
    }

    public void BackToUpgrades()
    {
        doublePoints.enabled = false;
        coinMagnet.enabled = false;
        Upgrade.enabled = true;
    }
}
