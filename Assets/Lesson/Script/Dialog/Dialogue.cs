using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public DialogueObject[] dialogueObjects; // รูปภาพก่อน ข้อความ รูปภาพหลัง (หลายอัน)
}

[System.Serializable]
public class DialogueObject
{
    public CustomGameObject[] preObject; // Object/รูปภาพ ที่จะแสดงก่อนข้อความ (หลายอัน)
    public string sentence; // ข้อความ/ประโยค
    public CustomGameObject[] postObject; // Object/รูปภาพ ที่จะแสดงหลังข้อความ (หลายอัน)
}

// ไว้ใช้สำหรับเก็บ Object/รูปภาพ
[System.Serializable]
public class CustomGameObject
{
    public bool isForever; // รูปภาพจะอยู่ถาวร จนถึงประโยคสุดท้ายจบเลยไหม?
    public GameObject gameObject;
}

