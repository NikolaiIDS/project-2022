using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public Player player;
    public GameObject cam;


    private bool isCrouching = false;

    void Start()
    {
        player.GetComponent<Animator>().Play("Crouch");
        isCrouching = true;
        player.GetComponent<Animator>().Play("StandUp");
        isCrouching = false;
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            cam.GetComponent<Animator>().Play("CamShake");
        }

        /*if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) 
        {
            cam.GetComponent<Animator>().Play("CamShakeWalk"); 
        }*/
    }
    public bool CrouchAnimation()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl) && isCrouching == false)
        {
            player.GetComponent<Animator>().Play("Crouch");
            isCrouching = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && isCrouching == true || Input.GetButtonDown("Jump") && isCrouching == true)
        {
            player.GetComponent<Animator>().Play("StandUp");
            isCrouching = false;
        }
        return isCrouching;
    }
}
