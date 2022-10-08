using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;


[System.Serializable]
public class Character : MonoBehaviour
{
    public string characterName;
    //the root is the container for all images related tot he character in the scene.the root object
    [HideInInspector]public RectTransform root;
    public Vector2 anchorPadding{get{return root.anchorMax-root.anchorMin;}}
    Vector2 targetPosition;
    Coroutine moving;
    bool isMoving{get{return moving != null;}}
    public void MoveTo(Vector2 Target, float speed, bool smooth = true)
    {
        //if we are moving, stop moving
        StopMoving();
        //start moving coroutine.
        moving = CharacterManager.instance.StartCoroutine(Moving(Target, speed, smooth));
    }
    public void StopMoving()
    {
        if(isMoving){
            CharacterManager.instance.StopCoroutine(moving);
        }
        moving = null;
    }

    IEnumerator Moving(Vector2 target, float speed, bool smooth) 
    {
        targetPosition = target;
        //now we want to get the padding between the anchors of this character so we know what their min and max position are.
        Vector2 padding = anchorPadding;
        //now get the limitations for 0 to 100% movement. the farthest a character can move to the right before reaching 100% should be the 1 value - the padding
        float maxX = 1f - padding.x;
        float maxY = 1f - padding.y;
        
        Vector2 minAnchorTarget = new Vector2 (maxX - targetPosition.x, maxY - targetPosition.y);
        speed *= Time.deltaTime;

        while(root.anchorMin != minAnchorTarget)
        {
            root.anchorMin =(!smooth) ? Vector2.MoveTowards (root.anchorMin, minAnchorTarget, speed): Vector2.Lerp (root.anchorMin, minAnchorTarget, speed);
            root.anchorMax = root.anchorMin + padding;
            yield return new WaitForEndOfFrame();
        }
        StopMoving();
    }
    
}
