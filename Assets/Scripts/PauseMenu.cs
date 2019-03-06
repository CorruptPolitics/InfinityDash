using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public GameObject pauseMenu;
    MusicSwitcher theMusic;

    private void Start()
    {
        theMusic = FindObjectOfType<MusicSwitcher>();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        theMusic.audioManager.Pause();
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        theMusic.audioManager.Play();
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().Restart();
        pauseMenu.SetActive(false);
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
