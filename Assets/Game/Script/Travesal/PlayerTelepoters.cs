using UnityEngine;
using UnityEngine.UI;

public class PlayerTelepoters : MonoBehaviour
{
    private GameObject currentTeleporter;

    public Button btnEnterDoor;

    void Start()
    {

    }

    void Update()
    {

    }

    public void pointerDownEnterDoor()
    {
        if (currentTeleporter != null)
        {
            Teleporters teleporter = currentTeleporter.GetComponent<Teleporters>();
            transform.position = teleporter.GetDestination().position;

            //Debug.Log("Teleporting");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Teleporter tag is assign to EnrtryDoor & ExitDoor
        // ถ้า Player เดินไปชน Object ที่มี tag=Teleporter
        // other = Teleporter(ประตู)

        if (other.CompareTag("Teleporter"))
        {
            currentTeleporter = other.gameObject;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Teleporter"))
        {
            if (other.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }

        // btnEnterDoor.gameObject.SetActive(false);
    }
}