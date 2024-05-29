using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalmove = 0f;
    public bool jump = false;
    public float runSpeed = 40f;
    public Animator animator;

    private void FixedUpdate()
    {
        controller.Move(horizontalmove * Time.fixedDeltaTime, false, jump);
        jump = false;       
    }

    private void Update()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalmove));

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("Jump", true);
            jump = true;
            //controller.JumpBufferCounter = controller.JumpBufferTime;
            if (!controller.m_Grounded && controller.JumpAmount >= 1)
            {
                controller.JumpAmount += 1;
            }
        }
        /*else
        {
            controller.JumpBufferCounter -= Time.deltaTime;
        }*/
    }
}

