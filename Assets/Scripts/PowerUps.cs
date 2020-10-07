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

    public Sprite powerUpIcons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        thePowerUpManager = FindObjectOfType<PowerUpManager>();

        gameObject.AddComponent<PolygonCollider2D>().isTrigger = true;
        GetComponent<SpriteRenderer>().sprite = powerUpIcons;

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
