using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    private AnimationStateController anims;

    public GameObject cinemachine;
    private float _cinemachineTransformPosY;
    public GameObject cmAimed;
    private float _cmAimedTransformY;
    private bool isAimed = false;

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
        //cinemachine = GameObject.Find("CM1");
        //cmAimed = GameObject.Find("CM2");
    }

    // Update is called once per frame
    void Update()
    {
        _cinemachineTransformPosY = cinemachine.transform.position.y;
        _cmAimedTransformY = cmAimed.transform.position.y;
        GroundCheck = GameObject.Find("GroundCheck");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        checkG = Physics.CheckSphere(GroundCheck.transform.position, .3f, lm);
        //Debug.Log(checkG);

        CalculatingMovement();
    }
    void CalculatingMovement()
    {
        
        crouch = anims.CrouchIsEnabled();

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 1, Input.GetAxisRaw("Vertical")).normalized;

        float yRotation = cam.transform.localEulerAngles.y + 6.76f;//+ 180;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, yRotation, ref turnSmoothVelocity, turnSmoothTime);

        if (direction.magnitude >= 0.1f && isAimed == false)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        if (isAimed == true)
        {
            transform.rotation = Quaternion.Euler(0f, yRotation, 0);
        }

        direction.y -= gravity * Time.deltaTime;
        /*if (isDoubleJumpActive == false)
        {
            direction.y -= gravity;
        }*/


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

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            
            isAimed = true;
            cinemachine.SetActive(false);
            cmAimed.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
           
            isAimed = false;
            cinemachine.SetActive(true);
            cmAimed.SetActive(false);
            //transform.rotation = Quaternion.Euler(0f, yRotation, 0);
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && crouch == false && isAimed==false)
        {
            direction.x *= speed*2.5f;
            direction.y *= speed;
            direction.z *= speed * 2.5f;
            direction = transform.transform.TransformDirection(direction);
            controller.Move(direction * Time.deltaTime);
        }
        else
        {
            direction *= speed;
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

