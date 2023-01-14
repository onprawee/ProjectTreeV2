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

    public CustomGameObject[] previousPreObj; // ใช้สำหรับเก็บรายการรูปภาพก่อนประโยคที่กำลังแสดงอยู่ เพื่อใช้สำหรับซ่อนรูปภาพเหล่านั้นในการกดปุ่ม Next ครั้งถัดไป

    public CustomGameObject[] previousPostObj; // ใช้สำหรับเก็บรายการรูปภาพหลังประโยคที่กำลังแสดงอยู่ เพื่อใช้สำหรับซ่อนรูปภาพเหล่านั้นในการกดปุ่ม Next ครั้งถัดไป

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
            dialogObj.preObject = obj.preObject;
            dialogObj.sentence = obj.sentence;
            dialogObj.postObject = obj.postObject;

            dialogueObjects.Enqueue(dialogObj);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        //ถ้าไม่มี ข้อความเหลืออยู่ในคิว : จะปิด Dialog 
        if (dialogueObjects.Count == 0)
        {
            return;
        }

        // ซ่อนรูปภาพก่อนประโยค ที่กำลังแสดงอยู่
        if (previousPreObj != null)
        {
            for (int i = 0; i < previousPreObj.Length; i++)
            {
                // ถ้ารูปภาพ ไม่ได้ตั้งค่า isForever = true ให้ซ่อนรูปภาพ
                if (!previousPreObj[i].isForever)
                {
                    previousPreObj[i].gameObject.SetActive(false); // ซ่อนรูป
                }
            }
            previousPreObj = null; // ล้างข้อมูลรูปภาพที่แสดงอยู่ก่อนหน้า
        }

        // ซ่อนรูปภาพหลังประโยค ที่กำลังแสดงอยู่
        if (previousPostObj != null)
        {
            for (int i = 0; i < previousPostObj.Length; i++)
            {
                // ถ้ารูปภาพ ไม่ได้ตั้งค่า isForever = true ให้ซ่อนรูปภาพ
                if (!previousPostObj[i].isForever)
                {
                    previousPostObj[i].gameObject.SetActive(false); // ซ่อนรูป
                }
            }
            previousPostObj = null; // ล้างข้อมูลรูปภาพที่แสดงอยู่ก่อนหน้า
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
        // ล้างข้อความก่อนหน้า
        dialogueText.text = "";

        // ดึงข้อมูลที่จะแสดงมาจาก obj
        var preObj = obj.preObject;
        var sentence = obj.sentence;
        var postObj = obj.postObject;

        // ซ่อนปุ่ม Next
        var nextButton = GameObject.Find("NextText");
        nextButton.SetActive(false);

        //แสดงรูปภาพ ก่อนประโยค
        if (preObj != null)
        {
            foreach (var pObj in preObj)
            {
                pObj.gameObject.SetActive(true); // แสดงรูปภาพ
            }
            previousPreObj = preObj; // เก็บ รูปภาพก่อนประโยคทั้งหมดของประโยคนี้ ไว้ในตัวแปรนี้ 
                                     // เพื่อที่จะใช้ในการซ่อนรูปภาพเหล่านี้ในอนาคต
        }

        // แสดงประโยค
        // ลูปเพื่อแสดงตัวอักษรของประโยคนี้ ทีละตัวอักษร
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(delay);
        }

        // แสดงรูปภาพ หลังประโยค
        if (postObj != null)
        {
            foreach (var objP in postObj)
            {
                objP.gameObject.SetActive(true); // แสดงรูปภาพ
            }
            previousPostObj = postObj; // เก็บ รูปภาพหลังประโยคทั้งหมดของประโยคนี้ ไว้ในตัวแปรนี้
                                       // เพื่อที่จะใช้ในการซ่อนรูปภาพเหล่านี้ในอนาคต
        }

        // แสดงปุ่ม Next
        nextButton.SetActive(true);
    }
}
