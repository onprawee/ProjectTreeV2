using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MoveFollowPoint : MonoBehaviour
{
    [SerializeField]
    Transform[] points, points2, points3;

    [SerializeField]
    float moveSpeed = 3f;
    int waypointsIndex = 0;

    public GameObject[] addColor, addColor2, addColor3;
    public GameObject[] textpoint4, textpoint6, textpoint8;
    public GameObject TextHeader;
    public GameManager gameManager;
    // public GameObject puzzleImage;
    public GameObject ShowDialog, TextNode4, TextNode6, TextNode8;

    private Animator anim;
    private Vector3 localScale;

    public Timer timer;

    void Start()
    {
        transform.position = points[waypointsIndex].transform.position;
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", false);
        localScale = transform.localScale;
    }

    void Update()
    {
        moveToNextNode();
        moveAnimation();
    }
    void moveToNextNode()
    {
        if (gameManager.spriteRenderer.sprite.name == "Node4_1")
        {
            transform.position = Vector3.MoveTowards(transform.position, points[waypointsIndex].transform.position, moveSpeed * Time.deltaTime);
            if (transform.position == points[waypointsIndex].transform.position)
            {
                addColor[waypointsIndex].SetActive(true);
                TextHeader.SetActive(true);
                textpoint4[waypointsIndex].SetActive(true); //show Text
                anim.SetBool("isRunning", false);
            }

            if (transform.position == points[waypointsIndex].transform.position)
            {
                if (points.Length - 1 == waypointsIndex)
                {
                    //Delay Show Dialog
                    var t = Task.Run(async delegate
                    {
                        await Task.Delay(1000);
                        return 42;
                    });
                    t.Wait();
                    ShowDialog.SetActive(true);
                    TextNode4.SetActive(true);
                    TextHeader.SetActive(false);
                    foreach (var textpoint in textpoint4)
                    {
                        textpoint.SetActive(false); //hide Text
                    }
                    return;
                }
                anim.SetBool("isRunning", true);
                waypointsIndex += 1;
                //Debug.Log(waypointsIndex);
            }
        }
        else if (gameManager.spriteRenderer.sprite.name == "Node6_1")
        {
            transform.position = Vector3.MoveTowards(transform.position, points2[waypointsIndex].transform.position, moveSpeed * Time.deltaTime);
            if (transform.position == points2[waypointsIndex].transform.position)
            {
                addColor2[waypointsIndex].SetActive(true);
                TextHeader.SetActive(true);
                textpoint6[waypointsIndex].SetActive(true); //show Text
                anim.SetBool("isRunning", false);
            }

            if (transform.position == points2[waypointsIndex].transform.position)
            {
                if (points2.Length - 1 == waypointsIndex)
                {
                    var t = Task.Run(async delegate
                    {
                        await Task.Delay(1000);
                        return 42;
                    });
                    t.Wait();
                    ShowDialog.SetActive(true);
                    TextNode6.SetActive(true);
                    TextHeader.SetActive(false);
                    foreach (var textpoint in textpoint6)
                    {
                        textpoint.SetActive(false); //hide Text
                    }
                    return;
                }
                anim.SetBool("isRunning", true);
                waypointsIndex += 1;
            }
        }
        else if (gameManager.spriteRenderer.sprite.name == "Node8_1")
        {
            transform.position = Vector3.MoveTowards(transform.position, points3[waypointsIndex].transform.position, moveSpeed * Time.deltaTime);
            if (transform.position == points3[waypointsIndex].transform.position)
            {
                addColor3[waypointsIndex].SetActive(true);
                TextHeader.SetActive(true);
                textpoint8[waypointsIndex].SetActive(true); //show Text
                anim.SetBool("isRunning", false);
            }

            if (transform.position == points3[waypointsIndex].transform.position)
            {
                if (points3.Length - 1 == waypointsIndex)
                {
                    var t = Task.Run(async delegate
                    {
                        await Task.Delay(1000);
                        return 42;
                    });
                    t.Wait();
                    ShowDialog.SetActive(true);
                    TextNode8.SetActive(true);
                    TextHeader.SetActive(false);
                    foreach (var textpoint in textpoint8)
                    {
                        textpoint.SetActive(false); //hide Text
                    }
                    return;
                }
                anim.SetBool("isRunning", true);
                waypointsIndex += 1;

            }
        }
    }
    void moveAnimation()
    {

        if (gameManager.spriteRenderer.sprite.name == "Node4_1")
        {
            if (transform.position.x >= points[waypointsIndex].transform.position.x)
            {
                localScale.x = Mathf.Abs(localScale.x) * -1;
                transform.localScale = localScale;
            }
            else if (transform.position.x <= points[waypointsIndex].transform.position.x)
            {
                localScale.x = Mathf.Abs(localScale.x);
                transform.localScale = localScale;
            }
        }
        else if (gameManager.spriteRenderer.sprite.name == "Node6_1")
        {
            if (transform.position.x >= points2[waypointsIndex].transform.position.x)
            {
                localScale.x = Mathf.Abs(localScale.x) * -1;
                transform.localScale = localScale;
            }
            else if (transform.position.x <= points2[waypointsIndex].transform.position.x)
            {
                localScale.x = Mathf.Abs(localScale.x);
                transform.localScale = localScale;
            }
        }
        else if (gameManager.spriteRenderer.sprite.name == "Node8_1")
        {
            if (transform.position.x >= points3[waypointsIndex].transform.position.x)
            {
                localScale.x = Mathf.Abs(localScale.x) * -1;
                transform.localScale = localScale;
            }
            else if (transform.position.x <= points3[waypointsIndex].transform.position.x)
            {
                localScale.x = Mathf.Abs(localScale.x);
                transform.localScale = localScale;
            }
        }
    }
}
