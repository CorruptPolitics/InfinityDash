using UnityEngine;
using UnityEngine.UI;

public class MusicSwitcher : MonoBehaviour
{
    Button MusicButton;
    public GameObject hackButton;
    public GameObject heatButton;
    public GameObject raceButton;
    public GameObject exitMusic;
    public AudioSource audioManager;
    public AudioClip hackMusic;
    public AudioClip heatSeekMusic;
    public AudioClip raceMusic;

    void Start()
    {
        //Fetch the Dropdown GameObject
        MusicButton = GetComponent<Button>();
        hackButton.SetActive(false);
        heatButton.SetActive(false);
        raceButton.SetActive(false);
        exitMusic.SetActive(false);
    }

    public void OpenMusicClips()
    {
        hackButton.SetActive(true);
        heatButton.SetActive(true);
        raceButton.SetActive(true);
        exitMusic.SetActive(true);
    }

    public void CloseMusicClips()
    {
        hackButton.SetActive(false);
        heatButton.SetActive(false);
        raceButton.SetActive(false);
        exitMusic.SetActive(false);
    }

    public void StartHackMusic()
    {
        audioManager.clip = hackMusic;
        audioManager.Play();
        hackButton.SetActive(false);
        heatButton.SetActive(false);
        raceButton.SetActive(false);
        exitMusic.SetActive(false);
    }

    public void StartHeatSeeker()
    {
        audioManager.clip = heatSeekMusic;
        audioManager.Play();
        hackButton.SetActive(false);
        heatButton.SetActive(false);
        raceButton.SetActive(false);
        exitMusic.SetActive(false);
    }

    public void StartRaceMusic()
    {
        audioManager.clip = raceMusic;
        audioManager.Play();
        hackButton.SetActive(false);
        heatButton.SetActive(false);
        raceButton.SetActive(false);
        exitMusic.SetActive(false);
    }
}