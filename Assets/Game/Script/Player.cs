using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float horizontalMove;
    private bool moveRight;
    private bool moveLeft;
    
    private Animator anim;
    private Vector3 localScale;
    private float jumpSpeed = 8f;
    bool isGrounded;
    bool canDoubleJump;
    public float delayBeforeDoubleJump;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning",false);
        anim.SetBool("isFalling",false);
        anim.SetBool("isJumping",false);
        moveLeft = false;
        moveRight = false;

        localScale = transform.localScale;
    }
    void Update(){
        Movement();
    }
    public void pointerDownLeft(){
        moveLeft = true;
        anim.SetBool("isRunning",true);
        localScale.x = Mathf.Abs(localScale.x) * -1 ;
        transform.localScale = localScale;
    }
    public void pointerUpLeft(){
        moveLeft = false;
        anim.SetBool("isRunning",false);
        //localScale.x *= -1; //หมุน
        //transform.localScale = localScale;
    }   
    public void pointerDownRight(){
        anim.SetBool("isRunning",true);
        localScale.x = Mathf.Abs(localScale.x);
        transform.localScale = localScale;
        moveRight = true;
    }
    public void pointerUpRight(){
        anim.SetBool("isRunning",false);
        moveRight = false;
    }
    public void pointerUpJump(){
       
        anim.SetBool("isFalling",true);
    }
    void Movement(){
        if(moveLeft){
            horizontalMove = -speed;
            
        }else if(moveRight){
            horizontalMove = speed;
        }else{
            horizontalMove = 0;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            canDoubleJump = false;
            anim.SetBool("isFalling",false);
            anim.SetBool("isJumping",false);
        }
    }
    public void jumpButton()
    {
        if(isGrounded)
        {
            isGrounded = false;
            rb.velocity = Vector2.up * jumpSpeed;
            Invoke("EnableDoubleJump", delayBeforeDoubleJump);
            anim.SetBool("isJumping",true);
        }
        if (canDoubleJump)
        {

            rb.velocity = Vector2.up * (jumpSpeed/2);
            canDoubleJump = false;
        }   
    }
    void EnableDoubleJump()
        {
            canDoubleJump = true;
        }
    private void FixedUpdate(){
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}
