using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelPreorderManager : MonoBehaviour
{
    int levelsUnlock;

    public Button[] levelButtons;
    public GameObject[] imagePreorderLock;
    public GameObject[] textPreorderLevel;

    public Button reward;

    public GameObject rewardPanel;
    void Start()
    {
        //ต้อง Mod ด้วยจำนวน ที่ได้ค่าระหว่าง 1 - 3 (ตาม จำนวนของปุ่มที่มีอยู่ในหน้าเลือก Level)
        //เช่น Level ที่ 1 ของ Preorder มี Index อยู่ที่ 15 => 15%14 = 1 

        //ต้องสร้างไฟล์แยกในแต่ละเรื่อง และตั้งชื่อ "LevelsUnlock" โดยระบุบ
        levelsUnlock = PlayerPrefs.GetInt("LevelsUnlockPreorder", 1) % 4;
        Debug.Log("LevelsUnlockPreorder" + levelsUnlock);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
            imagePreorderLock[i].SetActive(true);
        }

        for (int i = 0; i < levelsUnlock; i++)
        {
            levelButtons[i].interactable = true;
            imagePreorderLock[i].SetActive(false);
            textPreorderLevel[i].SetActive(true);
        }

        if (PlayerPrefs.GetInt("preorderIsPass") == 0)
        {
            reward.interactable = false;
            PlayerPrefs.SetInt("rewardPreorder", 0);

        }
        else
        {
            PlayerPrefs.SetInt("rewardPreorder", 1);
            reward.interactable = true;
            Debug.Log("Reward is ready");
        }

    }
    void Update()
    {
        if (PlayerPrefs.GetInt("rewardPreorder") == 1)
        {
            //rewardPanel.SetActive(false);
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
        PlayerPrefs.SetInt("rewardPreorder", 1);

        rewardPanel.SetActive(false);
    }


}
