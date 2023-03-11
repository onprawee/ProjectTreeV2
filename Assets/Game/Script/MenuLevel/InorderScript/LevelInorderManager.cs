using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelInorderManager : MonoBehaviour
{
    int inorderLevelUnlock;

    public Button[] levelButtons;
    public GameObject[] imageInorderLock;
    public GameObject[] textInorderLevel;


    void Start()
    {

        inorderLevelUnlock = PlayerPrefs.GetInt("LevelsUnlockInorder", 1) % 20;
        Debug.Log("LevelsUnlockInorder" + inorderLevelUnlock);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
            imageInorderLock[i].SetActive(true);
        }

        for (int i = 0; i < inorderLevelUnlock; i++)
        {
            levelButtons[i].interactable = true;
            imageInorderLock[i].SetActive(false);
            textInorderLevel[i].SetActive(true);
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
