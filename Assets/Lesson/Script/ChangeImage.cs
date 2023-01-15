using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    [SerializeField]
    public Image original;
    public Sprite newSprite;

    public Sprite newSprite1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void NewImage(){
        
        original.sprite = newSprite;
    }
     public void NewImage1(){
        
        newSprite = newSprite1;
    }
    
}
