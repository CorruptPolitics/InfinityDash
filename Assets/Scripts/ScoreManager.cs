using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public Text highScoreText;
    public Text timerText;

    public bool isAlive;

    public float startTime;

    public float scoreCount;
    public float highScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    public bool doubleScore;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("Highscore");
        }
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            if (seconds.Length == 4)
            {
                timerText.text = minutes + ":" + "0" + seconds;
            }

            else
            {
                ChangeText(minutes, seconds);
            }

            if (scoreIncreasing)
            {
                scoreCount += pointsPerSecond * Time.deltaTime;
            }

            if (scoreCount > highScoreCount)
            {
                highScoreCount = scoreCount;
                PlayerPrefs.SetFloat("Highscore", highScoreCount);
            }

            scoreText.text = "Score: " + Mathf.Round(scoreCount);
            highScoreText.text = "Highscore: " + Mathf.Round(highScoreCount);
        }
    }

    //Quick function to chnage text
    void ChangeText(string minute, string second)
    {
        timerText.text = minute + ":" + second;
    }

    //Reset the timer
    public void ResetTimer()
    {
        startTime = Time.time;
    }

    //Function created for multiple ways to add score
    public void AddScore(int pointsToAdd)
    {
        if (doubleScore)
        {
            pointsToAdd *= 2;
        }
        scoreCount += pointsToAdd;
    }
}
