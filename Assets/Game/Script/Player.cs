using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    public GameObject[] button, pressedButton, lightOff, lightOn;
    int nodeIndex = 0;

    public List<String> orderedNode;
    public Text textResult;
    public Text[] orderedNodeText;
    public String answer;

    //Key and Door
    public Transform keyFollowPoint;
    public Key followingKey;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", false);
        anim.SetBool("isFalling", false);
        anim.SetBool("isJumping", false);

        moveLeft = false;
        moveRight = false;

        localScale = transform.localScale;

        btnLeft = GameObject.Find("ButtonLeft").GetComponent<Button>();
        btnRight = GameObject.Find("ButtonRight").GetComponent<Button>();
        btnJump = GameObject.Find("ButtonJump").GetComponent<Button>();

        buttonClose = GameObject.Find("ButtonClose").GetComponent<Button>();
        buttonOpen = GameObject.Find("ButtonOpen").GetComponent<Button>();

        buttonClose.gameObject.SetActive(false);
        buttonOpen.gameObject.SetActive(false);

        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(true);
            pressedButton[i].SetActive(false);

            lightOff[i].SetActive(true);
            lightOn[i].SetActive(false);
        }

        orderedNode = new List<String>();
    }
    void Update()
    {
        Movement();


        for (int i = 0; i < pressedButton.Length; i++)
        {
            if (pressedButton[i].activeSelf)
            {
                lightOff[i].SetActive(false);
                lightOn[i].SetActive(true);
            }
            else
            {
                lightOff[i].SetActive(true);
                lightOn[i].SetActive(false);
            }
        }

        string result = String.Join("", orderedNode.ToArray());

        //เช็คว่าเดินทางครบทุกโหนดหรือยัง
        if (result.Length == answer.Length)
        {
            if (result == answer)
            {
                textResult.text = "YOU WIN";
                //Dialog
            }
            else
            {
                textResult.text = "YOU LOSE";
                //Restart Scene
                new WaitForSeconds(5);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            textResult.text = "";
        }
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
        button[nodeIndex].SetActive(false);
        pressedButton[nodeIndex].SetActive(true);

        //เพิ่มตัวอักษรลงใน List
        string buttonName = pressedButton[nodeIndex].name;
        string lastChar = buttonName.Substring(buttonName.Length - 1);
        orderedNode.Add(lastChar);

        displayNode();
    }

    public void pointerDownButtonClose()
    {
        button[nodeIndex].SetActive(true);
        pressedButton[nodeIndex].SetActive(false);

        //ลบตัวอักษรออกจาก List
        string buttonName = pressedButton[nodeIndex].name;
        string lastChar = buttonName.Substring(buttonName.Length - 1);
        orderedNode.Remove(lastChar);

        displayNode();
    }

    public void displayNode()
    {
        //แสดงตัวอักษรใน List ลงใน Text
        for (int i = 0; i < orderedNodeText.Length; i++)
        {
            if (orderedNode.Count - 1 >= i && orderedNode[i] != null)
            {
                orderedNodeText[i].text = orderedNode[i];
            }
            else
            {
                orderedNodeText[i].text = "";
            }
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("you are in node button" + nodeIndex);
        if (collision.CompareTag("NotPress"))
        {
            buttonOpen.gameObject.SetActive(true);
            buttonClose.gameObject.SetActive(false);
            nodeIndex = Array.FindIndex(button, x => x.gameObject.name == collision.gameObject.name);

        }
        else if (collision.CompareTag("Pressed"))
        {
            buttonClose.gameObject.SetActive(true);
            nodeIndex = Array.FindIndex(pressedButton, x => x.gameObject.name == collision.gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonOpen.gameObject.SetActive(false);
        buttonClose.gameObject.SetActive(false);
    }
}
