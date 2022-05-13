using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScript : MonoBehaviour
{
    public GameObject wheel1;
    public int value1 = 1;
    public GameObject wheel2;
    public int value2 = 1;
    public GameObject wheel3;
    public int value3 = 1;
    public GameObject wheel4;
    public int value4 = 1;
    public bool In = false;
    public GameObject cam;
    public GameObject puzzleUI;
    public GameObject tps;

    int a = 0;

    public bool enter = false;
    public bool correct = false;

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F) && !In)
        {
            In = true;
            tps.SetActive(false);
            cam.SetActive(true);
            puzzleUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            a = 0;
        }
    }

    // Update is called once per frame
    void Update() 
    { 
        if (Input.GetKeyDown(KeyCode.F) && In && a>=1)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
            In = false;
            cam.SetActive(false);
            puzzleUI.SetActive(false);
            tps.SetActive(true);
        }
        if (enter && value1 == 3 && value2 == 1 & value3 == 4 && value4 == 2)
        {
            enter = false;
            correct = true;
            Debug.Log("Correct");
        }
        else
        {
            enter = false;
        }
        
        a++;
    }

    public void Wheel1()
    {
        if (value1 == 4)
        {
            value1 = 1;
        }
        else value1++;
        wheel1.transform.RotateAround(wheel1.transform.position, transform.forward, 90);
    }
    public void Wheel2()
    {
        if (value2 == 4)
        {
            value2 = 1;
        }
        else value2++;
        wheel2.transform.RotateAround(wheel2.transform.position, transform.forward, 90);
    }
    public void Wheel3()
    {
        if (value3 == 4)
        {
            value3 = 1;
        }
        else value3++;
        wheel3.transform.RotateAround(wheel3.transform.position, transform.forward, 90);
    }
    public void Wheel4()
    {
        if (value4 == 4)
        {
            value4 = 1;
        }
        else value4++;

        wheel4.transform.RotateAround(wheel4.transform.position, transform.forward, 90);
    }
    public void Enter()
    {
        enter = true;
    }

}
