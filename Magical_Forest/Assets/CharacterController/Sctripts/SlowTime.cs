using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public float SlowiTime;
    public GameObject Particles;
    private float currTime = 1;
    public Player player;

    void Update()
    {

        if (Input.GetKeyDown("1"))
        {
            //Debug.Log("pressed");
            currTime = SlowiTime;
            Time.timeScale = SlowiTime;
            Particles.SetActive(true);
            player.GetComponent<Animator>().Play("Start");
        }
       


        if (Input.GetKeyUp("1"))
        {
            //Debug.Log("down");
            Particles.SetActive(false);
            currTime = 1f;
            Time.timeScale = currTime;
            player.GetComponent<Animator>().Play("End");
        }

    }
    public float SlowedTime()
    {
        return currTime;
    }
}
