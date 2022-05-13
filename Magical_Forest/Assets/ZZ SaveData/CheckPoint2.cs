using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint2 : MonoBehaviour
{
    public bool checkPointAquired;
    public GameObject cp1;

    public EnemyTowerScript[] towers = new EnemyTowerScript[3];
    public GameObject[] Enemies = new GameObject[7];

    public Vector3 pos;

    void Start()
    {
        if (checkPointAquired)
        {
            towers[0].coreHealth = 0;
            towers[0].shieldsHealth = 0;
            towers[1].coreHealth = 0;
            towers[1].shieldsHealth = 0;
            towers[2].coreHealth = 0;
            towers[2].shieldsHealth = 0;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TowerCheck();
        }
    }
    private void TowerCheck()
    {
        if (towers[0].coreHealth <= 0 && towers[1].coreHealth <= 0 && towers[2].coreHealth <= 0)
        {
            checkPointAquired = true;
        }
        if (checkPointAquired)
        {
            pos = gameObject.transform.position;
        }
        else
        {
            pos = cp1.transform.position;
        }
    }
}
