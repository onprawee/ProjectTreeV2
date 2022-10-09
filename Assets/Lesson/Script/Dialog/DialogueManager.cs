using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    // Queue : FIFO => First In Fist Out 
    private Queue<string> sentences;

    //Class Dialog
    public Dialogue dialogue;

    //Type Effect delay
    public float delay = 0.1f;

    void Start()
    {
        sentences = new Queue<string>();

        //Show First text In Array 
        StartDialogue(dialogue);
    }
    private void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        //ข้อความอธิบายทั้งหมดถูกเก็บไว้ใน Array => public Dialogue dialogue;
        //ทำการ วน Loop เพื่อดึงข้อความอธิบายเข้ามาใส่ใน Queue ทีละตัว => private Queue<string> sentences;
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        //ถ้าไม่มี ข้อความเหลืออยู่ในคิว : จะปิด Dialog 
        if (sentences.Count == 0)
        {
            return;
        }
        //กรณีที่มีข้อความเหลืออยู่ จะทำการดึงข้อความนั้นออกมาจากคิว  แล้วเอาไปใส่ในตัวแปร sentence 
        string sentence = sentences.Dequeue();

        StopAllCoroutines(); //หยุดฟังก์ชันทั้งหมดที่ทำงานอยู่ 
        //เรียกใช้ฟังก์ชัน TypeSentence(sentence) ทำงาน 
        StartCoroutine(TypeSentence(sentence));
        Debug.Log("Dequeue : ");
    }
    IEnumerator TypeSentence(string sentence)
    {
        //แสดงข้อความทีละตัวอักษร โดยสามารถระบุ Delay ได้ 
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(delay);
        }
    }

}
