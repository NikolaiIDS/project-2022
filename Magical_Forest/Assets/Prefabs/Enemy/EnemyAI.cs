using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform player;
    public float Distance;
    public ParticleSystem kaboom;

    public bool isAngered;

    public bool run;
    public bool idle;
    public bool punch;

    public bool ifDamageIsDealt;
    bool coroutine = false;

    public AnimationsEnemy anims;

    public NavMeshAgent agent;

    //[Header("Health")]
    public float health = 200f;

    void Start()
    {
        player = GameObject.Find("Character").GetComponent<Transform>();
        health = 200f;
    }
    void Update()
    {        
        EnemyMovement();
    }
    public void EnemyMovement()
    {
        ifDamageIsDealt = false;

        Distance = Vector3.Distance(player.position, this.transform.position);
        if (Distance <= 7.5)
        {
            isAngered = true;
        }
        else
        {
            isAngered = false;
        }

        if (isAngered)
        {
            if (Distance <= 2)
            {
                agent.isStopped = true;
                punch = true;
                anims.Punch(punch);
                run = false;
                anims.Run(run);
                idle = false;
                anims.Idle(idle);


                if (ifDamageIsDealt == false && coroutine == false)
                {
                    StartCoroutine(Num());
                }

            }
            else
            {
                punch = false;
                anims.Punch(punch);
                run = true;
                anims.Run(run);
                idle = false;
                anims.Idle(idle);
                agent.isStopped = false;
                agent.SetDestination(player.position);
            }

        }
        else
        {
            isAngered = false;
            idle = true;
            anims.Idle(idle);
            run = false;
            anims.Run(run);

            agent.isStopped = true;
        }
        DamageToPlayer();
    }

    public int DamageToPlayer()
    {
        if (ifDamageIsDealt == true)
        {
            return 20;
        }
        else return 0;
    }
    public void DamageToEnemy(float amount)
    {
        health -= amount;
        
        Debug.Log(health);
        if (health <= 0)
        {
            agent.isStopped = true;
            StartCoroutine(Dying());
        }
    }

    IEnumerator Num()
    {
        ifDamageIsDealt = true;
        coroutine = true;
        yield return new WaitForSeconds(1.1f);
        coroutine = false;

    }
    IEnumerator Dying()
    {        
        anims.Dying(true);
        yield return new WaitForSeconds(3f);
        ParticleSystem explosionEffect = Instantiate(kaboom)
            as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        explosionEffect.Play();
        Destroy(gameObject);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sword")*//* && Input.GetKey(KeyCode.Mouse0)*//*)
        {
            DamageToEnemy(60);
            // a = true;
            Debug.Log("is hitting");
        }
        //else a = false;
    }*/
}
