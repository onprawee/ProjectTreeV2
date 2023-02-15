using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPressButton : MonoBehaviour
{
    private Button buttonClose, buttonOpen;
    public GameObject[] button, pressedButton, lightOff, lightOn;
    int nodeIndex = 0;

    public List<String> orderedNode;

    public Text[] orderedNodeText;
    public String answer;

    //Key and Door
    public Transform keyFollowPoint;
    public Key[] followingKey;

    //GameOverScreen
    public GameOverScreen gameOverScreen;

    void Start()
    {
        //Press&Close Button Light
        buttonClose = GameObject.Find("ButtonClose").GetComponent<Button>();
        buttonOpen = GameObject.Find("ButtonOpen").GetComponent<Button>();

        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(true);
            pressedButton[i].SetActive(false);

            lightOff[i].SetActive(true);
            lightOn[i].SetActive(false);

        }

        orderedNode = new List<String>();

    }

    void Update()
    {

        for (int i = 0; i < pressedButton.Length; i++)
        {
            if (pressedButton[i].activeSelf)
            {
                lightOff[i].SetActive(false);
                lightOn[i].SetActive(true);
            }
            else
            {
                lightOff[i].SetActive(true);
                lightOn[i].SetActive(false);

            }
        }

        string result = String.Join("", orderedNode.ToArray());

        //เช็คว่าเดินทางครบทุกโหนดหรือยัง
        if (result.Length == answer.Length)
        {
            Debug.Log("You're complete the path");

            if (result == answer)
            {
                gameOverScreen.Setup("ลำดับการเดินทางถูกต้อง");
                gameOverScreen.buttonRestart.gameObject.SetActive(false);
                gameOverScreen.buttonMenu.gameObject.SetActive(true);
                gameOverScreen.buttonnext.gameObject.SetActive(true);
            }
            else
            {
                gameOverScreen.Setup("ลำดับการเดินทางไม่ถูกต้อง");
                gameOverScreen.buttonRestart.gameObject.SetActive(true);
                gameOverScreen.buttonMenu.gameObject.SetActive(true);
                gameOverScreen.buttonnext.gameObject.SetActive(false);
            }

        }
        else
        {
            Debug.Log("You're not complete the path");
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
        buttonOpen.gameObject.SetActive(true);
        buttonClose.gameObject.SetActive(true);
    }
}
