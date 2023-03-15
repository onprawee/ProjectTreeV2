using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    bool cutSceneIsOpen;
    public void ButtonMenuHome()
    {
        SceneManager.LoadScene("Menu_Home");
    }
    public void ButtonMenuGame()
    {
        // PlayerPrefs.SetInt("cutSceneOpen", (cutSceneIsOpen) ? 1 : 0);

        if (PlayerPrefs.GetInt("cutSceneOpen") == 0)
        {
            Debug.Log("CutScene");
            SceneManager.LoadScene("CutScene");
        }
        else
        {
            SceneManager.LoadScene("Menu_Game");
        }
    }
    public void ButtonMenuLearning()
    {
        SceneManager.LoadScene("Menu_Learn");

    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    //Button Menu 
    //Preorder
    public void ButtonPreorderLesson()
    {
        SceneManager.LoadScene("SceneA");
    }

}

