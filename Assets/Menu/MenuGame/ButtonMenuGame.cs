using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonMenuGame : MonoBehaviour
{
    public void ButtonMenuHome()
    {
        SceneManager.LoadScene("Menu_Home");
    }
    //Game Traversal 
    //Menu Game Traversal => Menu Subject Traversal => Menu_Level => Game Page

    public void Menu_Decoration()
    {
        SceneManager.LoadScene("ChristmasTree");
    }

    public void Subject_Traversal_Preorder()
    {
        SceneManager.LoadScene("PreorderLevel_Traversal");
    }

    public void Subject_Traversal_Inorder()
    {
        SceneManager.LoadScene("InorderLevel_Traversal");
    }

    public void Subject_Traversal_Postorder()
    {
        SceneManager.LoadScene("PostorderLevel_Traversal");
    }
}
