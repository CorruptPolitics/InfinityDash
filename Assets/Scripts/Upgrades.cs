using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Upgrades : MonoBehaviour
{
    public Canvas Upgrade;
    public Canvas doublePoints;
    public Canvas coinMagnet;

    // Start is called before the first frame update
    void Start()
    {
        Upgrade.enabled = false;
        doublePoints.enabled = false;
        coinMagnet.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenUpgradesInMenu()
    {
        Upgrade.enabled = true;
    }

    public void OpenUpgradesAfterDeath()
    {
        Upgrade.enabled = true;
    }

    public void BackToDeathMenu()
    {
        Upgrade.enabled = false;
    }

    public void BackToMenu()
    {
        Upgrade.enabled = false;
    }

    public void DoublePointsUpgrade()
    {
        doublePoints.enabled = true;
        Upgrade.enabled = false;
    }

    public void CoinMagnetUpgrade()
    {
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
