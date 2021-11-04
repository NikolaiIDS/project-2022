using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookYslow : MonoBehaviour
{
    [SerializeField]
    private float sensitivityY = 1;
    private SlowTime slowY;
    void Start()
    {
        slowY = GameObject.Find("Player").GetComponent<SlowTime>();
    }


    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 newRotation = transform.localEulerAngles;
        if (slowY.SlowedTime() != 1)
        {
            newRotation.x -= mouseY * (sensitivityY * slowY.SlowedTime());
        }
        else
        {

            newRotation.x -= mouseY * sensitivityY;
        }
       
        if (newRotation.x < -90f)
        {
            newRotation.x = -89f;
        }
        transform.localEulerAngles = newRotation;
    }
    
}
