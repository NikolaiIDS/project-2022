using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int health;
    public int coins;
    //public int[] checkpoints;
    public bool dungeonPuzzle;
    public PlayerData(ThirdPersonScript tps)
    {
        health = tps.health;
        coins = tps.coins;

        //dungeonPuzzle = ps.correct;
    }
}
