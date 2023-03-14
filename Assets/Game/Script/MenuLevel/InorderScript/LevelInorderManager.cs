using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelInorderManager : MonoBehaviour
{
    int inorderLevelUnlock;

    public Button[] levelButtons;
    public GameObject[] imageInorderLock;
    public GameObject[] textInorderLevel;

    public GameObject rewardPanel;

    public Button reward;

    void Start()
    {
        inorderLevelUnlock = PlayerPrefs.GetInt("LevelsUnlockInorder", 1) % 8;
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
        if (PlayerPrefs.GetInt("inorderIsPass") == 0)
        {
            reward.interactable = false;
            PlayerPrefs.SetInt("rewardInorder", 0);
        }
        else
        {
            reward.interactable = true;

        }

    }
    void Update()
    {
        if (PlayerPrefs.GetInt("rewardInorder") == 1)
        {
            reward.interactable = false;
            Debug.Log("Reward is ready");
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

    public void OpenRewardPanel()
    {
        AudioManager.instance.PlaySFX("Click");
        Debug.Log("Get Reward");

        rewardPanel.SetActive(true);

    }

    public void GetReward()
    {
        PlayerPrefs.SetInt("rewardInorder", 1);
        AudioManager.instance.PlaySFX("Click");

        rewardPanel.SetActive(false);
    }

}
