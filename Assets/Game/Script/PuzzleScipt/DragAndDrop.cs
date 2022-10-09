using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DragAndDrop : MonoBehaviour
{
    public GameObject SelectPiece;
    int OIL = 1; //Order In Layer 

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Debug.Log(hit);
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<PiecesScript>().InRightPosition)
                {
                    //ถ้าไม่อยู่ในตำแหน่งที่ถูกต้องก็สามารถเคลื่อนไหวได้
                    SelectPiece = hit.transform.gameObject;
                    SelectPiece.GetComponent<PiecesScript>().Selected = true;
                    SelectPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;
                }

            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SelectPiece != null)
            {
                SelectPiece.GetComponent<PiecesScript>().Selected = false;
                SelectPiece = null;
            }
        }

        if (SelectPiece != null)
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectPiece.transform.position = new Vector3(mousePoint.x, mousePoint.y, 0);
        }
    }
}
