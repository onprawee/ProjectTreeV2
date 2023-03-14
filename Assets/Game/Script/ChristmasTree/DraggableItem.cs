using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;

    [HideInInspector] public Transform parentAfterDrag;

    [HideInInspector] public InventorySlot inventorySlot;

    void Start()
    {
        Debug.Log("Hello" + transform.name);
        var parentName = PlayerPrefs.GetString(transform.name + ".parent");
        Debug.Log(parentName);

        var parent = GameObject.Find(parentName);

        if (parent)
        {
            Debug.Log("Hi" + transform.name);
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
}


