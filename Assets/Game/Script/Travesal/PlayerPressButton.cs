using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPressButton : MonoBehaviour
{
    private Button buttonClose, buttonOpen;
    public GameObject[] button, pressedButton, lightOff, lightOn, imageOff, imageOn;
    int nodeIndex = 0;

    public List<String> orderedNode;

    public Text[] orderedNodeText;
    public String answer;

    //Key and Door
    public Transform keyFollowPoint;
    public Key[] followingKey;


    //Dialog Box
    public Button buttonMenuGame, buttonTryAgain, buttonNext;
    // private Text orderTitle, orderText;
    public Text textStatus;
    public GameObject dialogBox, ScreenBlur;


    void Start()
    {
        //Press&Close Button Light
        buttonClose = GameObject.Find("ButtonClose").GetComponent<Button>();
        buttonOpen = GameObject.Find("ButtonOpen").GetComponent<Button>();

        buttonClose.gameObject.SetActive(false);
        buttonOpen.gameObject.SetActive(false);

        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(true);
            pressedButton[i].SetActive(false);

            lightOff[i].SetActive(true);
            lightOn[i].SetActive(false);

            imageOff[i].SetActive(true);
            imageOn[i].SetActive(false);
        }

        orderedNode = new List<String>();


        // orderTitle = GameObject.Find("OrderTitle").GetComponent<Text>();
        // orderText = GameObject.Find("OrderText").GetComponent<Text>();

        buttonMenuGame.gameObject.SetActive(false);
        buttonTryAgain.gameObject.SetActive(false);
        buttonNext.gameObject.SetActive(false);
        // orderTitle.gameObject.SetActive(false);
        // orderText.gameObject.SetActive(false);

        dialogBox.SetActive(false);
        ScreenBlur.SetActive(false);


    }

    void Update()
    {
        for (int i = 0; i < pressedButton.Length; i++)
        {
            if (pressedButton[i].activeSelf)
            {
                lightOff[i].SetActive(false);
                lightOn[i].SetActive(true);

                imageOff[i].SetActive(false);
                imageOn[i].SetActive(true);
            }
            else
            {
                lightOff[i].SetActive(true);
                lightOn[i].SetActive(false);

                imageOff[i].SetActive(true);
                imageOn[i].SetActive(false);
            }
        }

        string result = String.Join("", orderedNode.ToArray());

        //เช็คว่าเดินทางครบทุกโหนดหรือยัง
        if (result.Length == answer.Length)
        {
            dialogBox.SetActive(true);
            ScreenBlur.SetActive(true);
            //Set Text
            // orderTitle.gameObject.SetActive(true);
            // orderText.gameObject.SetActive(true);
            // orderText.text = result;

            buttonMenuGame.gameObject.SetActive(true);
            if (result == answer)
            {

                textStatus.text = "ลำดับการเดินทางถูกต้อง";

                buttonNext.gameObject.SetActive(true);

            }
            else
            {
                textStatus.text = "ลำดับการเดินทางไม่ถูกต้อง";
                buttonTryAgain.gameObject.SetActive(true);


            }
        }
        else
        {
            textStatus.text = "";
        }
    }

    public void pointerDownButtonOpen()
    {
        //Debug.Log("you're press button idx" + nodeIndex);
        button[nodeIndex].SetActive(false);
        pressedButton[nodeIndex].SetActive(true);

        //เพิ่มตัวอักษรลงใน List
        string buttonName = pressedButton[nodeIndex].name;
        string lastChar = buttonName.Substring(buttonName.Length - 1);
        orderedNode.Add(lastChar);

        displayNode();
    }

    public void pointerDownButtonClose()
    {
        button[nodeIndex].SetActive(true);
        pressedButton[nodeIndex].SetActive(false);

        //ลบตัวอักษรออกจาก List
        string buttonName = pressedButton[nodeIndex].name;
        string lastChar = buttonName.Substring(buttonName.Length - 1);
        orderedNode.Remove(lastChar);

        displayNode();
    }

    public void displayNode()
    {
        //แสดงตัวอักษรใน List ลงใน Text
        for (int i = 0; i < orderedNodeText.Length; i++)
        {
            if (orderedNode.Count - 1 >= i && orderedNode[i] != null)
            {
                orderedNodeText[i].text = orderedNode[i];
            }
            else
            {
                orderedNodeText[i].text = "";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("you are in node button" + nodeIndex);
        if (collision.CompareTag("NotPress"))
        {
            buttonOpen.gameObject.SetActive(true);
            buttonClose.gameObject.SetActive(false);
            nodeIndex = Array.FindIndex(button, x => x.gameObject.name == collision.gameObject.name);

        }
        else if (collision.CompareTag("Pressed"))
        {
            buttonClose.gameObject.SetActive(true);
            nodeIndex = Array.FindIndex(pressedButton, x => x.gameObject.name == collision.gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonOpen.gameObject.SetActive(false);
        buttonClose.gameObject.SetActive(false);
    }
}
