using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VeloEnemyAI : MonoBehaviour
{
    Transform playerT;
    ThirdPersonScript player;
    [SerializeField]
    private float Distance;
    [SerializeField]
    private ParticleSystem kaboom;
    [SerializeField]
    private float distanceOfDetection;

    [SerializeField]
    private bool isAngered;

    [SerializeField]
    private bool run;
    [SerializeField]
    private bool idle;
    [SerializeField]
    private bool punch;

    [SerializeField]
    private bool ifDamageIsDealt;
    private bool coroutine = false;

    [SerializeField]
    private VeloEnemyAnimations anims;

    [SerializeField]
    private NavMeshAgent agent;

    //[SerializeField]
    //private GameObject neck;
    [Header("Shooting")]
    [SerializeField]
    private float shootRange;
    [SerializeField]
    private bool _shootIsActive = false;
    [SerializeField]
    private GameObject Spike;
    [SerializeField]
    private Transform shootFrom;

    [Header("Health")]
    public int health;
    bool isDead = false;

    [Header("Level")]
    [SerializeField]
    private int level;
    [SerializeField]
    private int coinsDrop;
    [SerializeField]
    private GameObject coinPrefab;
    [SerializeField]
    private Transform enemyMesh;
    [SerializeField]
    private GameObject healthPotion;

    void Start()
    {
        level = 2;
        coinsDrop = level * 5;
        playerT = GameObject.Find("EnemyShootAt").GetComponent<Transform>();
        player = GameObject.Find("Character").GetComponent<ThirdPersonScript>();
        health = 100;
    }
    void Update()
    {

        EnemyMovement();
    }
    public void EnemyMovement()
    {
        Vector3 targetLookNoY = new Vector3(playerT.position.x, transform.position.y, playerT.transform.position.z);
        Vector3 targetLook = new Vector3(playerT.position.x, playerT.position.y, playerT.transform.position.z);

        if (player.health <= 0)
        {
            agent.isStopped = true;
            punch = false;
            anims.Punch(punch);
            run = false;
            anims.Run(run);
            idle = true;
            anims.Idle(idle);
            return;
        }
        if (health <= 0 && !isDead)
        {
            isDead = true;
            agent.isStopped = true;
            Debug.Log("AAA");
            StartCoroutine(Dying());
        }
        else if (!isDead)
        {
            ifDamageIsDealt = false;


            Distance = Vector3.Distance(playerT.position, this.transform.position);
            if (Distance <= distanceOfDetection)
            {
                isAngered = true;
            }
            else
            {
                isAngered = false;
            }

            if (isAngered)
            {
                //neck.transform.LookAt(playerT);
                transform.LookAt(targetLookNoY);
                shootFrom.LookAt(targetLook);
                if (Distance <= shootRange)
                {
                    if (!coroutine)
                    {
                        StartCoroutine(Shooting());
                    }                                        
                    agent.isStopped = true;
                    punch = true;
                    anims.Punch(punch);
                    run = false;
                    anims.Run(run);
                    idle = false;
                    anims.Idle(idle);


                    /*if (ifDamageIsDealt == false && coroutine == false)
                    {
                        StartCoroutine(Num());
                    }*/

                }
                else
                {
                    StopCoroutine(Shooting());
                    punch = false;
                    anims.Punch(punch);
                    run = true;
                    anims.Run(run);
                    idle = false;
                    anims.Idle(idle);
                    agent.isStopped = false;
                    agent.SetDestination(playerT.position);
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
            /*if (ifDamageIsDealt == true)
            {
                player.DamageIsDealt(20f);
                //player.health -= 20;
                Debug.Log("Hit works");
            }
            else
            {
                player.DamageIsDealt(0f);
                //player.health -= 0;
            }

            //DamageToPlayer();*/
        }
        else agent.isStopped = true;


        //Debug.Log(health);
        
    }

    IEnumerator Shooting()
    {
        coroutine = true;
        yield return new WaitForSeconds(.2f);
        Instantiate(Spike, new Vector3(shootFrom.position.x + 1f, shootFrom.position.y, shootFrom.position.z), shootFrom.rotation);
        yield return new WaitForSeconds(.05f);
        Instantiate(Spike, shootFrom.position, shootFrom.rotation);
        yield return new WaitForSeconds(.05f);
        Instantiate(Spike, new Vector3(shootFrom.position.x - 1f, shootFrom.position.y, shootFrom.position.z), shootFrom.rotation);
        //Debug.Log("shoots");
        yield return new WaitForSeconds(.725f);        
        
        coroutine = false;
        
        /*yield return new WaitForSeconds(.3f);
        Instantiate(Spike, shootFrom);*/
    }
    IEnumerator Dying()
    {
        anims.Dying(true);
        yield return new WaitForSeconds(2f);
        ParticleSystem explosionEffect = Instantiate(kaboom)
            as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        explosionEffect.Play();

        Destroy(gameObject);
        Instantiate(healthPotion, new Vector3(enemyMesh.position.x + Random.Range(1f, 5f), enemyMesh.position.y + Random.Range(1f, 5f), enemyMesh.position.z + Random.Range(1f, 5f)), Quaternion.identity);
        /*
                CoinBagScript coinBag;
                GameObject a = Instantiate(coinPrefab, new Vector3(enemyMesh.position.x + Random.Range(1f, 5f), enemyMesh.position.y + Random.Range(1f, 5f), enemyMesh.position.z + Random.Range(1f, 5f)), Quaternion.identity);
                coinBag = a.GetComponent<CoinBagScript>();
                coinBag.coins = coinsDrop;*/
        for (int i = 1; i <= coinsDrop; i++)
        {
            Instantiate(coinPrefab, new Vector3(enemyMesh.position.x + Random.Range(1f, 5f), enemyMesh.position.y + Random.Range(1f, 5f), enemyMesh.position.z + Random.Range(1f, 5f)), Quaternion.identity);


            //Instantiate(coinPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(Random.Range(-180f,180f), 0, 0));
        }
    }
}
