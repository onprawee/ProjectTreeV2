using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public DialogueObject[] dialogueObjects;
}

[System.Serializable]
public class DialogueObject
{
    public string sentence;
    public GameObject nextObj;
}

