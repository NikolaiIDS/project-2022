using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeloShoot : MonoBehaviour
{
    public float bulletSpeed = 30;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            bulletSpeed = 0;
        }
        else if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        StartCoroutine(DespawnTimer());
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }
    IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    }
}
