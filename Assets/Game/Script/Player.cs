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

    private Button btnRight, btnJump, btnLeft, btnClose, buttonClose, buttonOpen;
    private Animator anim;
    private Vector3 localScale;
    private float jumpSpeed = 7f;
    bool isGrounded, canDoubleJump;
    public float delayBeforeDoubleJump, verticalMove;

    //buttonNode
    public GameObject[] offLight, onLight;
    int nodeIndex = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", false);
        anim.SetBool("isFalling", false);
        anim.SetBool("isJumping", false);
        //anim.SetBool("isClimbing", false);
        moveLeft = false;
        moveRight = false;
        //isClimbing = false;

        localScale = transform.localScale;

        // btnClimb = GameObject.Find("ButtonClimb").GetComponent<Button>();
        btnLeft = GameObject.Find("ButtonLeft").GetComponent<Button>();
        btnRight = GameObject.Find("ButtonRight").GetComponent<Button>();
        btnJump = GameObject.Find("ButtonJump").GetComponent<Button>();

        buttonClose = GameObject.Find("ButtonClose").GetComponent<Button>();
        buttonOpen = GameObject.Find("ButtonOpen").GetComponent<Button>();

        buttonClose.gameObject.SetActive(false);
        buttonOpen.gameObject.SetActive(false);

        for (int i = 0; i < offLight.Length; i++)
        {

            offLight[i].SetActive(true);
            onLight[i].SetActive(false);
        }

        // btnClimb.gameObject.SetActive(false);

    }
    void Update()
    {
        Movement();

        // Ladder();
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
    // void Ladder()
    // {
    //     if (isClimbing)
    //     {
    //         verticalMove = speed;
    //     }
    //     else
    //     {
    //         verticalMove = 0;
    //     }
    // }
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


    public void pointerDownButtonOpen()
    {
        Debug.Log("you're press button idx" + nodeIndex);
        offLight[nodeIndex].SetActive(false);
        onLight[nodeIndex].SetActive(true);
        Debug.Log("Open Node" + nodeIndex);
    }

    public void pointerUpButtonOpen()
    {
        Debug.Log("On Light ");
    }

    public void pointerDownButtonClose()
    {
        offLight[nodeIndex].SetActive(true);
        onLight[nodeIndex].SetActive(false);
    }

    public void pointerUpButtonClose()
    {
        Debug.Log("Close Light");
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
        // if (isClimbing)
        // {
        //     rb.gravityScale = 0f;
        //     rb.velocity = new Vector2(rb.velocity.x, verticalMove);
        // }
        // else
        // {
        //     rb.gravityScale = 1f;
        // }
    }

    // public void ClosDialog()
    // {
    //     btnClose = GameObject.Find("BtnClose").GetComponent<Button>();
    //     Debug.Log("Close");

    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("you are in node button" + nodeIndex);
        if (collision.CompareTag("isOffLight"))
        {
            buttonOpen.gameObject.SetActive(true);
            buttonClose.gameObject.SetActive(false);
            nodeIndex = Array.FindIndex(offLight, x => x.gameObject.name == collision.gameObject.name);

        }
        else if (collision.CompareTag("isOnLight"))
        {
            buttonClose.gameObject.SetActive(true);
            nodeIndex = Array.FindIndex(onLight, x => x.gameObject.name == collision.gameObject.name);
        }
    }
}
