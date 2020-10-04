using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogetherButton : MonoBehaviour
{
    public bool forGate;
    public bool forBridge;
    public bool forElevator;
    public bool for2Elevators;
    public bool forFire;

    BoxCollider2D b1BoxCollider;
    CapsuleCollider2D b1CapsuleCollider;
    Rigidbody2D b1Rigidbody;
    BoxCollider2D b2BoxCollider;
    CapsuleCollider2D b2CapsuleCollider;
    Rigidbody2D b2Rigidbody;

    //player properties
    public Player player1;
    Player player1Script;
    public Player player2;
    Player player2Script;

    //Activate items
    public GameObject button1;
    public GameObject button2;
    public GameObject gate;
    Gate gateScript;
    public GameObject bridge;
    Bridge bridgeScript;
    public GameObject elevator;
    Elevator elevatorScript;
    public GameObject elevator2;
    Elevator elevator2Script;
    public GameObject fire;

    // Start is called before the first frame update
    void Start()
    {
        b1BoxCollider = button1.GetComponent<BoxCollider2D>();
        b1CapsuleCollider = button1.GetComponent<CapsuleCollider2D>();
        b1Rigidbody = button1.GetComponent<Rigidbody2D>();

        b2BoxCollider = button2.GetComponent<BoxCollider2D>();
        b2CapsuleCollider = button2.GetComponent<CapsuleCollider2D>();
        b2Rigidbody = button2.GetComponent<Rigidbody2D>();

        player1Script = player1.GetComponent<Player>();
        player2Script = player2.GetComponent<Player>();

        if (forGate)
        {
            gateScript = gate.GetComponent<Gate>();
        }
        if (forBridge)
        {
            bridgeScript = bridge.GetComponent<Bridge>();
        }
        if (forElevator)
        {
            elevatorScript = elevator.GetComponent<Elevator>();
        }
        if (for2Elevators)
        {
            elevatorScript = elevator.GetComponent<Elevator>();
            elevator2Script = elevator2.GetComponent<Elevator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        StopPlayer();
        GetPressed();
    }

    void StopPlayer()
    {
        if (player1Script.myFeet.IsTouchingLayers(LayerMask.GetMask("Pressure")) && !player1Script.myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            player1Script.noUpdate = true;
            player1.myRigidBody.velocity = new Vector2(0, 0);
        }
        else
        {
            player1Script.noUpdate = false;
        }
        if (player2Script.myFeet.IsTouchingLayers(LayerMask.GetMask("Pressure")) && !player2Script.myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            player2Script.noUpdate = true;
            player2.myRigidBody.velocity = new Vector2(0, 0);
        }
        else
        {
            player2Script.noUpdate = false;
        }
    }

    void GetPressed()
    {
        if (b1BoxCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && b2BoxCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            if (!b1BoxCollider.isTrigger && !b2BoxCollider.isTrigger)
            {
                if (forGate)
                {
                    gateScript.Activate();
                }
                if (forBridge)
                {
                    bridgeScript.Activate();
                }
                if (forElevator)
                {
                    elevatorScript.Activate();
                }
                if (for2Elevators)
                {
                    elevatorScript.Activate();
                    elevator2Script.Activate();
                }
                if (forFire)
                {
                    IEnumerator WaitToKillFire()
                    {
                        yield return new WaitForSeconds(1f);
                        Destroy(fire);
                    }
                    StartCoroutine(WaitToKillFire());
                }
            }
            b1BoxCollider.isTrigger = true;
            b1CapsuleCollider.isTrigger = true;
            b2BoxCollider.isTrigger = true;
            b2CapsuleCollider.isTrigger = true;
        }
    }

}
