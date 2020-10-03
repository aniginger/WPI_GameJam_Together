using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    BoxCollider2D myBoxCollider;
    Vector2 basePosition;

    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] float riseDistance = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();

        basePosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
        StopGate();
    }

    public void Activate()
    {
        myRigidBody.velocity = new Vector2(0, moveSpeed);
    }
    void StopGate()
    {
        if(transform.position.y >= basePosition.y + riseDistance)
        {
            myRigidBody.velocity = new Vector2(0, 0);
        }
    }
}
