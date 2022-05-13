using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InToDaDungeon : MonoBehaviour
{
    public EnemyTowerScript[] towers = new EnemyTowerScript[3];
    public GameObject subF;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            subF.SetActive(true);
        }
        if (other.CompareTag("Player") && towers[0].coreHealth <= 0 && towers[1].coreHealth <= 0 && towers[2].coreHealth <= 0 && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("DefaultDungeonScene");
        }       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            subF.SetActive(false);
        }
    }
}
