using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    EnemyAI enemyAI;
    public bool a;
    // Start is called before the first frame update
    void Start()
    {
        enemyAI = GameObject.Find("Emeny").GetComponent<EnemyAI>();
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(Hit());
        }
    }
    IEnumerator Hit()
    {
        yield return new WaitForSeconds(1.07f);
        enemyAI.DamageToEnemy(60);
    }
}
