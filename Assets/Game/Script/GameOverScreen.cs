using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text textStatus;

    public Button buttonRestart, buttonMenuUnlock, buttonnext, buttonMenu, buttonMenuLevel3;
    public GameObject iconwin, iconlose;

    public void Setup(string txtstatus)
    {
        gameObject.SetActive(true);
        textStatus.text = txtstatus.ToString();
    }

    public void RestartButton()
    {
        //Restart Scene
        AudioManager.instance.PlaySFX("Click");
        new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuGame()
    {
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("Menu_Game");
    }

    //Preorder
    public void nextLevelPreorder()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;


        if (currentLevel >= PlayerPrefs.GetInt("LevelsUnlockPreorder"))
        {
            PlayerPrefs.SetInt("LevelsUnlockPreorder", currentLevel + 1);
        }
        //Debug.Log("Level" + PlayerPrefs.GetInt("LevelsUnlockPreorder") + "Unlocked");
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene(currentLevel + 1);

    }
    public void MenuGameUnlockPreorder()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= PlayerPrefs.GetInt("LevelsUnlockPreorder"))
        {
            PlayerPrefs.SetInt("LevelsUnlockPreorder", currentLevel + 1);
        }
        //Debug.Log("Menu Level" + PlayerPrefs.GetInt("LevelsUnlockPreorder") + "Unlocked");
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("Menu_Game");

    }
    //Inorder
    public void nextLevelInorder()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("LevelsUnlockInorder"))
        {
            PlayerPrefs.SetInt("LevelsUnlockInorder", currentLevel + 1);
        }
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene(currentLevel + 1);
    }

    public void MenuGameUnlockInorder()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= PlayerPrefs.GetInt("LevelsUnlockInorder"))
        {
            PlayerPrefs.SetInt("LevelsUnlockInorder", currentLevel + 1);
        }
        //Debug.Log("Menu Level" + PlayerPrefs.GetInt("LevelsUnlockInorder") + "Unlocked");
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("Menu_Game");

    }

    //Postorder
    public void nextLevelPostorder()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("LevelsUnlockPostorder"))
        {
            PlayerPrefs.SetInt("LevelsUnlockPostorder", currentLevel + 1);
        }
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene(currentLevel + 1);
    }

    public void MenuGameUnlockPostorder()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= PlayerPrefs.GetInt("LevelsUnlockPostorder"))
        {
            PlayerPrefs.SetInt("LevelsUnlockPostorder", currentLevel + 1);
        }
        //Debug.Log("Menu Level" + PlayerPrefs.GetInt("LevelsUnlockPostorder") + "Unlocked");
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("Menu_Game");

    }



}
