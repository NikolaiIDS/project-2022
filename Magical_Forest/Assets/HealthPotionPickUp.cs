using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionPickUp : MonoBehaviour
{
    private ThirdPersonScript tps;
    public int MinHP = 100;
    public int MaxHP = 200;
    // Start is called before the first frame update
    void Start()
    {
        tps = GameObject.Find("Character").GetComponent<ThirdPersonScript>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tps.health += (float)Random.Range(MinHP, MaxHP);
            Destroy(this.gameObject);
        }
    }
}
