﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public int coinScore;
    public bool isCoin;
    public int pointPickup50;
    public bool is50Points;
    public bool isDiamond;

    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isCoin == true)
        {
            scoreManager.AddScore(coinScore);
            gameObject.SetActive(false);
        }

        if (is50Points == true)
        {
            scoreManager.AddScore(pointPickup50);
            gameObject.SetActive(false);
        }

        if (isDiamond == true)
        {
            scoreManager.gemCount++;
            scoreManager.gemPickedUp = true;
            PlayerPrefs.SetInt("Gems", scoreManager.gemCount);
            gameObject.SetActive(false);
        }
    }
}
