using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //raycast variables
    public Transform wallCheck;
    public bool isTouchingWall;
    bool isGrounded;
    [SerializeField] public float wallCheckDistance = -1.3f;

    public Transform groundCheck;
    public bool isTouchingGround;
    [SerializeField] public float groundCheckDistance = -0.8f;

    //other configs
    Rigidbody2D myRigidBody;
    CapsuleCollider2D myCollider;
    [SerializeField] public float walkSpeed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckSurroundings();
        ChangeDirection();
        Move();
        KillEnemy();
    }

    private void Move()
    {
        if (transform.localScale.x < 0)
        {
            myRigidBody.velocity = new Vector2(-walkSpeed, 0);
        }
        if (transform.localScale.x > 0)
        {
            myRigidBody.velocity = new Vector2(walkSpeed, 0);
        }
    }

    private void ChangeDirection()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Shield")) && !isTouchingGround)
        {
            
        }

        if (isTouchingWall || (!isTouchingGround && myRigidBody.gravityScale > 0))
        {
            float realGroundCheck = groundCheckDistance;
            groundCheckDistance = 0;
            transform.localScale = new Vector2(-transform.localScale.x, 1);
            wallCheckDistance *= -1;
            groundCheckDistance = realGroundCheck;
        }
    }

    public void KillEnemy()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Weapon")))
        {
            Destroy(gameObject);
        }
    }

    private void CheckSurroundings()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, LayerMask.GetMask("Ground"));
        isTouchingGround = Physics2D.Raycast(groundCheck.position, transform.up, groundCheckDistance, LayerMask.GetMask("Ground"));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y + groundCheckDistance, groundCheck.position.z));
    }
}
