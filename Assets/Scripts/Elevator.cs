using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    BoxCollider2D myBoxCollider;
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] float finalYPos;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StopElevating();
    }

    public void Activate()
    {
        myRigidBody.velocity = new Vector2(0, moveSpeed);
    }
    void StopElevating()
    {
        if(transform.position.y >= finalYPos)
        {
            myRigidBody.velocity = new Vector2(0, 0);
        }
    }
}
