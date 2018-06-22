﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Canvas mainMenu;
    public Canvas credits;

	// Use this for initialization
	void Start () {

        credits.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Infinity Dash");
    }

    public void OpenCredits()
    {
        credits.enabled = true;
        mainMenu.enabled = false;
    }

    public void BackButton()
    {
        credits.enabled = false;
        mainMenu.enabled = true;
    }
}