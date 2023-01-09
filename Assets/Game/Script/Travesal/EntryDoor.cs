using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EntryDoor : MonoBehaviour
{
    private Player thePlayer;

    public SpriteRenderer theSprite;

    public Sprite doorOpenSprite;

    public bool doorOpen, waitingToOpen;

    private GameObject currentTeleporter;

    private Button btnEnterDoor;


    void Start()
    {
        thePlayer = FindObjectOfType<Player>();

        btnEnterDoor = GameObject.Find("ButtonEnterDoor").GetComponent<Button>();
        btnEnterDoor.gameObject.SetActive(false);
    }

    void Update()
    {
        if (waitingToOpen)
        {
            if (Vector3.Distance(thePlayer.followingKey.transform.position, transform.position) < 0.1f)
            {
                waitingToOpen = false;

                doorOpen = true;

                theSprite.sprite = doorOpenSprite;

                thePlayer.followingKey.gameObject.SetActive(false);
                thePlayer.followingKey = null;

            }
        }
    }

    // สคริปต์นี้ถูกใช้กับ Object ประตู
    // OnTrigger จะเกิดก็ต่อเมื่อมีอะไรเข้ามาชนประตู
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ถ้า Object ที่มาชนประตู คือ Player
        // other is Player
        if (other.tag == "Player")
        {
            if (thePlayer.followingKey != null)
            {
                thePlayer.followingKey.followTarget = transform;
                waitingToOpen = true;
            }

            if (doorOpen)
            {
                btnEnterDoor.gameObject.SetActive(true);
            }
        }

    }
}



