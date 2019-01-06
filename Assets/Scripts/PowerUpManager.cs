using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    //Script checks which powerups to use and how much time is left.
    private bool doublePoints;
    private bool powerUpActive;
    private float powerUpCountDown;

    private ScoreManager theScoreManager;
    private float normalPointValue;

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
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
                theScoreManager.pointsPerSecond = normalPointValue * 2;
                theScoreManager.doubleScore = true;
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
    public void ActivatePowerUp(bool points, float timer)
    {
        doublePoints = points;
        powerUpActive = true;
        powerUpCountDown = timer;
        normalPointValue = theScoreManager.pointsPerSecond;
    }
}
