using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogButton : MonoBehaviour
{
    public void buttonMenuGame()
    {
        SceneManager.LoadScene("Menu_Game");
    }

    public void buttonTryAgain()
    {
        //Restart Scene
        new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void buttonNextLevel()
    {
        // SceneManager.LoadScene("PreorderLevel1");
        Debug.Log("Next Level");
    }

}
