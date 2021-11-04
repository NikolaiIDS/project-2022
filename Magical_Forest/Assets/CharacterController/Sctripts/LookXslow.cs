using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookXslow : MonoBehaviour
{

    public float sensitivityX;
    public SlowTime slowX;

   
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X");
        Vector3 newRotation = transform.localEulerAngles;
        if (slowX.SlowedTime()!=1)
        {            
            newRotation.y += mouseX * (sensitivityX * slowX.SlowedTime());
        }
        else
        {
           
            newRotation.y += mouseX * sensitivityX;
        }
        transform.localEulerAngles = newRotation;
    }
}
