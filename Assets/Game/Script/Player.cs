using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    private float horizontalMove;
    private bool moveRight;
    private bool moveLeft;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector3 localScale;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning",false);
        anim.SetBool("isFalling",false);
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
        // anim.SetBool("isFalling",false);
        localScale.x *= -1;
        transform.localScale = localScale;
        
    }
    public void pointerUpLeft(){
        moveLeft = false;
        anim.SetBool("isRunning",false);
        localScale.x *= -1;
        transform.localScale = localScale;
    }   
    public void pointerDownRight(){
        anim.SetBool("isRunning",true);
        moveRight = true;
    }
    public void pointerUpRight(){
        anim.SetBool("isRunning",false);
        moveRight = false;
    }

    void Movement(){
        if(moveLeft){
            horizontalMove = - speed;
            
        }else if(moveRight){
            horizontalMove = speed;
        }else{
            horizontalMove = 0;
        }
    }
    private void FixedUpdate(){
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }


}
