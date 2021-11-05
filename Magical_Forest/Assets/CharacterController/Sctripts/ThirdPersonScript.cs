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
        Debug.Log(checkG);

        CalculatingMovement();
    }


    void CalculatingMovement()
    {
        float targetAngle;
        float angle;
        Vector3 moveDir = new Vector3();

        Vector3 velocity = new Vector3();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        
        velocity = direction;
        
        if (velocity.magnitude >= 0.1f)
        {
            targetAngle = Mathf.Atan2(velocity.x, velocity.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            if (checkG == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isDoubleJumpActive = true;
                    velocity = direction * speed;
                    velocity.y -= gravity;

                    directionY = jump;
                    directionY -= Time.deltaTime * gravity;
                    velocity.y = directionY;

                    controller.Move(velocity *speed * Time.deltaTime);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) && isDoubleJumpActive == true) 
                {
                    velocity = direction * speed;
                    velocity.y -= gravity;

                    directionY = jump*jumpMultiplier;
                    isDoubleJumpActive = false;

                    directionY -= Time.deltaTime * gravity;
                    velocity.y = directionY;

                    controller.Move(velocity * speed * Time.deltaTime);
                }
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                controller.Move(moveDir.normalized * speed * 2 * Time.deltaTime);
            }
            else
            {
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
        }
        

    }
}
