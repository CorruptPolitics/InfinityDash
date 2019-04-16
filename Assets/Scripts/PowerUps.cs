using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    //List of powerups.  So far just double points and magnet.
    public bool doublePoints;
    public bool coinMagnet;
    private float powerUpTimer;

    private PowerUpManager thePowerUpManager;

    public Sprite[] powerUpIcons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        thePowerUpManager = FindObjectOfType<PowerUpManager>();
        int powerUpSelector = Random.Range(0, 2);

        switch (powerUpSelector)
        {
            case 0:
                gameObject.AddComponent<PolygonCollider2D>().isTrigger = true;
                doublePoints = true;
                break;

            case 1:
                gameObject.AddComponent<PolygonCollider2D>().isTrigger = true;              
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
