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
        Debug.Log("Back to menu!");
    }
    public void ButtonMenuGame()
    {
        SceneManager.LoadScene("Menu_Game");
        Debug.Log("Menu Game!");
    }
    public void ButtonMenuLearning()
    {
        SceneManager.LoadScene("Menu_Learn");
        Debug.Log("Menu Learning!");
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
        Debug.Log("Preorder !");
    }

}

