using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    //Script checks which powerups to use and how much time is left.
    private bool doublePoints;
    private bool coinMagnet;
    public bool powerUpActive;
    private float powerUpCountDown;
    private GameObject doubleObject;
    private GameObject magnetObject;
    private Text doublePointsText;
    private Text coinMagnetText;
    private bool doublePointsPickup;

    private ScoreManager theScoreManager;
    private Transform playerTransform;
    private GameObject[] theCoins;
    private float normalPointValue;
    private float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        doubleObject = GameObject.Find("DoublePointsText");
        magnetObject = GameObject.Find("CoinMagnetText");
        doublePointsText = doubleObject.GetComponent<Text>();
        coinMagnetText = magnetObject.GetComponent<Text>();
        doublePointsText.enabled = false;
        coinMagnetText.enabled = false;
        theScoreManager = FindObjectOfType<ScoreManager>();
        playerTransform = GameObject.Find("Player").transform;
        doublePointsPickup = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpActive)
        {
            //set countdown timer in the heirarchy inspector. Countsdown every second.
            powerUpCountDown -= Time.deltaTime;

            //Picks up powerup, double points! 
            //Also checks to not stack double points if ever happens. Upgrade in Progress
            if (doublePoints && !doublePointsPickup)
            {
                doublePointsPickup = true;
                StartCoroutine("DisplayPowerUp");
                theScoreManager.pointsPerSecond = normalPointValue * 2;
                theScoreManager.doubleScore = true;
            }

            //Pick up magnet, coins come to player in certain distance. 
            //Upgrade in progress.
            if (coinMagnet)
            {
                StartCoroutine("DisplayPowerUp");
                theCoins = GameObject.FindGameObjectsWithTag("pickup");
                foreach (GameObject coin in theCoins)
                {
                    if (Vector3.Distance(coin.transform.position, playerTransform.position) < 10)
                    {
                        coin.transform.position = Vector3.MoveTowards(coin.transform.position, playerTransform.position, speed);
                    }
                }
            }

            //resets values
            if (powerUpCountDown <= 0)
            {
                theScoreManager.pointsPerSecond = normalPointValue;
                powerUpActive = false;
                theScoreManager.doubleScore = false;
            }
        }
    }

    //function that passes double points value and timer.  More values will be put here if we plan on more powerups.
    public void ActivatePowerUp(bool points, bool magnet, float timer)
    {
        doublePoints = points;
        coinMagnet = magnet;
        powerUpCountDown = timer;
        normalPointValue = theScoreManager.pointsPerSecond;
        powerUpActive = true;
    }

    //Function that displays a text for what powerup was picked up
    IEnumerator DisplayPowerUp()
    {
        if (doublePoints)
        {
            doublePointsText.enabled = true;
            yield return new WaitForSeconds(3f);
            doublePointsText.enabled = false;
        }

        if (coinMagnet)
        {
            coinMagnetText.enabled = true;
            yield return new WaitForSeconds(3f);
            coinMagnetText.enabled = false;
        }
    }
}
