using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatforms : MonoBehaviour {

    // Platform objects and generation
    public GameObject platformToSpawn;
    public Transform generationPoint;
    public ObjectPooling[] poolObjects;

    //Platform Selection
    private int selectPlatform;
    private float[] platformWidths;

    //Distance Between Each Platform
    private float distanceBetweenPlatforms;
    private float platformWidth;

    //Platform Heights 
    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightDifference;
    private float heightChange;

    private PointGeneration coinGen;
    public float randomCoinPercentage;

    //These variables control powerups and when and where they spawn.
    public float powerUpHeight;
    public ObjectPooling powerUpPool;
    public float powerUpPercentage;

    //public GameObject[] platformsToSpawn;


    // Use this for initialization
    void Start () {
        //platformWidth = platformToSpawn.GetComponent<BoxCollider2D>().size.x;

        platformWidths = new float[poolObjects.Length];

        for (int i = 0; i < poolObjects.Length; i++)
        {
            platformWidths[i] = poolObjects[i].poolObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        coinGen = FindObjectOfType<PointGeneration>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetweenPlatforms = Random.Range(6.0f, 10.0f);
            selectPlatform = Random.Range(0, poolObjects.Length);
            heightChange = transform.position.y + Random.Range(maxHeightDifference, -maxHeightDifference);

            //These statements check height on platfomrs to not spawn out of camera's view.
            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            if (Random.Range(0f, 100f) < powerUpPercentage)
            {
                GameObject newPowerUp = powerUpPool.GetPoolObject();
                newPowerUp.transform.position = transform.position + new Vector3(distanceBetweenPlatforms / 2f, Random.Range(powerUpHeight / 2, powerUpHeight), 0f);
                newPowerUp.SetActive(true);
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[selectPlatform] / 2) + distanceBetweenPlatforms, heightChange, transform.position.z);

            //Instantiate(/*platformToSpawn*/ platformsToSpawn[selectPlatform], transform.position, transform.rotation);
            GameObject newPlaform = poolObjects[selectPlatform].GetPoolObject();
            newPlaform.transform.position = transform.position;
            newPlaform.transform.rotation = transform.rotation;
            newPlaform.SetActive(true);

            if (Random.Range(0f, 100f) < randomCoinPercentage)
            {
                coinGen.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[selectPlatform] / 2), transform.position.y, transform.position.z);

        }
    }
}
