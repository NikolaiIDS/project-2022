using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSccript : MonoBehaviour
{
    public ParticleSystem kaboom;
    public ParticleSystem kaboom2;
    private EnemyAI enemyAI;
    public int dmg = 40;
    //public EnemyAI enemyAI;
    void Start()
    {
        //enemyAI = GameObject.Find("Emeny").GetComponent<EnemyAI>();
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
        if (collision.gameObject.CompareTag("Tree"))
        {
            ParticleSystem explosionEffect = Instantiate(kaboom)
            as ParticleSystem;
            explosionEffect.transform.position = transform.position;
            explosionEffect.Play();
            ParticleSystem explosionEffect2 = Instantiate(kaboom2)
            as ParticleSystem; explosionEffect2.transform.position = transform.position;
            explosionEffect2.Play();
        }
        else
        {
            ParticleSystem explosionEffect = Instantiate(kaboom)
            as ParticleSystem;
            explosionEffect.transform.position = transform.position;
            explosionEffect.Play();
            if (collision.gameObject.CompareTag("Enemy"))
            {
                enemyAI = collision.gameObject.GetComponent<EnemyAI>();
                enemyAI.health -= dmg;
            }
        }
        
        
        Destroy(gameObject);
    }
    
}
