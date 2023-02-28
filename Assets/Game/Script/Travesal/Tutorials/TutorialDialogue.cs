using UnityEngine;
using UnityEngine.UI;

public class TutorialDialogue : MonoBehaviour
{
    public GameObject[] dialogueText;

    public Button nextButton, previousButton, closeButton;

    private int currentDialogue = 0;

    void Start()
    {
        Debug.Log(dialogueText.Length);

        currentDialogue = 0;
        dialogueText[currentDialogue].SetActive(true);

    }

    void Update()
    {
        if (currentDialogue == 0)
        {
            previousButton.gameObject.SetActive(false);
        }
        else
        {
            previousButton.gameObject.SetActive(true);
        }

        if (currentDialogue == dialogueText.Length - 1)
        {
            nextButton.gameObject.SetActive(false);
            closeButton.gameObject.SetActive(true);
        }
        else
        {
            nextButton.gameObject.SetActive(true);
            closeButton.gameObject.SetActive(false);
        }
    }

    public void NextDialogue()
    {
        dialogueText[currentDialogue].SetActive(false);
        currentDialogue++;
        dialogueText[currentDialogue].SetActive(true);
    }

    public void PreviousDialogue()
    {
        dialogueText[currentDialogue].SetActive(false);
        currentDialogue--;
        dialogueText[currentDialogue].SetActive(true);
    }

    public void CloseDialogue()
    {

        gameObject.SetActive(false);
        dialogueText[currentDialogue].SetActive(false);
        currentDialogue = 0;
        dialogueText[currentDialogue].SetActive(true);

    }




}