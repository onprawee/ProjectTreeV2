using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelButtonHandler : MonoBehaviour
{
    public void ButtonMenuHome()
    {
        SceneManager.LoadScene("Menu_Home");
    }
    //Preorder
    public void PreorderLevel1()
    {
        SceneManager.LoadScene("PreorderLevel1");
    }

    //postorder
}
