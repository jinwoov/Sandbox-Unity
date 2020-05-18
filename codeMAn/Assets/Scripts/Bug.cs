using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Bug : MonoBehaviour
{
    [SerializeField]
    float runSpeed = .5f;

    Rigidbody2D MyRigidBody { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        MyRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFacingRight())
        {
            MyRigidBody.velocity = new Vector2(runSpeed, 0f);
        }
        else
        {
            MyRigidBody.velocity = new Vector2(-runSpeed, 0f);
        }
    }

    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision);
        transform.localScale = new Vector2(-(Mathf.Sign(MyRigidBody.velocity.x)), 1f);
    }
}
