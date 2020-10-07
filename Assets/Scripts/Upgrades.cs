using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Upgrades : MonoBehaviour
{
    public Canvas Upgrade;
    Scene theScene;
    GameObject theMainMenu;

    // Start is called before the first frame update
    void Awake()
    {
        Upgrade.enabled = false;
        theScene = SceneManager.GetActiveScene();
        if (theScene.name == "Main Menu")
        {
            theMainMenu = GameObject.Find("Main Menu");
        }

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
        theMainMenu.SetActive(true);
        Upgrade.enabled = false;
    }

    public void UpgradeMagnet()
    {

    }

    public void UpgradeDoublePoints()
    {

    }
}
