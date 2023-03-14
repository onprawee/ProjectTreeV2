using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;

    [HideInInspector] public InventorySlot inventorySlot;
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
        PlayerPrefs
        image.raycastTarget = true;
    }
}


