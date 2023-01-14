using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    // Queue : FIFO => First In Fist Out 
    private Queue<DialogueObject> dialogueObjects;

    //Class Dialog
    public Dialogue dialogue;

    //Type Effect delay
    public float delay = 0.1f;

    public GameObject previousDiplayedObj;

    void Start()
    {
        dialogueObjects = new Queue<DialogueObject>();

        //Show First text In Array 
        StartDialogue(dialogue);
    }
    private void StartDialogue(Dialogue dialogue)
    {
        dialogueObjects.Clear();
        //ข้อความอธิบายทั้งหมดถูกเก็บไว้ใน Array => public Dialogue dialogue;
        //ทำการ วน Loop เพื่อดึงข้อความอธิบายเข้ามาใส่ใน Queue ทีละตัว => private Queue<string> sentences;
        foreach (var obj in dialogue.dialogueObjects)
        {
            var dialogObj = new DialogueObject();
            dialogObj.sentence = obj.sentence;
            dialogObj.nextObj = obj.nextObj;

            dialogueObjects.Enqueue(dialogObj);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (previousDiplayedObj)
        {
            previousDiplayedObj.SetActive(false);
            previousDiplayedObj = null;
        }

        //ถ้าไม่มี ข้อความเหลืออยู่ในคิว : จะปิด Dialog 
        if (dialogueObjects.Count == 0)
        {
            return;
        }
        //กรณีที่มีข้อความเหลืออยู่ จะทำการดึงข้อความนั้นออกมาจากคิว  แล้วเอาไปใส่ในตัวแปร sentence 
        var obj = dialogueObjects.Dequeue();

        StopAllCoroutines(); //หยุดฟังก์ชันทั้งหมดที่ทำงานอยู่

        //เรียกใช้ฟังก์ชัน TypeSentence(sentence) ทำงาน 
        StartCoroutine(TypeSentence(obj));
        Debug.Log("Dequeue : ");
    }
    IEnumerator TypeSentence(DialogueObject obj)
    {
        //แสดงข้อความทีละตัวอักษร โดยสามารถระบุ Delay ได้ 
        dialogueText.text = "";
        var sentence = obj.sentence;
        var nextObj = obj.nextObj;

        var nextButton = GameObject.Find("NextText");
        nextButton.SetActive(false);
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(delay);
        }
        // ถ้า nextObj ไม่ใช่ null ให้แสดง nextObj ขึ้นมา
        if (nextObj != null)
        {
            nextObj.SetActive(true);
            previousDiplayedObj = nextObj;
        }

        nextButton.SetActive(true);
    }
}
