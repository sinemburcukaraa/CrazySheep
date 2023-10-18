using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ToonyColorsPro.ShaderGenerator.Enums;

public class JoystickPlayerController : MonoBehaviour
{
    bool active;
    public UltimateJoystick ultimateJoystick;
    Rigidbody rigidbody;
    public float moveSpeed;
    public int jumpForce;
    public bool isJump=false;
    //Animator animator;

    private void Start()
    {
        rigidbody= GetComponent<Rigidbody>();
        active = true;
    }
    private void FixedUpdate()
    {
        jump();
        movement();

    }
    public void movement()
    {

        if (active)
        {
            rigidbody.velocity = new Vector3(ultimateJoystick.GetVerticalAxis() * (-moveSpeed), rigidbody.velocity.y, ultimateJoystick.GetHorizontalAxis() * (moveSpeed));
            if (ultimateJoystick.GetHorizontalAxis() != 0 || ultimateJoystick.GetVerticalAxis() != 0)
            {
                transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
                //animator.SetBool("walk", true);
            }
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
            //animator.SetBool("walk", false);
        }

    }

    public void jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isJump)
            {
                rigidbody.AddForce(Vector3.up * jumpForce);
                isJump = true;

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }

    }
}
