using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeloShoot : MonoBehaviour
{
    public float bulletSpeed = 30;
    void Start()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }
}
