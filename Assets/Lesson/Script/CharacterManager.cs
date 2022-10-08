using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Responsible for adding and maintaining characters in the scene.
public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;
    //All characters must be attached to the character panel.
    public RectTransform characterPanel;
    // A list of all characters currently in our scene.
    public List<Character> characters = new List<Character>();
    //Easy lookup for our characters.
    public Dictionary<string, int> characterDictionary = new Dictionary<string, int>();
    void Awake()
    {
        instance = this;
    }
    // Try to get a character by the name provided from the character list.
    public void GetCharacter(string characterName)
    {
        int index = -1;
        if(characterDictionary.TryGetValue (characterName, out index))
        {
         
        }

    }
}
