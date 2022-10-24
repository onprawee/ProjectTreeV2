using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void ButtonMenu()
    {
        //SceneManager.LoadScene("");
        Debug.Log("Back to menu!");
    }
    public void ButtonNext()
    {
        //SceneManager.LoadScene("");
        Debug.Log("Next Game!");
    }
}
