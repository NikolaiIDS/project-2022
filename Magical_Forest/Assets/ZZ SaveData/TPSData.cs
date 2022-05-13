using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSData : MonoBehaviour
{
    public CheckPoint2 checkpoint2;
    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = checkpoint2.pos;
        transform.position = position;
    }

}
