﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapAnimator : MonoBehaviour
{
    public Animator ani;
    public CharacterController contr;
    private bool onGround;
    private bool isJumping;
    private bool isIdle;
    private bool isRunning;
    private bool runJump;


    // Start is called before the first frame update
    void Start()
    {
        contr = GetComponent<CharacterController>();
        ani = GetComponent<Animator>();
        onGround = true;
        isJumping = false;
        isIdle = true;
        isRunning = false;
        runJump = false;
        ani.SetBool("isRunning", false);
        ani.SetBool("isIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            ani.SetBool("isRunning", true);
            ani.SetBool("isIdle", false);
            onGround = true;
            isJumping = false;
            isIdle = false;
            isRunning = true;
            runJump = false;

            if (Input.GetButton("Jump"))
            {
                ani.SetTrigger("runJump");
                ani.SetBool("isIdle", false);
                ani.SetBool("isRunning", false);
                onGround = false;
                isJumping = false;
                isIdle = false;
                isRunning = false;
                runJump = true;
            }
        }
        else if (Input.GetButton("Jump"))
        {
            if (isJumping == false)
            {
                ani.SetTrigger("isJumping");
                ani.SetBool("isIdle", false);
                ani.SetBool("isRunning", false);
                onGround = false;
                isJumping = true;
                isIdle = false;
                isRunning = false;
                runJump = false;
            }
        }
        else //no button is pressed, just standing there or in jump sequence
        {
            if (contr.isGrounded == false)
            {
                if (isJumping == true)
                {
                    //ani.SetTrigger("isJumping");
                    ani.SetBool("isIdle", false);
                    ani.SetBool("isRunning", false);
                    onGround = false;
                    isJumping = true;
                    isIdle = false;
                    isRunning = false;
                    runJump = false;
                }
                if (runJump == true)
                {
                  //  ani.SetTrigger("runJump");
                    ani.SetBool("isIdle", false);
                    ani.SetBool("isRunning", false);
                    onGround = false;
                    isJumping = false;
                    isIdle = false;
                    isRunning = false;
                    runJump = true;
                }
            }
            if (contr.isGrounded == true)
            //else
            {
                isIdle = true;
                onGround = true;
                isRunning = false;
                runJump = false;
                isJumping = false;
                ani.SetBool("isIdle", true);
                ani.SetBool("isRunning", false);
            }
        }
    }
}
