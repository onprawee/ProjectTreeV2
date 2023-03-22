using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public Dialogue dialogue;

    public Text textSentence;

    private int currentIndex = 0;
    public float delay = 0.1f;

    private int scene;

    public GameObject nextButton, previousButton;

    void Start()
    {
        StartDialogue();
        scene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void StartDialogue()
    {
        textSentence.text = "";
        currentIndex = 0;
        var dialogueObjects = dialogue.dialogueObjects[currentIndex];

        StopAllCoroutines();

        StartCoroutine(TypeSentence(dialogueObjects));

    }

    public void NextSentence()
    {
        AudioManager.instance.PlaySFX("Click");
        if (currentIndex == dialogue.dialogueObjects.Length - 1)
        {
            Debug.Log("i'm on the next level ");
            SceneManager.LoadScene(scene);
            return;
        }

        //ซ่อนรูปภาพที่กำลังแสดงอยู่
        var dialogueObjects = dialogue.dialogueObjects[currentIndex];


        for (int i = 0; i < dialogueObjects.preObject.Length; i++)
        {
            if (dialogueObjects.preObject[i].isForever == false)
            {
                dialogueObjects.preObject[i].gameObject.SetActive(false);
            }

        }
        for (int i = 0; i < dialogueObjects.postObject.Length; i++)
        {
            if (dialogueObjects.postObject[i].isForever == false)
            {
                dialogueObjects.postObject[i].gameObject.SetActive(false);
            }

        }

        Debug.Log(currentIndex);
        // อัปเดตจำนวน Index ของ Array 

        currentIndex++;

        dialogueObjects = dialogue.dialogueObjects[currentIndex];

        // เรียกใช้ Coroutine ในการแสดงข้อความ
        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogueObjects));

    }

    public void PreviousSentence()
    {
        AudioManager.instance.PlaySFX("Click");
        //ซ่อนรูปภาพที่กำลังแสดงอยู่
        var dialogueObjects = dialogue.dialogueObjects[currentIndex];
        for (int i = 0; i < dialogueObjects.preObject.Length; i++)
        {
            dialogueObjects.preObject[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < dialogueObjects.postObject.Length; i++)
        {
            dialogueObjects.postObject[i].gameObject.SetActive(false);
        }

        //อัปเดตจำนวน Index ของ Array 
        currentIndex--;

        dialogueObjects = dialogue.dialogueObjects[currentIndex];

        Debug.Log(currentIndex);

        //เรียกใช้ Coroutine ในการแสดงข้อความ
        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogueObjects));
    }

    IEnumerator TypeSentence(DialogueObject dialogueObject)
    {
        textSentence.text = "";

        var sentence = dialogueObject.sentence;
        var PreImage = dialogueObject.preObject;
        var PostImage = dialogueObject.postObject;

        previousButton.SetActive(false);
        nextButton.SetActive(false);

        if (PreImage != null)
        {
            foreach (var item in PreImage)
            {
                item.gameObject.SetActive(true);
            }
        }

        foreach (char letter in dialogueObject.sentence.ToCharArray())
        {
            textSentence.text += letter;
            yield return new WaitForSeconds(delay);

        }

        if (PostImage != null)
        {
            foreach (var item in PostImage)
            {
                item.gameObject.SetActive(true);
            }
        }

        nextButton.SetActive(true);

        if (currentIndex == 0)
        {
            previousButton.SetActive(false);
        }
        else
        {
            previousButton.SetActive(true);
        }
    }

}
