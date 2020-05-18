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
    [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);


    //State
    bool isAlive = true; // state is alive

    // cached component references
    SpriteRenderer playerSprite;
    Rigidbody2D MyRigidBody { get; set; }
    Animator MyAnimator { get; set; }
    CapsuleCollider2D MyBodyCollider { get; set; }
    BoxCollider2D MyFeetCollider { get; set; }



    // Start is called before the first frame update
    void Start()
    {
        MyRigidBody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        MyAnimator = GetComponent<Animator>();
        MyBodyCollider = GetComponent<CapsuleCollider2D>();
        MyFeetCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlive) { return; }
        acceleration = Input.GetAxisRaw("Horizontal");
        Run();
        Jump();
        FlipSprite();
        Die();
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

    private void Die()
    {
        if (MyBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            MyAnimator.SetTrigger("Die");
            GetComponent<Rigidbody2D>().velocity = deathKick;
            isAlive = false;
        }
    }

    private void Jump()
    {
        if (!MyFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
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
