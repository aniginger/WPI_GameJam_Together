using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    BoxCollider2D myBoxCollider;
    SpriteRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        myBoxCollider.enabled = true;
        myRenderer.enabled = true;
    }
}
