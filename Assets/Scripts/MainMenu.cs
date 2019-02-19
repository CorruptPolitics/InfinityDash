using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Canvas mainMenu;
    public Canvas gameStore;
    public Canvas credits;

	// Use this for initialization
	void Start () {

        credits.enabled = false;
        gameStore.enabled = false;
		
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
        gameStore.enabled = false;
        mainMenu.enabled = true;
    }

    public void OpenStore()
    {
        mainMenu.enabled = false;
        gameStore.enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
