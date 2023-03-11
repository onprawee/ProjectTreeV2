using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPostorderManager : MonoBehaviour
{
    int inorderLevelUnlock;

    public Button[] levelButtons;
    public GameObject[] imagePostorderLock;
    public GameObject[] textPostorderLevel;


    void Start()
    {

        inorderLevelUnlock = PlayerPrefs.GetInt("LevelsUnlockPostorder", 1) % 24;
        Debug.Log("LevelsUnlockPostorder" + inorderLevelUnlock);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
            imagePostorderLock[i].SetActive(true);
        }

        for (int i = 0; i < inorderLevelUnlock; i++)
        {
            levelButtons[i].interactable = true;
            imagePostorderLock[i].SetActive(false);
            textPostorderLevel[i].SetActive(true);
        }

    }

    public void LoadLevel(int levelIndex)
    {
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene(levelIndex);
    }

    public void MenuHome()
    {
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("Menu_Home");
    }
}
