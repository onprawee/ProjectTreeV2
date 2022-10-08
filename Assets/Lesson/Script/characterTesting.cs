using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterTesting : MonoBehaviour
{
    public Character Raelin;
    public Character Avira;
    // Start is called before the first frame update
    void Start()
    {
        // Raelin = CharacterManager.instance.GetCharacter("Raelin", enableCreatedCharacterOnStart: false);
        // Avira =
    }
    public string[] speech;
    int i =0;
    public Vector2 moveTarget;
    public float moveSpeed;
    public bool smooth;
    

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown (KeyCode.Space)){
        //     if(i < speech.Length)
        //         Raelin.Say (speech[i]);
        //     else
        //         DialogueSystem.instance.Close ();
        //     i++;
        // }
        // if(Input.GetKey (KeyCode.M)){
        //     Raelin.MoveTo (moveTarget, moveSpeed, smooth);
        // }
    }
}
