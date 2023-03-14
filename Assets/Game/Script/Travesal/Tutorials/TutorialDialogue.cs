using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialDialogue : MonoBehaviour
{
    public GameObject[] dialogueText;

    public Button nextButton, previousButton, closeButton;

    private int currentDialogue = 0;

    void Start()
    {
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
        AudioManager.instance.PlaySFX("Click");
    }

    public void PreviousDialogue()
    {
        dialogueText[currentDialogue].SetActive(false);
        currentDialogue--;
        dialogueText[currentDialogue].SetActive(true);
        AudioManager.instance.PlaySFX("Click");
    }

    public void CloseDialogue()
    {

        gameObject.SetActive(false);
        dialogueText[currentDialogue].SetActive(false);
        currentDialogue = 0;
        dialogueText[currentDialogue].SetActive(true);
        AudioManager.instance.PlaySFX("Click");

    }

    public void TutorialScene()
    {
        SceneManager.LoadScene("TutorialScene");
        AudioManager.instance.PlaySFX("Click");
    }
    public void Menu_Game()
    {
        SceneManager.LoadScene("Menu_Game");
        AudioManager.instance.PlaySFX("Click");
    }




}