using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    BoxCollider2D myBoxCollider;
    SpriteRenderer myRenderer;
    [SerializeField] float waterfallSpeed = -3f;

    //player properties
    public Player player1;
    Player player1Script;
    public Player player2;
    Player player2Script;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        myRenderer = GetComponent<SpriteRenderer>();

        player1Script = player1.GetComponent<Player>();
        player2Script = player2.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        DropPlayer();
    }

    void DropPlayer()
    {
        if (player1Script.myFeet.IsTouchingLayers(LayerMask.GetMask("Waterfall")) && !player1Script.isGrounded)
        {
            player1Script.myRigidBody.velocity = new Vector2(0, waterfallSpeed);
        }

        if (player2Script.myFeet.IsTouchingLayers(LayerMask.GetMask("Waterfall")) && !player2Script.isGrounded)
        {
            player2Script.myRigidBody.velocity = new Vector2(0, waterfallSpeed);
        }
    }

    public void StopWaterfall()
    {
        myBoxCollider.enabled = false;
        myRenderer.enabled = false;
    }
    public void StartWaterfall()
    {
        myBoxCollider.enabled = true;
        myRenderer.enabled = true;
    }
}
