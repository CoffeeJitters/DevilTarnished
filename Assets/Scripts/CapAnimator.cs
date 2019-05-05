using System.Collections;
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
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            ani.SetBool("isRunning", true);
            ani.SetBool("isIdle", false);
            ani.SetBool("runJump", false);
            onGround = true;
            isJumping = false;
            isIdle = false;
            isRunning = true;

            if(Input.GetButton("Jump"))
            {
                if (contr.isGrounded == false)
                {
                    onGround = false;
                    isJumping = false;
                    isIdle = false;
                    isRunning = false;
                    runJump = true;
                    ani.SetTrigger("runJump");
                    ani.SetBool("isRunning", false);
                    ani.SetBool("isIdle", false);
                }

                if(contr.isGrounded == true)
                {
                    onGround = true;
                    isJumping = false;
                    isIdle = false;
                    isRunning = true;
                    runJump = false;
                    ani.SetBool("isRunning", true);
                    ani.SetBool("isIdle", false);
                }
            }
        }
       else if(Input.GetButton("Jump"))
        {
            ani.SetTrigger("isJumping");
            ani.SetBool("isRunning", false);
            ani.SetBool("isIdle", false);
            ani.SetBool("runJump", false);
            onGround = false;
            isJumping = true;
            isIdle = false;
            isRunning = false;
        }
        else
        {
            isIdle = true;
            onGround = true;
            isRunning = false;
            runJump = true;
            isJumping = false;
            ani.SetBool("isIdle", true);
            ani.SetBool("isRunning", false);
            ani.SetBool("runJump", false);
        }
    }
}
