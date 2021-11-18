using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    private AnimationStateController anims;

    public GameObject GroundCheck;
    bool checkG;
    public LayerMask lm;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private float directionY;
    bool isDoubleJumpActive = false;
    public float jump = 5;
    private float jumpMultiplier = 2f;
    public float gravity = 9.81f;

    bool crouch;

    // Start is called before the first frame update
    void Start()
    {
        anims = GetComponent<AnimationStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck = GameObject.Find("GroundCheck");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        checkG = Physics.CheckSphere(GroundCheck.transform.position, 0.3f, lm);
        //Debug.Log(checkG);

        CalculatingMovement();
    }


    void CalculatingMovement()
    {
        
        crouch = anims.CrouchIsEnabled();

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        float yRotation = cam.transform.localEulerAngles.y;//+ 180;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, yRotation, ref turnSmoothVelocity, turnSmoothTime);

        if (direction.magnitude >= 0.1f)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        direction *= speed;
        direction.y -= gravity;        

        if (checkG == true && crouch == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isDoubleJumpActive = true;
                directionY = jump;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && isDoubleJumpActive == true && crouch == false)
            {
                directionY = jump * jumpMultiplier;                
                isDoubleJumpActive = false;
            }
        }
        directionY -= Time.deltaTime * gravity;
        direction.y = directionY;

        GCheck();
        DoubleJump();

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && crouch == false)
        {
            direction = transform.transform.TransformDirection(direction);
            controller.Move(direction * 2.5f * Time.deltaTime);
        }
        else
        {
            direction = transform.transform.TransformDirection(direction);
            controller.Move(direction * Time.deltaTime);
        }
    }
    public bool GCheck()
    {
        return checkG;
    }

    public bool DoubleJump()
    {
        return isDoubleJumpActive;
    }
}
