
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public GamePauseScreen gamePauseScreen;
    public GameStartScreen gameStartScreen;

    public TutorialGame tutorialGame;

    private Scene currentScene;

    //Scene Name
    private string PreorderLv1 = "PreOrderLevel1";
    private string InorderLv1 = "InorderLevel1";
    private string PostorderLv1 = "PostorderLevel1";


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", false);
        anim.SetBool("isFalling", false);
        anim.SetBool("isJumping", false);

        anim.SetBool("isHurt", false);

        moveLeft = false;
        moveRight = false;

        localScale = transform.localScale;

        btnLeft = GameObject.Find("ButtonLeft").GetComponent<Button>();
        btnRight = GameObject.Find("ButtonRight").GetComponent<Button>();
        btnJump = GameObject.Find("ButtonJump").GetComponent<Button>();


        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == PreorderLv1 || currentScene.name == InorderLv1 || currentScene.name == PostorderLv1 || currentScene.name == "TutorialScene")
        {
            tutorialGame.gameObject.SetActive(true);
            Debug.Log("Tutorial");
        }
        else
        {
            Debug.Log("Not Tutorial");
            tutorialGame.gameObject.SetActive(false);
            gameStartScreen.Setup();
        }



    }
    void Update()
    {
        Movement();

        onKeyDown();
    }

    void onKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            pointerDownLeft();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            pointerUpLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            pointerDownRight();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            pointerUpRight();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpButton();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            pointerUpJump();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePauseScreen.PauseScreenActive();
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

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            canDoubleJump = false;
            anim.SetBool("isFalling", false);
            anim.SetBool("isJumping", false);
            //anim.SetBool("isHurt", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trap")
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isHurt", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trap")
        {
            anim.SetBool("isHurt", false);
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
            AudioManager.instance.PlaySFX("Jump");

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
