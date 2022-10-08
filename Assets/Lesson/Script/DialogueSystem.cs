using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Globalization;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textMeshPro;
    public static DialogueSystem instance;
    public ELEMENTS elements;

    void Awake(){
        instance = this;
    }
    
    void Start()
    {
      
    }
   //<summary>
        //Say something and show it on the speech box.
        //</summary>
    public void Say(string speech, string speaker ="")
    {
      StopSpeaking();
      StartCoroutine(Speaking(speech, speaker));
    }
    public void StopSpeaking()
    {
        if (isSpeaking)
      {
        StopCoroutine(speaking);
       
      }
       speaking = null;
    }
    public bool isSpeaking {get{return speaking != null;}}

    [HideInInspector] public bool isWaitingForUserInput = false;
    Coroutine speaking = null;
    IEnumerator Speaking(string targetSpeech, string speaker ="")
    {
        speechPanel.SetActive(true);
        speechText.text = "";
        speakerNameText.text = speaker; // temporary
        isWaitingForUserInput = false;

        while(speechText.text != targetSpeech)
        {
            speechText.text += targetSpeech[speechText.text.Length];
            yield return new WaitForEndOfFrame();
        }
        //text finished
        isWaitingForUserInput = true; 
        while(isWaitingForUserInput)
            yield return new WaitForEndOfFrame();
        StopSpeaking();
    }
    
    [System.Serializable]
    public class ELEMENTS{
        //<summary>
        //the main panel containing all dialogue related elements in the UI
        //</summary>
        public GameObject speechPanel;
        public TMP_Text speakerNameText;
        public TMP_Text speechText;
    }
    public GameObject speechPanel {get{return elements.speechPanel;}}
    public TMP_Text speakerNameText {get{return elements.speakerNameText;}}
    public TMP_Text speechText {get{return elements.speechText;}}
}
