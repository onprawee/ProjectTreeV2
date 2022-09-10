using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MovementJoyStick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movementJoystick.joyStickVec.y != 0 ){
            rb.velocity = new Vector2(movementJoystick.joyStickVec.x * playerSpeed, movementJoystick.joyStickVec.y * playerSpeed);
        }
        else{
            rb.velocity = Vector2.zero;
        }
    }
}
