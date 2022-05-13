using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    public PuzzleScript ps;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ps.correct == true)
        {
            SceneManager.LoadScene("Dungeon 1");
        }
        
    }
}
