using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField]
    private float sensitivityY = 1;
    float yRot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x -= mouseY * sensitivityY;
        if (newRotation.x < -90f)
        {
            newRotation.x = -89f;
        }
        transform.localEulerAngles = newRotation;
    }
}
