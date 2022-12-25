using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    #region Variables
    Animator animator;
    [Header("Hand Arrow")]
    public GameObject handArrow;
    public float runSpeed = 12f;
    public float walkSpeed = 8f;
    float speed;
    public float gravity = -9.81f;
    public KeyCode jumpKey = KeyCode.Space;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float pushPower = 2.0F;
    [HideInInspector] public Vector3 movement;
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool isJumping;
    [HideInInspector] public bool vault;
    [HideInInspector] public bool crouch;

    Vector3 velocity;
    CharacterController controller;
    #endregion

    public bool jumpUp
    {
        get { return isJumping; }
        set
        {
            if (isJumping != value)
            {
                isJumping = value;
                // Run some function or event here
            }
        }
    }



    void Start()
    {
        animator = GetComponent<Animator>();
        handArrow.gameObject.SetActive(false);
        controller = GetComponent<CharacterController>();
    }

    public void  HandArrowActivate()
    {
        handArrow.gameObject.SetActive(true);
    }

    public void HandArrowDeactivate()
    {
        handArrow.gameObject.SetActive(false);
    }

    void Jump()
    {
        isJumping = !isGrounded;
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        
        animator.SetBool("isJumping", isJumping);

    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        animator.SetBool("isGrounded", isGrounded);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

    }

    void MoveMent()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        animator.SetFloat("xSpeed", x);
        animator.SetFloat("ySpeed", z);

        movement = transform.right * x + transform.forward * z;
        controller.Move(movement * Time.deltaTime * speed);
        velocity += (Vector3.up * gravity) * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
    }


    void Update()
    {
        GroundCheck();
        Jump();
        MoveMent();

        /*float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        animator.SetFloat("xSpeed", x);
        animator.SetFloat("ySpeed", y);*/

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("run", true);
            speed = runSpeed;
        }
        else
        {
            animator.SetBool("run", false);
            speed = walkSpeed;
        }

        if(Input.GetKey(KeyCode.V) && animator.GetBool("run"))
        {
            animator.SetBool("vault", true);
        }
        else
        {
            animator.SetBool("vault", false);
        }

        

        if(Input.GetKeyDown(KeyCode.C) && isGrounded && !animator.GetBool("run"))
        {
            crouch = !crouch;
        }
        animator.SetBool("crouch", crouch);


        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("aim", true);
        }

        if(Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("aim", false);
            animator.SetBool("shoot", true);
        }
        else
        {
            animator.SetBool("shoot", false);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
            return;

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3f)
            return;

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;
    }
    void DrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }
}
