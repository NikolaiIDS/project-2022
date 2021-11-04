using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow_tme : MonoBehaviour
{
    public float SlowTime;
    public GameObject Particles;
    

       
    void Update()
    {
        /* if (Input.GetKey(KeyCode.Mouse1))
         {


         }
         else
         {


         }*/

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Time.timeScale = SlowTime;
            Particles.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            Particles.gameObject.SetActive(false);
        }
    }
    public float SlowedTime()
    {
        return SlowTime;

    }


}
