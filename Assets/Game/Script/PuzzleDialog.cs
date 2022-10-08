using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDialog : MonoBehaviour
{
    public bool Selected;

    void Update(){

        if(!Selected){
            Debug.Log("UnSelected");
        }
    }
    
}
