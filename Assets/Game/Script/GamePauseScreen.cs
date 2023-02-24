using UnityEngine;
using UnityEngine.UI;

public class GamePauseScreen : MonoBehaviour
{
    public Button tutorialButton, questButton, exitButton, resumeButton;

    public GameStarScreen gameStarScreen;
    public TutorialDialogue tutorialDialogue;

    public void PauseScreenActive()
    {
        gameObject.SetActive(true);
    }

    public void TutorialButton()
    {
        //Tutorial
        tutorialDialogue.gameObject.SetActive(true);
        gameObject.SetActive(false);
        Debug.Log("Tutorial");
    }
    public void QuestButton()
    {
        //Quest
        gameStarScreen.Setup();
        gameObject.SetActive(false);

        Debug.Log("Quest");
    }
    public void ExitButton()
    {
        //Exit
        Debug.Log("Exit");
    }
    public void ResumeButton()
    {
        //Resume
        Debug.Log("Resume");
        gameObject.SetActive(false);
    }
}
