using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator animator;
    bool _crouch = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && animator.GetBool("isCrouchW")==false)
        {
            animator.SetBool("isWalking", true);
        }
        else animator.SetBool("isWalking", false);

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("walkLeft", true);
        }
        else animator.SetBool("walkLeft", false);

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("walkRight", true);
        }
        else animator.SetBool("walkRight", false);

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("walkBackward", true);
        }
        else animator.SetBool("walkBackward", false);

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("diagonal", true);
        }
        else animator.SetBool("diagonal", false);



        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.LeftShift) != true || Input.GetKey(KeyCode.W) != true)
        {
            animator.SetBool("isRunning", false);
        }
        /*if ((!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.S) || !Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.A)) && Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCWfromW", false);
        }*/        
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
        else if(animator.GetBool("IsCrouching") == true && !(Input.GetKey(KeyCode.W)))
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
