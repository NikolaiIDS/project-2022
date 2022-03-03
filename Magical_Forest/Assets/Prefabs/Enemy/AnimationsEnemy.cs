using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsEnemy : MonoBehaviour
{
    private bool isRunning;
    private bool isIdle;
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
    }
    public bool Idle(bool idle)
    {
        return isIdle = idle;
    }
    public bool Run(bool run)
    {
        
        return isRunning = run;
    }
}
