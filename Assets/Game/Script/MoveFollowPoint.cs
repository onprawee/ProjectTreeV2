using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFollowPoint : MonoBehaviour
{
    [SerializeField]
    Transform[] points, points2, points3, points4;

    [SerializeField]
    float moveSpeed = 3f;
    int waypointsIndex = 0;

    public GameObject[] addColor, addColor2, addColor3, addColor4;
    public GameManager gameManager;
    // public GameObject puzzleImage;

    private Animator anim;
    private Vector3 localScale;

    void Start()
    {
        transform.position = points[waypointsIndex].transform.position;
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", false);
        localScale = transform.localScale;
        //Debug.Log("Panpan");
    }

    void Update()
    {
        moveToNextNode();
        moveAnimation();
        // moveTopoint();
    }
    void moveToNextNode()
    {


        if (gameManager.spriteRenderer.sprite.name == "puzzle1_white")
        {
            transform.position = Vector3.MoveTowards(transform.position, points[waypointsIndex].transform.position, moveSpeed * Time.deltaTime);
            // moveToNextNode();
            // Debug.Log("Image 1");
            if (transform.position == points[waypointsIndex].transform.position)
            {
                addColor[waypointsIndex].SetActive(true);
                anim.SetBool("isRunning", false);
            }

            if (transform.position == points[waypointsIndex].transform.position)
            {
                if (points.Length - 1 == waypointsIndex)
                {
                    Debug.Log("End");
                    return;
                }
                anim.SetBool("isRunning", true);
                waypointsIndex += 1;
                Debug.Log(waypointsIndex);
            }
        }
        else if (gameManager.spriteRenderer.sprite.name == "puzzle2_white")
        {
            transform.position = Vector3.MoveTowards(transform.position, points2[waypointsIndex].transform.position, moveSpeed * Time.deltaTime);
            if (transform.position == points2[waypointsIndex].transform.position)
            {
                addColor2[waypointsIndex].SetActive(true);
                anim.SetBool("isRunning", false);
            }

            if (transform.position == points2[waypointsIndex].transform.position)
            {
                if (points2.Length - 1 == waypointsIndex)
                {
                    Debug.Log("End");
                    return;
                }
                anim.SetBool("isRunning", true);
                waypointsIndex += 1;
                Debug.Log(waypointsIndex);
            }
        }
        else if (gameManager.spriteRenderer.sprite.name == "puzzle3_white")
        {
            transform.position = Vector3.MoveTowards(transform.position, points3[waypointsIndex].transform.position, moveSpeed * Time.deltaTime);
            if (transform.position == points3[waypointsIndex].transform.position)
            {
                addColor3[waypointsIndex].SetActive(true);
                anim.SetBool("isRunning", false);
            }

            if (transform.position == points3[waypointsIndex].transform.position)
            {
                if (points3.Length - 1 == waypointsIndex)
                {
                    return;
                }
                anim.SetBool("isRunning", true);
                waypointsIndex += 1;
                Debug.Log(waypointsIndex);
            }
        }
        else if (gameManager.spriteRenderer.sprite.name == "puzzle4_white")
        {
            transform.position = Vector3.MoveTowards(transform.position, points4[waypointsIndex].transform.position, moveSpeed * Time.deltaTime);
            if (transform.position == points4[waypointsIndex].transform.position)
            {
                addColor4[waypointsIndex].SetActive(true);
                anim.SetBool("isRunning", false);
            }

            if (transform.position == points4[waypointsIndex].transform.position)
            {
                if (points4.Length - 1 == waypointsIndex)
                {
                    Debug.Log("End");
                    return;
                }
                anim.SetBool("isRunning", true);
                waypointsIndex += 1;
                Debug.Log(waypointsIndex);
            }
        }
    }
    void moveAnimation()
    {

        if (gameManager.spriteRenderer.sprite.name == "puzzle1_white")
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
        else if (gameManager.spriteRenderer.sprite.name == "puzzle2_white")
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
        else if (gameManager.spriteRenderer.sprite.name == "puzzle3_white")
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
        else if (gameManager.spriteRenderer.sprite.name == "puzzle4_white")
        {
            if (transform.position.x >= points4[waypointsIndex].transform.position.x)
            {
                localScale.x = Mathf.Abs(localScale.x) * -1;
                transform.localScale = localScale;
            }
            else if (transform.position.x <= points4[waypointsIndex].transform.position.x)
            {
                localScale.x = Mathf.Abs(localScale.x);
                transform.localScale = localScale;
            }
        }
    }



}
