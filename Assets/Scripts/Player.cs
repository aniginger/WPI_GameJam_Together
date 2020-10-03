using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    //stat values
    [SerializeField] float maxRunSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float maxFallSpeed = -20f;
    float runSpeed = 0f;

    //common bools
    public bool isGrounded;

    //set up components
    public Rigidbody2D myRigidBody;
    public CapsuleCollider2D myBodyCollider;
    public BoxCollider2D myFeet;
    PlayerDefend defendScript;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        defendScript = GetComponentInChildren<PlayerDefend>();

    }

    // Update is called once per frame
    void Update()
    {
        if (defendScript.defending)
        {
            myRigidBody.velocity = new Vector2(0, 0);
            return;
        }

        CheckSurroundings();
        Run();
        FlipSprite();
        Jump();
    }

    private void CheckSurroundings()
    {
        if (myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (myRigidBody.velocity.y <= maxFallSpeed)
        {
            float currentFallSpeed = myRigidBody.velocity.y;
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, currentFallSpeed);
        }
    }

    private void Run()
    {

        float controlThrow = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        if (Mathf.Abs(controlThrow) > 0)
        {
            runSpeed += 0.6f;
            if (runSpeed >= maxRunSpeed)
            {
                runSpeed = maxRunSpeed;
            }
            myRigidBody.velocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        }
        else
        {
            if (transform.localScale.x > 0)
            {
                myRigidBody.velocity = new Vector2(runSpeed, myRigidBody.velocity.y);
            }
            else if (transform.localScale.x < 0)
            {
                myRigidBody.velocity = new Vector2(runSpeed * -1, myRigidBody.velocity.y);
            }
            if (runSpeed > 0)
                runSpeed -= 1f;
            if (runSpeed <= 0)
            {
                runSpeed = 0;
            }
        }

    }

    private void Jump()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpSpeed);
                if (myRigidBody.velocity.x > 0)
                {
                    transform.localScale = new Vector2(1, 1);
                }
                else if (myRigidBody.velocity.x < 0)
                {
                    transform.localScale = new Vector2(-1, 1);
                }
            }
        }
    }

    private void FlipSprite()
    {
        if (myRigidBody.velocity.x > 0 && (isGrounded || myRigidBody.velocity.y > 0))
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        if (myRigidBody.velocity.x < 0 && (isGrounded || myRigidBody.velocity.y > 0))
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
    }

   
}


