using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonMenuGame : MonoBehaviour
{
    public void ButtonMenuHome()
    {
        SceneManager.LoadScene("Menu_Home");
    }

    public void ButtonMenuPreorder()
    {
        SceneManager.LoadScene("PreorderLevel");
    }

    public void ButtonMenuPostorder()
    {
        SceneManager.LoadScene("PostorderLevel");
    }

    public void ButtonMenuInorder()
    {
        SceneManager.LoadScene("InorderLevel");
    }
}
