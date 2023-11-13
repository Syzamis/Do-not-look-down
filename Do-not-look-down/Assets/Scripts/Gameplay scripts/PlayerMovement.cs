using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    
    [Header("Movespeed")]
    private float speed = 8f;
    
    [Header("Jumping Power")]    
    private float jumpingPower = 12f;

    [Header("Object References")]
    [SerializeField] private Rigidbody2D rigidBody;
    
    [Header("Grounded")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    [SerializeField]public float raycasterDistance;
    
    
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer);
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
        
        
        
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, transform.up, raycasterDistance, groundLayer);
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, -transform.up, raycasterDistance, groundLayer);


        if (hitUp.collider != null)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        if (hitDown.collider == null&&hitUp.collider== null)
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }

    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(horizontal*speed, rigidBody.velocity.y);
    }
}
