using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isCrouching;
    int isCrouchW;
    bool _crouch = false;
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
        }


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
        if (isRunning && (!shiftPressed || !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))))
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
        /*if (animator.GetBool("IsCrouching") == false && !(Input.GetKey(KeyCode.W)))
        {
            animator.SetBool("isCrouchW", false);
            _crouch = true;
        }*/
        return _crouch;
    }



}
