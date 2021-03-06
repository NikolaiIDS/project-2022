using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public float SlowiTime;
   
    private float currTime = 1;
   
    public Animator Animator;
    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown("1"))
        {
            Debug.Log("pressed");
            currTime = SlowiTime;
            Time.timeScale = SlowiTime;
            
            Animator.GetComponent<Animator>().Play("Start");
        }
       


        if (Input.GetKeyUp("1"))
        {
            Debug.Log("down");
           
            currTime = 1f;
            Time.timeScale = currTime;
            Animator.GetComponent<Animator>().Play("End");
        }

    }
    public float SlowedTime()
    {
        return currTime;
    }
}
