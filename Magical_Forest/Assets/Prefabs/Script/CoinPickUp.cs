using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public Transform player;
    float distance;
    public float speed=10;

    private ThirdPersonScript tps;
    void Start()
    {
        tps = GameObject.Find("Character").GetComponent<ThirdPersonScript>();
        player = GameObject.Find("Character").GetComponent<Transform>();
        speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        if (distance <= 10f )
        {
            //Debug.Log(distance);
            transform.LookAt(player.position);
            transform.Translate(0, 0, speed * Time.deltaTime);            
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tps.coins++;
            Destroy(this.gameObject);
        }
    }
}
