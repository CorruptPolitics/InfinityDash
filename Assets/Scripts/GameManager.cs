using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //declares the platform generator object
    public Transform platformGenerator;
    //declares where the platform generator begins
    private Vector3 platformStartPoint;
    //declares the player as the PlayerMovement script
    public PlayerMovement thePlayer;
    //declares the point at which the player starts
    private Vector3 playerStartPoint;
	
    
    // Use this for initialization
	void Start () {
    //sets the platform start point to the original position of the platform generator game object
        platformStartPoint = platformGenerator.position;
    //sets the player start point to the original position of the player game object
        playerStartPoint = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
