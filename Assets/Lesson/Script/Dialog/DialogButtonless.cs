using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogButtonless : MonoBehaviour
{
    // Start is called before the first frame update
    public void buttonMenuLearn()
    {
        SceneManager.LoadScene("Menu_Learn");
    }
    // Update is called once per frame
   public void buttonNextLevel()
    {
        // SceneManager.LoadScene("บทถัดไป");
        Debug.Log("Next Level");
    }
}
