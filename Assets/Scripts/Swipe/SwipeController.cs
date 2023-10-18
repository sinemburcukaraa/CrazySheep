using System.Collections;
using System.Collections.Generic;
using UltimateJoystickExample.Spaceship;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour
{
    Rigidbody rb;
    public UltimateJoystick js;
    public int Speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    public int value = 5;
    public void Update()
    {
        PlayerMovementControl();
    }

    public void PlayerMovementControl()
    {
        float horizontal = js.GetHorizontalAxis();
        //transform.Translate(new Vector3((horizontal* value)* 5, 0, Speed));
        rb.velocity = new Vector3((horizontal * value) * 5, 0, Speed);

        if (transform.position.x < -4.5f)
        {
            value = 0;
            if (js.GetHorizontalAxis() > 0)
            {
                value = Speed;
            }
        }
        if (transform.position.x > 4.5f)
        {
            value = 0;
            if (js.GetHorizontalAxis() < 0)
            {
                value = Speed;
            }
        }
    }
}
