﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

   [Header("Player Info.")]
    public float moveSpeed;
    public int power;
    public int coins;
    
    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;
    

    [Header("Jump Info.")]
    public bool grounded = false, springJump = false;
    public float jumpForce = 5, extraJumpsValue = 1, extraJumps;
    public float springJumpMultiplier;

    [Header("Move Info.")]
    private float moveInput;

    public Joystick joystick;
    public bool pcMode;

    [Header("Blink in damage")]
    public int blinkCount;
    public float blinkTimer, defBlinkTime;
    public SpriteRenderer spriteRenderer;

    [Header("Dialog Assistance")]
    public bool freeze;

    void Start(){

        coins = 0;
        blinkCount = 0;

        blinkTimer = -0.4f;
        defBlinkTime = 0.1f;
        jumpForce = 5f;
        extraJumpsValue = 1f;

        power = PlayerPrefs.GetInt("Collectables");
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        freeze = false;
    }

    void damageBlink(){

        // If time is positive, desable sprite. Otherwise, enable it.
        if(blinkCount != 0 && blinkTimer > 0.0f){
            spriteRenderer.enabled = false;            
        }else{
            spriteRenderer.enabled = true;
        }

        if(blinkTimer <= -defBlinkTime && blinkCount > 0){
            blinkTimer = defBlinkTime;
            blinkCount--;
        }
    }

    void Update(){
    
        damageBlink();
        blinkTimer -= Time.deltaTime;

        animator.SetBool("doubleJump", false);

        if(grounded){
            animator.SetBool("isGrounded", true);
            extraJumps = extraJumpsValue;
        }else{
            animator.SetBool("isGrounded", false);
        }

        if(springJump){
            rb.velocity = Vector2.up * jumpForce * springJumpMultiplier;  
            grounded = false;
            extraJumps = 0;
            springJump = false;
        }

        if(rb.velocity.y == 0){
            grounded = true;
        }

        //Animation
        animator.SetFloat("speed", rb.velocity.x * rb.velocity.x);
        if(rb.velocity.y > 0){
            animator.SetBool("goingUp", true);
        }else{
            animator.SetBool("goingUp", false);
        }

        if(rb.velocity.x >=0){
            animator.SetBool("goingRight", true);
        }else{
            animator.SetBool("goingRight", false);
        }
        jump();
    }
    void FixedUpdate(){
        moveHorizontal();   
    }

    void moveHorizontal(){
        if(pcMode){
            moveInput = Input.GetAxis("Horizontal");
        }else{ 
            if(joystick.Horizontal >= .2f){ // Controller sensitivity
                moveInput = 1f; 
            }else if(joystick.Horizontal <= -.2f){
                moveInput = -1f;
            }else{
                moveInput = 0f;
            }
        }
        float xAxisVelocity = freeze ? 0.0f : moveInput * moveSpeed;
        rb.velocity = new Vector2(xAxisVelocity, rb.velocity.y);
    }

    void jump(){
        if(pcMode){
            if(Input.GetKeyDown("space") && extraJumps>0){

                    animator.SetBool("doubleJump", true);

                    rb.velocity = Vector2.up * jumpForce;
                    extraJumps--;

            }else if(Input.GetKeyDown("space") && extraJumps==0 && grounded){
                    rb.velocity = Vector2.up * jumpForce;            
            }  
        }else{
            float verticalMove = joystick.Vertical;

            if(CrossPlatformInputManager.GetButtonDown("Jump") && extraJumps>0){
                    animator.SetBool("doubleJump", true);

                    rb.velocity = Vector2.up * jumpForce;
                    extraJumps--;

            }else if(CrossPlatformInputManager.GetButtonDown("Jump")  && extraJumps==0 && grounded){
                    rb.velocity = Vector2.up * jumpForce;            
            }  
        }
    }
}
