using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSccript : MonoBehaviour
{
    public ParticleSystem kaboom;
    public ParticleSystem kaboom2;
    EnemyAI enemyAI;
    public float dmg = 40;
    //public EnemyAI enemyAI;
    void Start()
    {
        enemyAI = GameObject.Find("Emeny").GetComponent<EnemyAI>();
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
        else if (collision.gameObject.CompareTag("Enemy"))
        {            
            enemyAI.DamageToEnemy(dmg);            
        }
        else
        {
            ParticleSystem explosionEffect = Instantiate(kaboom)
            as ParticleSystem;
            explosionEffect.transform.position = transform.position;
            explosionEffect.Play();
        }
        Destroy(gameObject);
    }
    
}
