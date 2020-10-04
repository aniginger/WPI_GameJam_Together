using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour

{
    public bool left;
    public bool right;

    [SerializeField] float moveSpeed = 7f;
    Rigidbody2D myRigidBody;
    CircleCollider2D myCircleCollider;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCircleCollider = GetComponent<CircleCollider2D>();

        if (left)
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0);
        }
        if (right)
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0);
        }
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if (myCircleCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")) ||
           myCircleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Destroy(gameObject);
        }
        if(Mathf.Abs(myRigidBody.velocity.x) <= 0.1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
