using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnStarOnAndOff : MonoBehaviour
{
    [SerializeField]
    private GameObject node;
  
    private bool starIsEnabled;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TurnOnAndOff);
        starIsEnabled = false; //ซ่อนโหนดไว้ก่อน
        node.SetActive(starIsEnabled); 
    }

    // Update is called once per frame
     private void TurnOnAndOff()
    {
        starIsEnabled ^=true;
        node.SetActive(starIsEnabled);
    }
   
}
