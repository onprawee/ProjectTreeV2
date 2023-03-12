using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePauseScreen : MonoBehaviour
{
    public Button tutorialButton, questButton, exitButton, resumeButton;

    public GameStartScreen gameStartScreen;
    public TutorialDialogue tutorialDialogue;

    public void PauseScreenActive()
    {
        AudioManager.instance.PlaySFX("Click");
        gameObject.SetActive(true);

    }

    public void TutorialButton()
    {
        //Tutorial
        AudioManager.instance.PlaySFX("Click");
        tutorialDialogue.gameObject.SetActive(true);
        gameObject.SetActive(false);
        Debug.Log("Tutorial");
    }
    public void QuestButton()
    {
        //Quest
        AudioManager.instance.PlaySFX("Click");
        gameStartScreen.Setup();
        gameObject.SetActive(false);

        Debug.Log("Quest");
    }
    public void ExitButton()
    {
        //Exit
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("Menu_Game");
    }
    public void ResumeButton()
    {
        //Resume
        AudioManager.instance.PlaySFX("Click");
        Debug.Log("Resume");
        gameObject.SetActive(false);
    }
}
