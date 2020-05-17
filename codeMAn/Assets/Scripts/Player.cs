using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    //Running speed before the game start
    [SerializeField]
    float runSpeed = 7f;
    private float acceleration = 0.0f;
    [SerializeField]
    float jumpSpeed = 28f;
    private bool isGrounded;


    //State
    bool isAlive = true; // state is alive

    // cached component references
    SpriteRenderer playerSprite;
    Rigidbody2D MyRigidBody { get; set; }
    Animator MyAnimator { get; set; }
    Collider2D MyCollider2D { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        MyRigidBody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        MyAnimator = GetComponent<Animator>();
        MyCollider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        acceleration = Input.GetAxisRaw("Horizontal");
        Run();
        Jump();
        FlipSprite();
    }


    private void Run()
    {
        //Get the horizontal axis
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value is between -1 to 1

        // Creating velocity
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, MyRigidBody.velocity.y);

        // make velocity to the upper variable velocity
        MyRigidBody.velocity = playerVelocity;

        // running animation
        bool playerMoves = Mathf.Abs(MyRigidBody.velocity.x) > Mathf.Epsilon;
        MyAnimator.SetBool("Running", playerMoves);

    }

    private void Jump()
    {
        if (!MyCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            MyRigidBody.velocity += jumpVelocityToAdd;
        }

        MyAnimator.SetBool("Jumping", MyRigidBody.velocity.y > 0);

    }

    private void FlipSprite()
    {
        if (acceleration > 0)
        {
            playerSprite.flipX = false;

        }
        else if (acceleration < 0)
        {

            playerSprite.flipX = true;

        }

    }
}
