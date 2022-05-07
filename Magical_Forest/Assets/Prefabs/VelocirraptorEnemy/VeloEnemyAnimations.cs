using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeloEnemyAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isRunning;
    private bool isIdle;
    private bool isPunching;
    private bool isDying;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Idle(isIdle);
        Run(isRunning);
        Punch(isPunching);
        if (isIdle == true && isRunning == false)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Run", false);
        }
        else if (isIdle == false && isRunning == true)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Run", true);
        }
        if (isPunching == true && isRunning == false)
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Run", false);
        }
        else if (isPunching == false && isRunning == true)
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Run", true);
        }
        /*if (isDying == true)
        {
            animator.SetBool("Dying", true);
        }*/
    }
    public bool Idle(bool idle)
    {
        return isIdle = idle;
    }
    public bool Run(bool run)
    {
        return isRunning = run;
    }
    public bool Punch(bool punch)
    {
        return isPunching = punch;
    }
    public bool Dying(bool die)
    {
        return isDying = die;
    }
}
