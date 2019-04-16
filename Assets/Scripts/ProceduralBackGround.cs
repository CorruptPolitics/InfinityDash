using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]

public class ProceduralBackGround : MonoBehaviour
{
    //offset so no overlaps or errors.
    public int offsetX = 2;

    //2 bools to check if a background needs to be spawned.
    public bool rightBuddy = false;
    public bool leftBuddy = false;

    //If object is not tilable
    public bool reverseScale = false;

    //Width of the element in sprite array.
    private float spriteWidth = 0f;

    private Camera cam;
    private Transform myTransform;

    void Awake()
    {
        cam = Camera.main;
        myTransform = transform;
    }

    void Start()
    {
        SpriteRenderer theRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = theRenderer.sprite.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Checking to see if backgrounds are needed.
        if (leftBuddy == false || rightBuddy == false)
        {
            //Calculates new camera extend of what the camera can see.  Half the width.
            float cameraHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;
            //Calculate the x position where camera can see the edge of sprite background.
            float edgeVisableRight = (myTransform.position.x + spriteWidth / 2) - cameraHorizontalExtend;
            //Same for left
            float edgeVisableLeft = (myTransform.position.x - spriteWidth / 2) + cameraHorizontalExtend;

            //Checking if we can see the edge of background.  Call CreateNewBuddy if follows statement
            if (cam.transform.position.x >= edgeVisableRight - offsetX && rightBuddy == false)
            {
                CreateNewBuddy(1);
                rightBuddy = true;
            }
            else if (cam.transform.position.x <= edgeVisableLeft + offsetX && leftBuddy == false)
            {
                CreateNewBuddy(-1);
                leftBuddy = true;
            }
        }
    }

    //Function that creates background on the left or righ side.
    void CreateNewBuddy(int rightOrleft)
    {
        //Calculating the newPosition for the new Buddy.
        Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * rightOrleft, myTransform.position.y, myTransform.position.z);
        //Instantiating new buddy and stroing it in a transform variable.
        Transform newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;

        //If not tilable, reverse the x size of object to make it look nice.
        if (reverseScale == true)
        {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
        }

        newBuddy.parent = myTransform.parent;

        if (rightOrleft > 0)
        {
            newBuddy.GetComponent<ProceduralBackGround>().leftBuddy = true;
        }
        else
        {
            newBuddy.GetComponent<ProceduralBackGround>().rightBuddy = true;
        }
    }
}
