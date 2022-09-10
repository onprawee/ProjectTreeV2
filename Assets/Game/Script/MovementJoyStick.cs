using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementJoyStick : MonoBehaviour
{
    public GameObject joyStickBG;
    public GameObject joyStick;
    public Vector2 joyStickVec; //Vec = Vector, ทิศทาง
    private Vector2 joyStickTouchPos; //pos = position
    private Vector2 joyStickOriginalPos;
    private float joyStickRadius;


    // Start is called before the first frame update
    void Start()
    {
        joyStickOriginalPos = joyStickBG.transform.position;
        joyStickRadius = joyStickBG.GetComponent<RectTransform>().sizeDelta.y / 4;

    }
    public void PointerDown(){
        joyStick.transform.position = Input.mousePosition;
        joyStickBG.transform.position = Input.mousePosition;
        joyStickTouchPos = Input.mousePosition;
    } 
    public void Drag(BaseEventData baseEventData){
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joyStickVec = (dragPos - joyStickTouchPos).normalized;

        float joyStickDist = Vector2.Distance(dragPos,joyStickTouchPos);

        if(joyStickDist < joyStickRadius){
            joyStick.transform.position = joyStickTouchPos + joyStickVec * joyStickDist;
        }else{
            joyStick.transform.position = joyStickTouchPos + joyStickVec * joyStickRadius;
        }
    }
    public  void PointerUp(){
        joyStickVec = Vector2.zero;
        joyStick.transform.position = joyStickOriginalPos;
        joyStickBG.transform.position = joyStickOriginalPos;
    }

}
