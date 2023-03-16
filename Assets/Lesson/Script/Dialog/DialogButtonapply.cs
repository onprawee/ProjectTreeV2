using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DialogButtonapply : MonoBehaviour
{
    public void buttonMenuLearn()
    {
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("Menu_Learn");
    }
    // Update is called once per frame
   public void buttonNextLevel()
    {
        AudioManager.instance.PlaySFX("Click");
       SceneManager.LoadScene("treedata");
        // SceneManager.LoadScene("บทถัดไป");
        Debug.Log("Next Level");
    }
}
