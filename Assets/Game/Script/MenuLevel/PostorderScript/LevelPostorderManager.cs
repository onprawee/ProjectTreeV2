using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPostorderManager : MonoBehaviour
{
    int inorderLevelUnlock;

    public Button[] levelButtons;
    public GameObject[] imagePostorderLock;
    public GameObject[] textPostorderLevel;

    public Button reward;
    public GameObject rewardPanel;


    void Start()
    {
        inorderLevelUnlock = PlayerPrefs.GetInt("LevelsUnlockPostorder", 1) % 12;
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

        if (PlayerPrefs.GetInt("postorderIsPass") == 0)
        {
            reward.interactable = false;
            PlayerPrefs.SetInt("rewardPostorder", 0);
        }
        else
        {
            reward.interactable = true;
        }

    }

    void Update()
    {
        if (PlayerPrefs.GetInt("rewardPostorder") == 1)
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
        PlayerPrefs.SetInt("rewardPorstorder", 1);

        rewardPanel.SetActive(false);
    }
}
