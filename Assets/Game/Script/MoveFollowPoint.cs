using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFollowPoint : MonoBehaviour
{
    [SerializeField]
    Transform[] points;
    [SerializeField]
    float moveSpeed = 3f;
    int waypointsIndex = 0;

    public GameObject[] noColor;
    public GameObject[] addColor;

    private Animator anim;
    private Vector3 localScale;

    void Start()
    {
        transform.position = points[waypointsIndex].transform.position;
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning",false);
        localScale = transform.localScale;
        Debug.Log("Panpan");

    }

    void Update()
    {
        moveToNextNode();
        moveAnimation();
    }

    void moveToNextNode()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[waypointsIndex].transform.position, moveSpeed * Time.deltaTime);

        //Show And Hide 
        if (transform.position == points[waypointsIndex].transform.position)
        {
            noColor[waypointsIndex].SetActive(false);
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
    void moveAnimation()
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
        Debug.Log("Animation");
    }



}
