using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlowTime : MonoBehaviour
{
    public float SlowiTime ;
    public GameObject Particles;
    private float currTime;    
    void Update()
    {      
        if (Input.GetKey(KeyCode.Mouse1))
        {
            currTime = SlowiTime;                                           
            Time.timeScale = SlowiTime;
            Particles.gameObject.SetActive(true);

        }
        else
        {
            currTime = 1f;
            Time.timeScale = currTime;
            Particles.gameObject.SetActive(false);
        }
    }
    public float SlowedTime()
    {
        return currTime;
    }   
}