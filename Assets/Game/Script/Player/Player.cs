using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed; //Move Speed 
    private float horizontalMove;
    private bool moveRight, moveLeft;

    private Button btnRight, btnJump, btnLeft;
    private Animator anim;
    private Vector3 localScale;
    private float jumpSpeed = 7f;
    bool isGrounded, canDoubleJump;
    public float delayBeforeDoubleJump, verticalMove;

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

    }
    void Update()
    {
        Movement();


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

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision: " + other.gameObject.name);
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
}