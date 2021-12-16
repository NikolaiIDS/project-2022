using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSccript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(BeforeDestroy());
    }

    IEnumerator BeforeDestroy()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
