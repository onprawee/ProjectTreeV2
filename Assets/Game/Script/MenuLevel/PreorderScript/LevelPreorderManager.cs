using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelPreorderManager : MonoBehaviour
{
    int levelsUnlock;

    public Button[] levelButtons;
    void Start()
    {
        //ต้อง Mod ด้วยจำนวน ที่ได้ค่าระหว่าง 1 - 3 (ตาม จำนวนของปุ่มที่มีอยู่ในหน้าเลือก Level)
        //เช่น Level ที่ 1 ของ Preorder มี Index อยู่ที่ 15 => 15%14 = 1 

        //ต้องสร้างไฟล์แยกในแต่ละเรื่อง และตั้งชื่อ "LevelsUnlock" โดยระบุบ
        levelsUnlock = PlayerPrefs.GetInt("LevelsUnlockPreorder", 1) % 14;
        Debug.Log("LevelsUnlockPreorder" + levelsUnlock);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }

        for (int i = 0; i < levelsUnlock; i++)
        {
            levelButtons[i].interactable = true;

        }

    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }


}
