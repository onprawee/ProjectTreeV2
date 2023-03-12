using UnityEngine;
using UnityEngine.UI;

public class ExitDoor : MonoBehaviour
{

    public Button btnEnterDoor;

    void Start()
    {
        //btnEnterDoor = GameObject.Find("ButtonEnterDoor").GetComponent<Button>();
    }

    void Update()
    {

    }

    // สคริปต์นี้ถูกใช้กับ Object ประตู
    // OnTrigger จะเกิดก็ต่อเมื่อมีอะไรเข้ามาชนประตู
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ถ้า Object ที่มาชนประตู คือ Player
        // other is Player
        if (other.tag == "Player")
        {

            btnEnterDoor.gameObject.SetActive(true);

            btnEnterDoor.interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ถ้า Object ที่เดินออกจากประตู คือ Player
        if (other.tag == "Player")
        {
            btnEnterDoor.gameObject.SetActive(true);
        }
    }
}



