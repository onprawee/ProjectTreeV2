using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreenonTime : MonoBehaviour
{
    public float time;
    //public string sceneName;

    // Update is called once per frame
    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            SceneManager.LoadScene("Menu_Game");
        }
    }
}
