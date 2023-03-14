using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButton : MonoBehaviour
{
    public void ButtonBack()
    {
        SceneManager.LoadScene("Menu_Game");
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu_Home");
    }

    //Load Level Menu
    public void LoadLevelMenu()
    {

        SceneManager.LoadScene("Menu_Level");

    }

}
