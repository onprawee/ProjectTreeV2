using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PiecesScript : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;

    public GameObject ShowUI;
    void Start()
    {

        RightPosition = transform.position;
        //Random ตำแหน่งเกิดของจิ๊กซอว์
        transform.position = new Vector3(Random.Range(4f, 8f), Random.Range(2.5f, -1.5f));
    }


    void Update()
    {
        //เมื่ออยู่ระหว่างตำแหน่งที่ถูกต้องจะ Fix ตำแหน่งไว้
        if (Vector3.Distance(transform.position, RightPosition) < 0.5f)
        {
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    transform.position = RightPosition;
                    InRightPosition = true;

                    GetComponent<SortingGroup>().sortingOrder = 0;
                    bool isAllRight = checkAllRightPosition(); //
                    if (isAllRight)
                    {
                        Debug.Log("Chip <3 PanPan");
                        ShowUI.SetActive(true);
                    }
                }
            }
        }
    }

    bool checkAllRightPosition()
    {
        for (int i = 0; i < 15; i++)
        {
            var pieceIsRight = GameObject.Find("Pieces " + i).transform.GetComponent<PiecesScript>().InRightPosition;
            if (!pieceIsRight)
            {
                return false;
            }
        }

        return true;
    }
}
