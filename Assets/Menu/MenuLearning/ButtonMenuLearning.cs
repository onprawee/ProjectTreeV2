using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public class ButtonMenuLearning : MonoBehaviour
{
    public void ButtonTreedata()
    {
        SceneManager.LoadScene("treedata");
    }
    public void ButtonBinaryTree()
    {
        SceneManager.LoadScene("binarytree");
    }
    public void ButtonTreeTraversal()
    {
        SceneManager.LoadScene("Treetra");
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
