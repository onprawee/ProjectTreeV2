using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonMenuGame : MonoBehaviour
{
    public void ButtonMenuHome()
    {
        SceneManager.LoadScene("Menu_Home");
    }
    //Game Jisaw
    //Menu Game Jisaw => Menu Subject Jisaw => Game Page
    public void GameJisaw()
    {
        SceneManager.LoadScene("Menu_subject_jisaw");
    }

    public void Subject_Jisaw_Preorder()
    {
        SceneManager.LoadScene("Preoder_jisaw");
    }

    public void Subject_Jisaw_Inorder()
    {
        // SceneManager.LoadScene("PreorderLevel");
    }

    public void Subject_Jisaw_Postorder()
    {
        // SceneManager.LoadScene("PreorderLevel");
    }

    //Game Traversal 
    //Menu Game Traversal => Menu Subject Traversal => Menu_Level => Game Page
    public void GameTraversal()
    {
        SceneManager.LoadScene("Menu_subject_travelsal");
    }
    public void Subject_Traversal_Preorder()
    {
        SceneManager.LoadScene("PreorderLevel_Traversal");
    }

    public void Subject_Traversal_Inorder()
    {
        // SceneManager.LoadScene("InorderLevel_Traversal");
    }

    public void Subject_Traversal_Postorder()
    {
        // SceneManager.LoadScene("PostorderLevel_Traversal");
    }
}
