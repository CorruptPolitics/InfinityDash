﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    //Script checks which powerups to use and how much time is left.
    private bool doublePoints;
    private bool coinMagnet;
    public bool powerUpActive;
    private float powerUpCountDown;
    private GameObject doublePointsText;
    private GameObject coinMagnetText;

    private ScoreManager theScoreManager;
    private Transform playerTransform;
    private GameObject[] theCoins;
    private float normalPointValue;
    private float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        doublePointsText = GameObject.Find("DoublePointsText");
        coinMagnetText = GameObject.Find("CoinMagnetText");
        doublePointsText.SetActive(false);
        coinMagnetText.SetActive(false);
        theScoreManager = FindObjectOfType<ScoreManager>();
        playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpActive)
        {
            //set countdown timer in the heirarchy inspector. Countsdown every second.
            powerUpCountDown -= Time.deltaTime;

            //Picks up powerup, double points!
            if (doublePoints)
            {
                StartCoroutine("DisplayPowerUp");
                theScoreManager.pointsPerSecond = normalPointValue * 2;
                theScoreManager.doubleScore = true;
            }

            //Pick up magnet, coins come to player in certain distance. Perhaps an upgrade in the future?
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
            doublePointsText.SetActive(true);
            yield return new WaitForSeconds(3f);
            doublePointsText.SetActive(false);
        }

        if (coinMagnet)
        {
            coinMagnetText.SetActive(true);
            yield return new WaitForSeconds(3f);
            coinMagnetText.SetActive(false);
        }
    }
}
