using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    EnemyAI enemyAI;
    public int damage = 80;
    public bool a = true;
    // Start is called before the first frame update
    void Start()
    {
        enemyAI = GameObject.Find("Emeny").GetComponent<EnemyAI>();
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Input.GetKey(KeyCode.Mouse0))
        {
            if (a)
            {
                enemyAI = collision.gameObject.GetComponent<EnemyAI>();
                enemyAI.health -= damage;
                a = false;
            }
            else if (!a)
            {
                a = true;
            }
            
        }
    }

}
