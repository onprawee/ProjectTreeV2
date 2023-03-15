using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;

    [HideInInspector] public Transform parentAfterDrag;

    [HideInInspector] public InventorySlot inventorySlot;

    public Sprite[] sprites;
    private float speed = 0.3f;

    void Start()
    {
        checkStatus();

        var parentName = PlayerPrefs.GetString(transform.name + ".parent");
        Debug.Log(parentName);

        var parent = GameObject.Find(parentName);

        if (parent)
        {
            parentAfterDrag = parent.transform;
            transform.SetParent(parent.transform);
            transform.SetAsLastSibling();
            image.raycastTarget = true;

            if (parent.CompareTag("DecorateBox"))
            {
                inventorySlot = parent.GetComponent<InventorySlot>();
                inventorySlot.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;

        AudioManager.instance.PlaySFX("Click");
        if (parentAfterDrag.CompareTag("DecorateBox"))
        {
            inventorySlot = parentAfterDrag.GetComponent<InventorySlot>();
            inventorySlot.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

    public void checkStatus()
    {
        image.gameObject.SetActive(false);
        if (image.name == "image1")
        {
            if (PlayerPrefs.GetInt("rewardPreorder") == 1)
            {
                image.gameObject.SetActive(true);
                Debug.Log("image1");
                StartCoroutine(Animate());
            }

        }
        else if (image.name == "image2")
        {
            if (PlayerPrefs.GetInt("rewardInorder") == 1)
            {
                image.gameObject.SetActive(true);
                StartCoroutine(Animate());
            }
        }
        else if (image.name == "image3")
        {
            if (PlayerPrefs.GetInt("rewardPostorder") == 1)
            {
                image.gameObject.SetActive(true);
                StartCoroutine(Animate());
            }
        }
    }
    IEnumerator Animate()
    {
        while (true)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                image.sprite = sprites[i];
                yield return new WaitForSeconds(speed);
            }
        }
    }
}


