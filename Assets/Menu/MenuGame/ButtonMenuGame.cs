using UnityEngine;
using UnityEngine.SceneManagement;



public class ButtonMenuGame : MonoBehaviour
{
    public GameObject dialoguePage;
    void Start()
    {
        // PlayerPrefs.SetInt("cutSceneOpen", (cutSceneIsOpen) ? 1 : 0);

        if (PlayerPrefs.GetInt("menudialogue") == 0)
        {
            Debug.Log("menu dialogue");
            dialoguePage.SetActive(true);
        }
        else
        {
            dialoguePage.SetActive(false);
        }
    }
    public void ButtonMenuHome()
    {
        SceneManager.LoadScene("Menu_Home");
    }
    //Game Traversal 
    //Menu Game Traversal => Menu Subject Traversal => Menu_Level => Game Page
    public void Menu_Game()
    {
        SceneManager.LoadScene("Menu_Game");
        AudioManager.instance.PlaySFX("Click");
    }
    public void Menu_Decoration()
    {
        SceneManager.LoadScene("ChristmasTree");
        AudioManager.instance.PlaySFX("Click");
    }

    public void Subject_Traversal_Preorder()
    {
        SceneManager.LoadScene("PreorderLevel_Traversal");
        AudioManager.instance.PlaySFX("Click");
    }

    public void Subject_Traversal_Inorder()
    {
        SceneManager.LoadScene("InorderLevel_Traversal");
        AudioManager.instance.PlaySFX("Click");
    }

    public void Subject_Traversal_Postorder()
    {
        SceneManager.LoadScene("PostorderLevel_Traversal");
        AudioManager.instance.PlaySFX("Click");
    }

    public void closeMenuDialogue()
    {
        dialoguePage.SetActive(false);
        PlayerPrefs.SetInt("menudialogue", 1);
    }
}
