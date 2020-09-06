using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class AndroidPlayerMovement : MonoBehaviour
{
    /*public CharController controller;
    public Animator animator;
    //public Animator orbAnimator;

    //public Joystick joystick;

    public float runSpeed = 40;
    public float smooth = 0.5f;

    float horizontalMove = 0f;
    bool crouch = false;
    bool jump = false;


    void Update()
    {
        *//*for(int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            if (touchPosition.x)
            {

            }
        }*//*

        if (joystick.Horizontal >= .3f)
        {
            horizontalMove = runSpeed;
        } else if (joystick.Horizontal <= -.3f)
        {
            horizontalMove = -runSpeed;

        }
        else
        {
            horizontalMove = 0;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Jump Control
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        // Crouch Control
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;

        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    public void TouchJump()
    {
        jump = true;
        animator.SetBool("IsJumping", true);
    }

    void FixedUpdate()
    {
        // Updating Physics Controls
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;        
    }*/
}
