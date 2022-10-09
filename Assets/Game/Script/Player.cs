using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed; //Move Speed 
    private float horizontalMove;
    private bool moveRight, moveLeft;

    private Button btnClimb, btnRight, btnJump, btnLeft, btnClose;
    private Animator anim;
    private Vector3 localScale;
    private float jumpSpeed = 8f;
    bool isGrounded, canDoubleJump;
    public float delayBeforeDoubleJump, verticalMove;

    //Ladder 
    private bool isLadder, isClimbing;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", false);
        anim.SetBool("isFalling", false);
        anim.SetBool("isJumping", false);
        anim.SetBool("isClimbing", false);
        moveLeft = false;
        moveRight = false;
        isClimbing = false;

        localScale = transform.localScale;

        btnClimb = GameObject.Find("ButtonClimb").GetComponent<Button>();
        btnLeft = GameObject.Find("ButtonLeft").GetComponent<Button>();
        btnRight = GameObject.Find("ButtonRight").GetComponent<Button>();
        btnJump = GameObject.Find("ButtonJump").GetComponent<Button>();

        btnClimb.gameObject.SetActive(false);

    }
    void Update()
    {
        Movement();
        Ladder();
    }

    void Movement()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            horizontalMove = speed;
        }
        else
        {
            horizontalMove = 0;
        }
    }

    void Ladder()
    {
        if (isClimbing)
        {
            verticalMove = speed;
        }
        else
        {
            verticalMove = 0;
        }
    }

    public void pointerUpJump()
    {

        anim.SetBool("isFalling", true);
    }

    public void pointerDownLeft()
    {
        moveLeft = true;
        anim.SetBool("isRunning", true);
        localScale.x = Mathf.Abs(localScale.x) * -1;
        transform.localScale = localScale;
    }
    public void pointerUpLeft()
    {
        moveLeft = false;
        anim.SetBool("isRunning", false);

    }

    public void pointerDownRight()
    {
        anim.SetBool("isRunning", true);
        localScale.x = Mathf.Abs(localScale.x); //หมุนกลับ
        transform.localScale = localScale;
        moveRight = true;
    }
    public void pointerUpRight()
    {
        anim.SetBool("isRunning", false);
        moveRight = false;
    }

    public void pointerDownClimbUp()
    {
        //กดค้างเพื่อปีน
        if (isLadder)
        {
            anim.SetBool("isClimbing", true);
            isClimbing = true;
        }
        else
        {
            anim.SetBool("isClimbing", false);
            isClimbing = false;
        }

    }
    public void pointerUpClimbUp()
    {
        anim.SetBool("isClimbing", false);
        isClimbing = false;

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            canDoubleJump = false;
            anim.SetBool("isFalling", false);
            anim.SetBool("isJumping", false);
        }
    }
    public void jumpButton()
    {
        if (isGrounded)
        {
            isGrounded = false;
            rb.velocity = Vector2.up * jumpSpeed;
            Invoke("EnableDoubleJump", delayBeforeDoubleJump);
            anim.SetBool("isJumping", true);
        }
        if (canDoubleJump)
        {

            rb.velocity = Vector2.up * (jumpSpeed / 2);
            canDoubleJump = false;
        }
    }
    void EnableDoubleJump()
    {
        canDoubleJump = true;
    }

    private void FixedUpdate()
    {
        //Move
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
        //Climbing : Move
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, verticalMove);
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    public void ClosDialog()
    {
        btnClose = GameObject.Find("BtnClose").GetComponent<Button>();
        Debug.Log("Close");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            btnClimb.gameObject.SetActive(true);
        }
        // if (collision.CompareTag("Mushroom"))
        // {
        //     SceneManager.LoadScene("JigsawScene");
        // }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            anim.SetBool("isClimbing", false);
            isLadder = false;
            isClimbing = false;
            btnClimb.gameObject.SetActive(false);
        }
    }
}
