using UnityEngine;
using UnityEngine.UI;

public class GameStarScreen : MonoBehaviour
{

    public Button buttonStart;

    public void Setup()
    {
        gameObject.SetActive(true);
    }


    public void buttonStartGame()
    {
        // new WaitForSeconds(5);
        gameObject.SetActive(false);
        AudioManager.instance.PlaySFX("Click");
        Debug.Log("Start");
    }


}
