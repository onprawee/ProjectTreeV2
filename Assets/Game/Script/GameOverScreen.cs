using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text textStatus;

    public Button buttonRestart, buttonMenu, buttonnext;

    public void Setup(string txtstatus)
    {
        gameObject.SetActive(true);
        textStatus.text = txtstatus.ToString();

    }

    public void RestartButton()
    {
        //Restart Scene
        new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevel()
    {
        // SceneManager.LoadScene("PreorderLevel1");
        Debug.Log("Next Level");
    }
    public void MenuGame()
    {
        SceneManager.LoadScene("Menu_Game");
    }
}
