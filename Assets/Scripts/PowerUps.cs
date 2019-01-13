﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    //List of powerups.  So far just double points
    public bool doublePoints;
    public bool coinMagnet;
    public float  powerUpTimer;

    private PowerUpManager thePowerUpManager;

    public Sprite[] powerUpIcons;
    private float xCollider = 1;
    private float yCollider = 1;

    // Start is called before the first frame update
    void Start()
    {
        thePowerUpManager = FindObjectOfType<PowerUpManager>();
    }

    void Awake()
    {
        int powerUpSelector = Random.Range(0, 2);

        switch (powerUpSelector)
        {
            case 0:
                gameObject.AddComponent<PolygonCollider2D>().isTrigger = true;
                doublePoints = true;
                break;

            case 1:
                gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(xCollider, yCollider);
                coinMagnet = true;
                break;
        }

        GetComponent<SpriteRenderer>().sprite = powerUpIcons[powerUpSelector];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            thePowerUpManager.ActivatePowerUp(doublePoints, coinMagnet, powerUpTimer);
        }
        gameObject.SetActive(false);
    }
}