using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    //List of powerups.  So far just double points
    public bool doublePoints;
    public float  powerUpTimer;

    private PowerUpManager thePowerUpManager;

    // Start is called before the first frame update
    void Start()
    {
        thePowerUpManager = FindObjectOfType<PowerUpManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            thePowerUpManager.ActivatePowerUp(doublePoints, powerUpTimer);
        }
        gameObject.SetActive(false);
    }
}
