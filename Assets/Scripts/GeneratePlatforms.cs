﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatforms : MonoBehaviour {

    public GameObject platformToSpawn;
    public Transform generationPoint;

    private float distanceBetweenPlatforms;
    private float platformWidth;

    public ObjectPooling poolObject;

	// Use this for initialization
	void Start () {
        platformWidth = platformToSpawn.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetweenPlatforms = Random.Range(6.0f, 9.5f);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetweenPlatforms, transform.position.y + Random.Range(-1.0f, 1.0f), transform.position.z);
            //Instantiate(platformToSpawn, transform.position, transform.rotation);
            GameObject newPlatform = poolObject.GetPoolObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
        }
	}
}