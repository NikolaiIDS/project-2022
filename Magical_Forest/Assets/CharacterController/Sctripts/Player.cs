using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    private AnimationPlayer anims;
    private Animator _animator;
    public GameObject GroundCheck;

    public LayerMask lm;

    [SerializeField]
    private float speed = 3.5f;
    [SerializeField]
    private float gravity = 9.81f;
    [SerializeField]
    private float jump = 5;
    [SerializeField]
    private float jumpMultiplier = 2;

    bool isDoubleJumpActive = false;
    bool checkG;
    bool crouch = false;
    private float directionY;


    // Start is called before the first frame update
    void Start()
    {
        GroundCheck = GameObject.Find("GroundCheck");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

        controller = GetComponent<CharacterController>();
        anims = GameObject.Find("PlayerAnim").GetComponent<AnimationPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        checkG = Physics.CheckSphere(GroundCheck.transform.position, 0.5f, lm);
        CalculateMovement();
    }
    void CalculateMovement()
    {
        crouch = anims.CrouchAnimation();
        //Debug.Log(crouch);
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 velocity = direction * speed;

        velocity.y -= gravity;

        Vector3 velocityX2 = direction * (speed * 2);
        velocityX2.y -= gravity;

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && crouch == false)
        {
            velocity = velocityX2;
        }

        if (checkG == true && crouch == false)
        {
            isDoubleJumpActive = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                directionY = jump;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && isDoubleJumpActive == true)
            {
                directionY = jump * jumpMultiplier;
                isDoubleJumpActive = false;
            }
        }

        directionY -= Time.deltaTime * gravity;
        velocity.y = directionY;

        velocity = transform.transform.TransformDirection(velocity);
        controller.Move(velocity * Time.deltaTime);
    }
}
