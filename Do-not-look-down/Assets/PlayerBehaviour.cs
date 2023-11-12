using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerBehaviour : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer);
    }

    private bool IsNearWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 1f, wallLayer);
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rigidBody.velocity.y>0f)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y*0.5f);
        }
    }

    private void FixedUpdate()
    {
        
        if (rigidBody.velocity.y < 0f && IsNearWall())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y * 0.5f);

        }

        if (!IsNearWall())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y * 2f);
        }
        
        rigidBody.velocity = new Vector2(horizontal*speed, rigidBody.velocity.y);
    }
}
