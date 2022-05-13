using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] destinations;
    private Transform finalDestination;
    private bool canMove = true;
    Transform playerT;
    ThirdPersonScript player;
    [SerializeField]
    private float Distance;
    [SerializeField]
    private float distanceOfDetection;

    [SerializeField]
    private bool isAngered;

    [SerializeField]
    private bool walk;
    [SerializeField]
    private bool idle;
    [SerializeField]
    private bool punch;

    [SerializeField]
    private NPCAnimations anims;

    [SerializeField]
    private NavMeshAgent agent;

    public bool subs = false;

    void Start()
    {
        player = GameObject.Find("Character").GetComponent<ThirdPersonScript>();
        playerT = GameObject.Find("EnemyShootAt").GetComponent<Transform>();
        finalDestination = destinations[Random.Range(0, destinations.Length - 1)].transform;
    }
    void Update()
    {
        NPCMovement();
    }
    public void NPCMovement()
    {
        Vector3 targetLookNoY = new Vector3(playerT.position.x, transform.position.y, playerT.transform.position.z);
        Distance = Vector3.Distance(playerT.position, this.transform.position);
        if (player.health <= 0)
        {
            agent.isStopped = true;
            //punch = false;
            //anims.Punch(punch);
            walk = false;
            anims.Walk(walk);
            idle = true;
            anims.Idle(idle);
            return;
        }       
        else
        {
            
            if (Distance <= 15)
            {
                isAngered = true;
            }
            else
            {
                isAngered = false;
            }

            if (isAngered)
            {
                subs = true;
                transform.LookAt(targetLookNoY);
                agent.isStopped = true;
                walk = false;
                anims.Walk(walk);
                idle = true;
                anims.Idle(idle);
                StopCoroutine(MovingCountdown());
                /* transform.LookAt(playerT);
                 if (Distance <= 8)
                 {
                     agent.isStopped = true;
                     punch = true;
                     anims.Punch(punch);
                     walk = false;
                     anims.walk(walk);
                     idle = false;
                     anims.Idle(idle);
                 }
                 else
                 {

                     punch = false;
                     anims.Punch(punch);
                     walk = true;
                     anims.walk(walk);
                     idle = false;
                     anims.Idle(idle);
                     agent.isStopped = false;
                     agent.SetDestination(playerT.position);
                 }*/
            }
            else
            {
                if (canMove)
                {
                    StartCoroutine(MovingCountdown());
                }              
                isAngered = false;
                idle = false;
                anims.Idle(idle);
                walk = true;
                anims.Walk(walk);

                agent.isStopped = false;
            }
        }
    }
    IEnumerator MovingCountdown()
    {
        canMove = false;
        agent.SetDestination(finalDestination.position);
        yield return new WaitForSeconds(Random.Range(10, 30));
        finalDestination = destinations[Random.Range(0, destinations.Length - 1)].transform;
        canMove = true;
    }
}
