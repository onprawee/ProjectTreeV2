using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void ButtonMenuHome()
    {
        SceneManager.LoadScene("Menu_Home");
    }
    public void ButtonMenuGame()
    {
        SceneManager.LoadScene("Menu_Game");
    }
    public void ButtonMenuLearning()
    {
        SceneManager.LoadScene("Menu_Learn");
    }

    public void ButtonExit()
    {
        Debug.Log("Exit !");
    }

    //Button Menu 
    //Preorder
    public void ButtonPreorderLesson()
    {
        SceneManager.LoadScene("SceneA");
    }

}

