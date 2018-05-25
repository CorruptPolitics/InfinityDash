using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

    public PlayerMovement player;

    private Vector3 lastPlayerPosition;
    private float distancetoMove;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerMovement>();
        lastPlayerPosition = player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        //This adjusts the distance of the camera relative to the player.
        //Only messes with the x coordinates because player only goes left to right.
        //Will work with y coordinates if neccessary.

        distancetoMove = player.transform.position.x - lastPlayerPosition.x;
        transform.position = new Vector3(transform.position.x + distancetoMove, transform.position.y, transform.position.z);

        lastPlayerPosition = player.transform.position;
    }
}
