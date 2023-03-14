using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            Debug.Log("OnDrop");
            GameObject droppedItem = eventData.pointerDrag;
            DraggableItem draggableItem = droppedItem.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;

            if (CompareTag("DecorateBox"))
            {
                Debug.Log("Decorated");
                gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            }

            
        }




    }

}


