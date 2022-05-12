using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimations : MonoBehaviour
{
    private bool isWalking;
    private bool isIdle;
    //private bool isPunching;
    //private bool isDying;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Idle(isIdle);
        Walk(isWalking);
        //Punch(isPunching);
        if (isIdle == true && isWalking == false)
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isWalking", false);
        }
        else if (isIdle == false && isWalking == true)
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", true);
        }
        /*if (isPunching == true && isWalking == false)
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Run", false);
        }
        else if (isPunching == false && isWalking == true)
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Run", true);
        }
        if (isDying == true)
        {
            animator.SetBool("Dead", true);
        }*/
    }
    public bool Idle(bool idle)
    {
        return isIdle = idle;
    }
    public bool Walk(bool run)
    {
        return isWalking = run;
    }
   /* public bool Punch(bool punch)
    {
        return isPunching = punch;
    }
    public bool Dying(bool die)
    {
        return isDying = die;
    }*/
}
