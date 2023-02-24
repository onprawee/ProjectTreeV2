using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testanime : MonoBehaviour
{
     [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 3f;
    int waypointIndex = 0;

    //Animation
    private Animator anim;
    private Vector3 localScale;

     public GameObject[] A; //node ที่ยังไม่ลงสี = Waypoint ใน Scence
    public GameObject[] nodecoler; //node ที่ลงสี 

    // Start is called before the first frame update
    void Start()
    {
         anim = GetComponent<Animator>();
        anim.SetBool("isRunning", false);
        transform.position = waypoints[waypointIndex].transform.position;
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        MovePosition();
    }
    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position,
                                                 moveSpeed * Time.deltaTime);
        //เงื่อนไขการ ซ่อนและแสดง 
        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            A[waypointIndex].SetActive(false);
            nodecoler[waypointIndex].SetActive(true);

            anim.SetBool("isRunning", false);
        }    
        
    }
    void MovePosition()
    {
        if (transform.position.x >= waypoints[waypointIndex].transform.position.x)
        {
            localScale.x = Mathf.Abs(localScale.x) * -1; //*-1 ทำให้หันซ้าย
            transform.localScale = localScale;
        }
        else if (transform.position.x <= waypoints[waypointIndex].transform.position.x)
        {
            localScale.x = Mathf.Abs(localScale.x); //หมุนกลับ 
            transform.localScale = localScale;
        }
    }
}