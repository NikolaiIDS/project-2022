using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public GameObject GroundCheck;
    bool checkG;
    public LayerMask lm;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private float directionY;
    bool isDoubleJumpActive = false;
    public float jump = 5;
    private float jumpMultiplier = 2;
    public float gravity = 9.81f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkG = Physics.CheckSphere(GroundCheck.transform.position, 0.3f, lm);
       // Debug.Log(checkG);

        CalculatingMovement();
    }


    void CalculatingMovement()
    {    
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 velocity = new Vector3();
        velocity = direction;

        if (Mathf.Sqrt(direction.x * direction.x + direction.z * direction.z) >= 0.1f) 
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                controller.Move(moveDir * speed * 2 * Time.deltaTime);
            }
            else
            {
                controller.Move(moveDir * speed * Time.deltaTime);
            }
        }

        /*direction = direction * speed;
        direction.y -= gravity;
        if (checkG == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //direction = direction * speed;
                //direction.y -= gravity;

                isDoubleJumpActive = true;                              
                directionY = jump;
                
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && isDoubleJumpActive == true)
            {
                //direction = direction * speed;
                //direction.y -= gravity;

                directionY = jump * jumpMultiplier;
                isDoubleJumpActive = false;

            }
        }
        directionY -= Time.deltaTime * gravity;
        direction.y = directionY;
        controller.Move(direction * Time.deltaTime);*/
    }
}
