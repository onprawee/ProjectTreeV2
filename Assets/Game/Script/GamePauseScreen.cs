using UnityEngine;
using UnityEngine.UI;

public class GamePauseScreen : MonoBehaviour
{
    public Button tutorialButton, questButton, exitButton, resumeButton;

    // public void PauseScreen(){
    //     gameObject.SetActive(true);
    // }
    public void PauseScreenActive()
    {
        gameObject.SetActive(true);
    }

    public void TutorialButton()
    {
        //Tutorial
        Debug.Log("Tutorial");
    }
    public void QuestButton()
    {
        //Quest
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
