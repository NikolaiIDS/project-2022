using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    public ThirdPersonScript tps;
    bool groundCheck;
    bool doubleJump = false;

    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isCrouching;
    int isCrouchW;
    bool _crouch = false;

    public bool swordIsEquipped;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isCrouching = Animator.StringToHash("isCrouching");
        isCrouchW = Animator.StringToHash("isCrouchW");

    }

    // Update is called once per frame
    void Update()
    {
        groundCheck = tps.GCheck();
        //doubleJump = tps.DoubleJump();

        bool shiftPressed = Input.GetKey(KeyCode.LeftShift);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isCrouched = Input.GetKeyDown(KeyCode.LeftControl);
        bool isCrouchWalking = animator.GetBool(isCrouchW);

        /*if ((!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.S) || !Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.A)) && Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCWfromW", false);
        }*/
        

        // Crouch walking Forward
        if (!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCWfromW", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isJumping", false);
            doubleJump = true;
            

        }

        if (groundCheck == true)
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false); 
            animator.SetBool("doubleJump", false);
        }

        if (doubleJump == true && Input.GetKeyDown(KeyCode.Space) && groundCheck == false)
        {
            animator.SetBool("doubleJump", true);
            doubleJump = false;            
        }

        /*if (doubleJump == false && Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("doubleJump", false);
        }*/


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
            if (Input.GetKey(KeyCode.LeftControl))
            {
                animator.SetBool("isCWfromW", true);
            }
            if (!Input.GetKey(KeyCode.LeftControl))
            {
                animator.SetBool("isCWfromW", false);
            }
        }

        // Standing walking Forward
        if (Input.GetKey(KeyCode.W) && animator.GetBool("isCrouchW") == false)
        {
            animator.SetBool("isWalking", true);
        }
        else animator.SetBool("isWalking", false);

        // Standing walking Left
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("walkLeft", true);
        }
        else animator.SetBool("walkLeft", false);

        // Standing walking Right
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("walkRight", true);
        }
        else animator.SetBool("walkRight", false);

        // Standing walking Backward
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("walkBackward", true);
        }
        else animator.SetBool("walkBackward", false);
         
        // Move Diagonally Standing with Forward
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("diagonal", true);
        }
        else animator.SetBool("diagonal", false);

        // Sprint while holding Forward and Crouch=FALSE
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isRunning", true);
        }
        // No spring while Shift=FALSE and Forward=FALSE
        else if (Input.GetKey(KeyCode.LeftShift) != true || Input.GetKey(KeyCode.W) != true)
        {
            animator.SetBool("isRunning", false);
        }

        // 
        if (isRunning && (!shiftPressed || !(Input.GetKey(KeyCode.W) /*|| Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)*/)))
        {
            animator.SetBool(isRunningHash, false);
            if (Input.GetKey(KeyCode.LeftControl))
            {
                animator.SetBool("isCWfromW", true);
            }
            if (!Input.GetKey(KeyCode.LeftControl))
            {
                animator.SetBool("isCWfromW", false);
            }
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouching", true);
        }
        if (animator.GetBool("IsCrouching") == true && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
        {
            animator.SetBool("isCrouchW", true);
        }
        if (animator.GetBool("IsCrouching") == false || !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
        {
            animator.SetBool("isCrouchW", false);
        }
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouching", false);
        }
        if (animator.GetBool("IsCrouching") == true && animator.GetBool("isCrouchW") == false)
        {
            animator.SetBool("fromCtoCI", true);
        }
        if (!animator.GetBool("IsCrouching") == true || animator.GetBool("isCrouchW") == true)
        {
            animator.SetBool("fromCtoCI", false);
        }

        CrouchIsEnabled();
    }
    public bool CrouchIsEnabled()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouching", true);
            _crouch = true;
        }
        else
        
        {
            animator.SetBool("IsCrouching", false);
            _crouch = false;
        }
        //Crouch W
        if (animator.GetBool("IsCrouching") == true && Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isCrouchW", true);
            _crouch = true;
        }
        
        else if (animator.GetBool("IsCrouching") == true && !(Input.GetKey(KeyCode.W)))
        {
            animator.SetBool("isCrouchW", false);
            _crouch = true;
        }
        //Crouch A
        if (animator.GetBool("IsCrouching") == true && Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isCrouchA", true);
            _crouch = true;
        }
        else if (animator.GetBool("IsCrouching") == true && !(Input.GetKey(KeyCode.A)))
        {
            animator.SetBool("isCrouchA", false);
            _crouch = true;
        }
        //Crouch S
        if (animator.GetBool("IsCrouching") == true && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isCrouchS", true);
            _crouch = true;
        }
        else if (animator.GetBool("IsCrouching") == true && !(Input.GetKey(KeyCode.S)))
        {
            animator.SetBool("isCrouchS", false);
            _crouch = true;
        }
        //Crouch D
        if (animator.GetBool("IsCrouching") == true && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isCrouchD", true);
            _crouch = true;
        }
        else if (animator.GetBool("IsCrouching") == true && !(Input.GetKey(KeyCode.D)))
        {
            animator.SetBool("isCrouchD", false);
            _crouch = true;
        }
        /*if (animator.GetBool("IsCrouching") == false && !(Input.GetKey(KeyCode.W)))
        {
            animator.SetBool("isCrouchW", false);
            _crouch = true;
        }*/
        return _crouch;
    }

    public void SwordController()
    {
        animator.SetLayerWeight(1, 1f);
        swordIsEquipped = true;
    }
    public void WandController()
    {
        animator.SetLayerWeight(1, 0f);
        swordIsEquipped = false;
    }



}
