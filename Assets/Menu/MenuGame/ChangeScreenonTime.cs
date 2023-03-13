using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreenonTime : MonoBehaviour
{
    public float time;
    //public string sceneName;
    private void Update()
    {
        PlayerPrefs.SetInt("cutSceneOpen", 1);
        
        time -= Time.deltaTime;
        if (time <= 0)
        {
            SceneManager.LoadScene("Menu_Game");
        }
    }
}
