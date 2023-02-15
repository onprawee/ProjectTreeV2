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

    void RestartButton()
    {
        //Restart Scene
        new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //ปุ่ม Next Level 
    void nextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;


        if (currentLevel >= PlayerPrefs.GetInt("LevelsUnlockPreorder"))
        {
            PlayerPrefs.SetInt("LevelsUnlockPreorder", currentLevel + 1);
        }

        Debug.Log("Level" + PlayerPrefs.GetInt("LevelsUnlockPreorder") + "Unlocked");
    }
    void MenuGame()
    {
        SceneManager.LoadScene("Menu_Game");
    }
}
