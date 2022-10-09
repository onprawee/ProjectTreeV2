using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTrigger : MonoBehaviour
{

    void Start()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Mushroom"))
        {
            SceneManager.LoadScene("JigsawScene");
        }
    }
}
