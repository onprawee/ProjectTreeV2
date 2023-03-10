using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPostorderManager : MonoBehaviour
{
    int inorderLevelUnlock;

    public Button[] levelButtons;

    void Start()
    {

        inorderLevelUnlock = PlayerPrefs.GetInt("LevelsUnlockPostorder", 1) % 20;
        Debug.Log("LevelsUnlockPostorder" + inorderLevelUnlock);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }

        for (int i = 0; i < inorderLevelUnlock; i++)
        {
            levelButtons[i].interactable = true;
        }

    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void MenuHome()
    {
        SceneManager.LoadScene("Menu_Home");
    }
}
