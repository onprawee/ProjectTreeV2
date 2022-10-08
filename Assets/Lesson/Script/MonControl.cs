using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class MonControl : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 3f;
    int waypointIndex = 0;

    public GameObject[] A; //node ที่ยังไม่ลงสี = Waypoint ใน Scence
    public GameObject[] nodecoler; //node ที่ลงสี 

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position,waypoints[waypointIndex].transform.position,
                                                 moveSpeed * Time.deltaTime);
        //เงื่อนไขการ ซ่อนและแสดง 
        if(transform.position == waypoints[waypointIndex].transform.position){
            A[waypointIndex].SetActive(false); 
            nodecoler[waypointIndex].SetActive(true);
        }
        // if(transform.position == waypoints[waypointIndex].transform.position){
        //     waypointIndex +=1;
        //     Debug.Log(waypointIndex);
        // }

        // if(waypointIndex==2){

        // }
        
        
        // if(waypointIndex == waypoints.Length){
        //     waypointIndex = 0;
        // }
    }
    public void Next(){
        if(transform.position == waypoints[waypointIndex].transform.position){
            waypointIndex +=1;
            Debug.Log(waypointIndex);
        }
    }
}
