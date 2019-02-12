using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //declares the platform generator object
    public Transform platformGenerator;
    //declares where the platform generator begins
    private Vector3 platformStartPoint;
    //declares the player as the PlayerMovement script
    public PlayerMovement thePlayer;
    //declares the point at which the player starts
    private Vector3 playerStartPoint;
    private DestroyPlatforms[] platformList;
    private ScoreManager theScoreManager;
    public Text finalScore;

    public DeathMenu deathCanvas;


    // Use this for initialization
    void Start()
    {
        //sets the platform start point to the original position of the platform generator game object
        platformStartPoint = platformGenerator.position;
        //sets the player start point to the original position of the player game object
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
        finalScore.text = theScoreManager.scoreText.text;
        deathCanvas.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    //call our co-routine
    public void RestartValues()
    {
        //when the player dies stop the score from increasing
        theScoreManager.scoreIncreasing = false;
        //makes the player invisible while "dead"
        thePlayer.gameObject.SetActive(false);
        //Display Score
        finalScore.text = "Your Final " + theScoreManager.scoreText.text;
        //Display death canvas
        deathCanvas.gameObject.SetActive(true);
        //StartCoroutine("RestartGameCo");
    }

    public void Restart()
    {
        //sets platforms with the PlatformDestroyer script attached to inactive and returns them to object pool
        platformList = FindObjectsOfType<DestroyPlatforms>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        //sets the players transform position back to the player start point
        thePlayer.transform.position = playerStartPoint;
        //sets the platformGenerator's position back to the platform start point
        platformGenerator.position = platformStartPoint;
        //turns the player visible again
        thePlayer.gameObject.SetActive(true);
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }

    /*declare co-routine named RestartGameCo using IEnumerator
    public IEnumerator RestartGameCo()
    {
        //when the player dies stop the score from increasing
        theScoreManager.scoreIncreasing = false;
        //makes the player invisible while "dead"
        thePlayer.gameObject.SetActive(false);
        //sets a half second delay before game restarts
        yield return new WaitForSeconds(0.5f);
        //sets platforms with the PlatformDestroyer script attached to inactive and returns them to object pool
        platformList = FindObjectsOfType<DestroyPlatforms>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        //sets the players transform position back to the player start point
        thePlayer.transform.position = playerStartPoint;
        //sets the platformGenerator's position back to the platform start point
        platformGenerator.position = platformStartPoint;
        //turns the player visible again
        thePlayer.gameObject.SetActive(true);
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }*/

}