using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;


    public GameObject cinemachine;
    public GameObject cmAimed;
    private bool isAimed = false;

    public GameObject GroundCheck;
    bool checkG;
    public LayerMask lm;

    public float speed = 6f;
    float runMultipliier = 2;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private float directionY;
    bool isDoubleJumpActive = false;
    public float jump = 5;
    private float jumpMultiplier = 1.5f;
    public float gravity = 9.81f;

    bool crouch;

    [Header("Health")]
    EnemyAI enemyAI;
    public float health = 200;
    public float maxHealth = 200;

    [Header("Anims")]
    public AnimationStateController anims;
    bool swordEquipped;

    [Header("Coins")]
    public int coins;

    [Header("Shield")]
    
    public GameObject shield;
    public float shieldDuration;
    public float shieldMax;
    public float shieldSec;
    public bool shieldIsActive = false;


    // Start is called before the first frame update
    void Start()
    {
        enemyAI = GameObject.Find("Emeny").GetComponent<EnemyAI>();
        anims = GetComponent<AnimationStateController>();
        //cinemachine = GameObject.Find("CM1");
        //cmAimed = GameObject.Find("CM2");
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck = GameObject.Find("GroundCheck");

        //  Cursor.lockState = CursorLockMode.Locked;
        //  Cursor.visible = false;

        checkG = controller.isGrounded;

        //checkG = Physics.CheckSphere(GroundCheck.transform.position, .15f, lm);
        //Debug.Log(checkG);

        CalculatingMovement();
        Health();
    }
    void CalculatingMovement()
    {

        swordEquipped = anims.swordIsEquipped;
        if (swordEquipped == true)
        {
            if (true)
            {

            }

            runMultipliier = 4f;
        }
        else runMultipliier = 2.5f;
        crouch = anims.CrouchIsEnabled();

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        float yRotation = cam.transform.localEulerAngles.y;//+ 180;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, yRotation, ref turnSmoothVelocity, turnSmoothTime);

        if (direction.magnitude >= 0.1f && isAimed == false)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        if (isAimed == true)
        {
            transform.rotation = Quaternion.Euler(0f, yRotation, 0);
        }


        /*if (checkG == false)
        {
            Debug.Log("checkG=false");
            
            
        }*/
        direction.y -= Time.deltaTime * gravity;
        //directionY = .1f;

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

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && crouch == false && isAimed == false)
        {
            direction.x *= speed * runMultipliier;
            //direction.y *= speed;
            direction.z *= speed * runMultipliier;
            direction = transform.transform.TransformDirection(direction);
            controller.Move(direction * Time.deltaTime);
        }
        else
        {
            direction *= speed;
            direction = transform.transform.TransformDirection(direction);
            controller.Move(direction * Time.deltaTime);
        }

        if (Input.GetKeyDown("2") && !shieldIsActive)
        {
            StartCoroutine(ShieldDuration());
        }
        if (!shieldIsActive && shieldDuration < shieldMax)
        {
            shieldDuration += .1f;
            
        }

    }
    public void Health()
    {
        if (shieldIsActive)
        {
            shieldDuration -= enemyAI.DamageToPlayer();
        }
        else health -= enemyAI.DamageToPlayer();

        //Debug.Log(health);
    }
    public bool GCheck()
    {
        return checkG;
    }

    public bool DoubleJump()
    {
        return isDoubleJumpActive;
    }
    IEnumerator ShieldDuration()
    {
        shield.SetActive(true);
        shieldIsActive = true;
        yield return new WaitForSeconds(shieldSec);
        if (shieldDuration <= 0) 
        {
            shieldIsActive = false;
            shield.SetActive(false);
            shieldDuration = 0;
            
        }
        shieldIsActive = false;
        shield.SetActive(false);
        
    }
}

