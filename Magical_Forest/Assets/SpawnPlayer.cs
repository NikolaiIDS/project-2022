using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        Invoke("FPC", 1f);

    }
    private void FPC()
    {
        Instantiate(player, transform.position, player.transform.rotation);
    }

   
}
