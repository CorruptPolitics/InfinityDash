using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;

    private Rigidbody2D playerRigidbody;

    private bool isGrounded;
    public LayerMask groundLayer;

    private Collider2D playerCollider;

	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.IsTouchingLayers(playerCollider, groundLayer);

        playerRigidbody.velocity = new Vector2(moveSpeed, playerRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeight);
        }
	}
}
