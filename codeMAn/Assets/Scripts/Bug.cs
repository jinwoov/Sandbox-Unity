using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Bug : MonoBehaviour
{
    [SerializeField]
    float runSpeed = 5f;

    Rigidbody2D MyRigidBody { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        MyRigidBody = GetComponent<Rigidbody2D>();
        Run();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Run()
    {
        //Get the horizontal axis
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value is between -1 to 1

        // Creating velocity
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, MyRigidBody.velocity.y);

        // make velocity to the upper variable velocity
        MyRigidBody.velocity = playerVelocity;
    }
}
