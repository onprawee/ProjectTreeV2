using UnityEngine;
using UnityEngine.UI;

public class EntryDoor : MonoBehaviour
{
    private PlayerPressButton thePlayer;

    public SpriteRenderer theSprite;

    public Sprite doorOpenSprite;

    public bool doorOpen, waitingToOpen;

    private GameObject currentTeleporter;

    public Button btnEnterDoor;


    void Start()
    {
        thePlayer = FindObjectOfType<PlayerPressButton>();

        btnEnterDoor.interactable = false;

    }

    void Update()
    {
        if (waitingToOpen)
        {
            btnEnterDoor.interactable = true;

            for (int i = 0; i < thePlayer.followingKey.Length; i++)
            {
                if (thePlayer.followingKey[i] != null)
                {

                    if (Vector3.Distance(thePlayer.followingKey[i].transform.position, transform.position) < 0.1f)
                    {
                        waitingToOpen = false;

                        doorOpen = true;

                        theSprite.sprite = doorOpenSprite;

                        thePlayer.followingKey[i].gameObject.SetActive(false);
                        thePlayer.followingKey[i] = null;

                    }
                }
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
            for (int i = 0; i < thePlayer.followingKey.Length; i++)
            {
                if (thePlayer.followingKey[i] != null)
                {

                    thePlayer.followingKey[i].followTarget = transform;
                    waitingToOpen = true;
                    btnEnterDoor.interactable = true;
                }
            }

            if (doorOpen)
            {
                // btnEnterDoor.gameObject.SetActive(true);
                btnEnterDoor.interactable = true;
            }

        }

    }


}



