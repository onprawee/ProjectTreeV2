using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFollowPoint : MonoBehaviour
{
    [SerializeField]
    Transform[] point;
    [SerializeField]
    float moveSpeed = 3f;
    int wayPointIndex = 0;

    public GameObject[] noColor;
    public GameObject[] addColor;

    void Start()
    {
        transform.position = point[wayPointIndex].transform.position;

    }

    void Update()
    {
        moveToNextNode();
        moveAnimation();
    }

    void moveToNextNode()
    {
        transform.position = Vector3.MoveTowards(transform.position, point[wayPointIndex].transform.position, moveSpeed * Time.deltaTime);

        //Show And Hide 
        if (transform.position == point[wayPointIndex].transform.position)
        {
            noColor[wayPointIndex].SetActive(false);
            addColor[wayPointIndex].SetActive(true);
        }
        if (transform.position == point[wayPointIndex].transform.position)
        {
            wayPointIndex += 1;
            Debug.Log(wayPointIndex);
        }

    }
    void moveAnimation()
    {
        Debug.Log("Animation");
    }



}
