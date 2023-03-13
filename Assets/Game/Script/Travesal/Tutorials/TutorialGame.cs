using UnityEngine;
using UnityEngine.UI;

public class TutorialGame : MonoBehaviour
{
    public GameObject[] tutorialDialogue;

    private int currentDialogue = 0;

    public Button nextButton, skipButton, closeButton;

    public GameStartScreen gameStartScreen;

    void Start()
    {
        currentDialogue = 0;
        tutorialDialogue[currentDialogue].SetActive(true);
    }

    void Update()
    {
        if (currentDialogue == 0)
        {
            skipButton.gameObject.SetActive(true);
        }
        else
        {
            skipButton.gameObject.SetActive(false);
        }

        if (currentDialogue == tutorialDialogue.Length - 1)
        {
            nextButton.gameObject.SetActive(false);
            closeButton.gameObject.SetActive(true);
            skipButton.gameObject.SetActive(false);
        }
        else
        {
            nextButton.gameObject.SetActive(true);
            closeButton.gameObject.SetActive(false);
        }
    }

    public void NextDialogue()
    {
        tutorialDialogue[currentDialogue].SetActive(false);
        currentDialogue++;
        tutorialDialogue[currentDialogue].SetActive(true);
    }
    public void SkipDialogue()
    {
        gameObject.SetActive(false);
        tutorialDialogue[currentDialogue].SetActive(false);
        gameStartScreen.Setup();
    }

    public void CloseDialogue()
    {
        gameObject.SetActive(false);
        tutorialDialogue[currentDialogue].SetActive(false);
        gameStartScreen.Setup();
    }


}
