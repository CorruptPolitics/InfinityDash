using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    public float jumpTime;
    private float jumpCounterTime;

    private Rigidbody2D playerRigidbody;

    private bool isGrounded;
    public LayerMask groundLayer;

    private Collider2D playerCollider;

    private Animator playerAnimation;

	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerAnimation = GetComponent<Animator>();
        jumpCounterTime = jumpTime;
	}
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.IsTouchingLayers(playerCollider, groundLayer);

        playerRigidbody.velocity = new Vector2(moveSpeed, playerRigidbody.velocity.y);

        //Checks player to be on ground to jump again
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeight);
            }
        }

        //Depending on how hard the jump is pressed, the player will jump to that response.
        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpCounterTime > 0)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeight);
                jumpCounterTime -= Time.deltaTime;
            }
        }

        //Prevents player to keep jumping in the air
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpCounterTime = 0;
        }

        //Resets JumpTime
        if (isGrounded)
        {
            jumpCounterTime = jumpTime;
        }

        playerAnimation.SetFloat("Speed", playerRigidbody.velocity.x);
        playerAnimation.SetBool("Grounded", isGrounded);
	}
}
