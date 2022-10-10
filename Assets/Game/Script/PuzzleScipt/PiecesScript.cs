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

    public GameObject ShowAddColor, PuzzleImg;

    // public SpriteRenderer spriteRenderer;
    public GameManager gameManager;

    void Start()
    {

        RightPosition = transform.position;
        //Random ตำแหน่งเกิดของจิ๊กซอว์
        transform.position = new Vector3(Random.Range(4f, 7f), Random.Range(1.3f, -2.3f));
        SetPuzzleImage();
        PuzzleImg.SetActive(false);
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
                        ShowAddColor.SetActive(true);
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

    private void SetPuzzleImage()
    {
        Debug.Log(gameManager.spriteRenderer.sprite.name);

        for (int i = 0; i < 15; i++)
        {
            GameObject.Find("Pieces " + i).transform.Find("puzzle").GetComponent<SpriteRenderer>().sprite = gameManager.spriteRenderer.sprite;

        }
    }

}
