using UnityEngine;
using System.Collections;

public class MagicAbilitiesScript : MonoBehaviour
{
    public float bulletSpeed = 10;
    public Rigidbody bullet;
    private bool canShoot = true;
    public Transform cam;
    AnimationStateController anims;
    void Start()
    {
        anims = GameObject.Find("Character").GetComponent<AnimationStateController>();
    }
    void Update()
    {
        if (!anims.swordIsEquipped)
        {
            transform.rotation = Quaternion.Euler(cam.transform.localEulerAngles.x, cam.transform.localEulerAngles.y, 0);
            if (Input.GetButtonDown("Fire1"))
                Fire();
        }
    }
    void Fire()
    {
        if (Time.timeScale != 0 && canShoot)
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
            bulletClone.velocity = transform.forward * bulletSpeed;
            canShoot = false;
            StartCoroutine(ShootingCountdown());
        }

    }
    IEnumerator ShootingCountdown()
    {
        yield return new WaitForSeconds(.5f);
        canShoot = true;
    }
}