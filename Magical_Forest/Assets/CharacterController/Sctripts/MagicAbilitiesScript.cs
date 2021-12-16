using UnityEngine;
using System.Collections;

public class MagicAbilitiesScript : MonoBehaviour
{
    public float bulletSpeed = 10;
    public Rigidbody bullet;
    public Transform cam;


    

    void Update()
    {
        transform.rotation = Quaternion.Euler(cam.transform.localEulerAngles.x, cam.transform.localEulerAngles.y, 0);
        if (Input.GetButtonDown("Fire1"))
            Fire();
    }
    void Fire()
    {
        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed;
    }
}