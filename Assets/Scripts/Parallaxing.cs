using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour{ 

    //Array of all back and foregrounds to be parallaxed.
    public Transform[] backGrounds;
    //Array of all the back and foreground scales relative to camera movement.
    private float[] parallaxScale;
    //How smooth the parallaxing is.
    public float smoothing = 1f;
    //Reference to main camera.
    private Transform cam;
    //Store posisiton of camera in previous frame.
    private Vector3 previousCamPos;

    void Awake()
    {
        cam = Camera.main.transform; 
    }

    void Start()
    {
        //Previous frame had current frame's camera position.
        previousCamPos = cam.position;
        //Making sure parallax array is same size as backgrounds array.
        parallaxScale = new float[backGrounds.Length];
        //Assigning correct parallax scale to correct background.
        for (int i = 0; i < backGrounds.Length; i++)
        {
            parallaxScale[i] = backGrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Loop through each background.
        for (int i = 0; i < backGrounds.Length; i++)
        {
            //Difference between camera is from current frame from last frame.  Then it's applied to appropriate scale.
            float parallax = previousCamPos.x - cam.position.x * parallaxScale[i];
            //New x target position which is the current postiion plus the parallax.
            float backgroundTargetPosX = backGrounds[i].position.x + parallax;
            //Create target position which is current position with target x position.
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backGrounds[i].position.y, backGrounds[i].position.z);
            //Lerp between current position and the target position.
            backGrounds[i].position = Vector3.Lerp(backGrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        //Set previous camera's position to camera's position at end of frame.
        previousCamPos = cam.position;
    }
}
