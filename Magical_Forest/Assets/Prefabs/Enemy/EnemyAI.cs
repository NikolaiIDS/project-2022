using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float Distance;

    public bool isAngered;

    public bool run;
    public bool idle;

    public AnimationsEnemy anims;
 
    public NavMeshAgent agent;
    void Start()
    {
        
    }
    void Update()
    {
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
            }
            else
            {
                idle = false;
                anims.Idle(idle);
                run = true;
                anims.Run(run);
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
    }

}
