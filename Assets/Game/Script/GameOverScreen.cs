using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text textStatus;

    public Button buttonRestart, buttonMenuUnlock, buttonnext, buttonMenu;

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

    //ปุ่ม Next Level 
    public void nextLevelPreorder()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;


        if (currentLevel >= PlayerPrefs.GetInt("LevelsUnlockPreorder"))
        {
            PlayerPrefs.SetInt("LevelsUnlockPreorder", currentLevel + 1);
        }
        Debug.Log("Level" + PlayerPrefs.GetInt("LevelsUnlockPreorder") + "Unlocked");
        SceneManager.LoadScene(currentLevel + 1);
    }
    public void MenuGameUnlockPreorder()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= PlayerPrefs.GetInt("LevelsUnlockPreorder"))
        {
            PlayerPrefs.SetInt("LevelsUnlockPreorder", currentLevel + 1);
        }
        Debug.Log("Menu Level" + PlayerPrefs.GetInt("LevelsUnlockPreorder") + "Unlocked");
        SceneManager.LoadScene("Menu_Game");
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("Menu_Game");
    }


}
