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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isJumping", false);
        }
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A) && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
        {
            animator.SetBool(isWalkingHash, false);           
        }
        if ( shiftPressed && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
        {
            animator.SetBool(isRunningHash, true);
        }
        if (isRunning && (!shiftPressed || !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))))
        {
            animator.SetBool(isRunningHash, false);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouching", true); 
        }
        if (animator.GetBool("IsCrouching" )==true && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
        {
            animator.SetBool("isCrouchW", true);
        }
        if (animator.GetBool("IsCrouching") ==false|| !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
        {
            animator.SetBool("isCrouchW", false);
        }
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouching", false);
        }

    }
        

       
    
}
