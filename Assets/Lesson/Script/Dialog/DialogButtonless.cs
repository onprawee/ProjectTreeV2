using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DialogButtonless : MonoBehaviour
{
    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private int scene;
    // Start is called before the first frame update
    public void buttonMenuLearn()
    {
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("Menu_Learn");
    }
    // Update is called once per frame
   public void buttonNextLevel()
    {
        AudioManager.instance.PlaySFX("Click");
       SceneManager.LoadScene(scene);
        // SceneManager.LoadScene("บทถัดไป");
        Debug.Log("Next Level");
    }
}
