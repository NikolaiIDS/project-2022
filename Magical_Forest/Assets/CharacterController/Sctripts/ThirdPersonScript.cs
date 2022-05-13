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

    public int damageDealt;
    public bool hitIsEnabled = true;
    public int health = 200;
    public int maxHealth = 200;

    [Header("Anims")]
    public AnimationStateController anims;
    bool swordEquipped;
    public float Distance;
    public GameObject lookAtEnemy;
    public GameObject Neck;

    [Header("Coins")]
    public int coins;

    [Header("Shield")]

    public GameObject shield;
    public float shieldDuration;
    public int shieldMax;
    public int shieldSec;
    public bool shieldIsActive = false;
    private bool isExtraHitAllowed = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyHit")
        {
            //Debug.Log("YES");
            if (hitIsEnabled)
            {
                damageDealt = 30;
                Health();
                hitIsEnabled = false;
                damageDealt = 0;
            }
            else if (!hitIsEnabled)
            {
                hitIsEnabled = true;
            }
        }
        else if (other.gameObject.tag != "EnemyHit")
        {
            //Debug.Log("NO");
            hitIsEnabled = true;
        }
        if (other.gameObject.tag == "EnemySpikes")
        {
            //Debug.Log("Hits");
            damageDealt = 10;
            Health();
            damageDealt = 0;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            //coins += other.gameObject.GetComponent<CoinBagScript>().coins;
            Destroy(collision.gameObject);
            coins++;
            Debug.Log("Coin collides");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        health = data.health;
        coins = data.coins;

        Physics.IgnoreLayerCollision(10, 12);
        Physics.IgnoreLayerCollision(10, 10);
        Physics.IgnoreLayerCollision(12, 12);
        Physics.IgnoreLayerCollision(7, 12);
        Physics.IgnoreLayerCollision(7, 10);
        Physics.IgnoreLayerCollision(7, 14);



        anims = GetComponent<AnimationStateController>();
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
        //Debug.Log(damageDealt);


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
            direction.z *= runMultipliier;
            direction *= speed;
            //direction.y *= speed;
            //direction.z *= speed * runMultipliier;
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
            shieldDuration += 15*Time.deltaTime;
        }
        if (shieldDuration > shieldMax)
        {
            shieldDuration = shieldMax;
        }

        /*Distance = Vector3.Distance(lookAtEnemy.transform.position, this.transform.position);
        if (Distance >= 40)
        {
            Neck.transform.LookAt(lookAtEnemy.transform.position);
        }*/
    }

    /*public void DamageIsDealt(float value)
    {
        damageDealt = value;
    }*/
    public void Health()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (shieldIsActive)
        {
            shieldDuration -= damageDealt;

            if (shieldDuration - damageDealt <= 0 && isExtraHitAllowed)
            {
                int extraDamage = damageDealt - (int)shieldDuration;
                shieldDuration -= shieldDuration;
                health -= extraDamage;
                isExtraHitAllowed = false;
                shieldIsActive = false;
                shield.SetActive(false);

                StopCoroutine(ShieldDuration());

                StartCoroutine(ShieldCooldown());

            }
        }
        else health -= damageDealt;
        if (health < 0) 
        {
            health = 0;
        }
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
        isExtraHitAllowed = true;
        yield return new WaitForSeconds(shieldSec);

        shield.SetActive(false);
        StartCoroutine(ShieldCooldown());

    }
    IEnumerator ShieldCooldown()
    {
        if (!shield.activeSelf && shieldIsActive)
        {
            yield return new WaitForSeconds(2);
            shieldIsActive = false;
        }
    }
}

