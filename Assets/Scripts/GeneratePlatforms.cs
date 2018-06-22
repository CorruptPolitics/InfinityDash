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
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetweenPlatforms, transform.position.y, transform.position.z);
            //Instantiate(platformToSpawn, transform.position, transform.rotation);

            GameObject newPlaform = poolObject.GetPoolObject();
            newPlaform.transform.position = transform.position;
            newPlaform.transform.rotation = transform.rotation;
            newPlaform.SetActive(true);
        }
	}
}
