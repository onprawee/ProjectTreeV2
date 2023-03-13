using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonMenuLearning : MonoBehaviour
{
    public void ButtonTreedata()
    {
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("treedata");
    }
    public void ButtonBinaryTree()
    {
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("binarytree");
    }
    public void ButtonTreeTraversal()
    {
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("Treetra");
    }

    public void ButtonHome()
    {
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("Menu_Home");
    }

}
