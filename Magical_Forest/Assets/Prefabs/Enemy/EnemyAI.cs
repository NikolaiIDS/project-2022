using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
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
    private AnimationsEnemy anims;

    [SerializeField]
    private NavMeshAgent agent;

    [Header("Health")]
    public float health = 200f;
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

/*
    Transform playerT;
    ThirdPersonScript player;
    public float Distance;
    public ParticleSystem kaboom;
    public float distanceOfDetection;

    public bool isAngered;

    public bool run;
    public bool idle;
    public bool punch;

    public bool ifDamageIsDealt;
    public bool coroutine = false;

    public AnimationsEnemy anims;

    public NavMeshAgent agent;

    [Header("Health")]
    public float health = 200f;
    bool isDead = false;

    [Header("Level")]
    public int level;
    public int coinsDrop;
    public GameObject coinPrefab;
    public Transform enemyMesh;
*/

    void Start()
    {
        level = 2;
        coinsDrop = level * 5;
        playerT = GameObject.Find("Character").GetComponent<Transform>();
        player = GameObject.Find("Character").GetComponent<ThirdPersonScript>();
        health = 200f;
    }
    void Update()
    {        
        EnemyMovement();
    }
    public void EnemyMovement()
    {

        if (!isDead)
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
                if (Distance <= 8)
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


        Debug.Log(health);
        if (health <= 0)
        {
            agent.isStopped = true;
            isDead = true;

            StartCoroutine(Dying());
        }
    }

    public int DamageToPlayer()
    {
        if (ifDamageIsDealt == true)
        {
            return 20;
        }
        else return 0;
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
        for (int i = 0; i < coinsDrop; i++)
        {
            Instantiate(coinPrefab, new Vector3(enemyMesh.position.x + Random.Range(1f,5f), enemyMesh.position.y + Random.Range(1f,5f), enemyMesh.position.z+Random.Range(1f,5f)), Quaternion.identity);
            

            //Instantiate(coinPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(Random.Range(-180f,180f), 0, 0));
        }
        Instantiate(healthPotion, new Vector3(enemyMesh.position.x + Random.Range(1f, 5f), enemyMesh.position.y + Random.Range(1f, 5f), enemyMesh.position.z + Random.Range(1f, 5f)), Quaternion.identity);
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
