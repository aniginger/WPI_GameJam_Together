using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    public bool forGate;
    public bool forBridge;
    public bool forElevator;
    public bool forFire;

    BoxCollider2D myBoxCollider;
    CapsuleCollider2D myCapsuleCollider;
    Rigidbody2D myRigidbody;

    //Activate items
    public GameObject gate;
    Gate gateScript;
    public GameObject bridge;
    Bridge bridgeScript;
    public GameObject elevator;
    Elevator elevatorScript;
    public GameObject fire;

    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();

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
    }

    // Update is called once per frame
    void Update()
    {
        GetPressed();
    }

    void GetPressed()
    {
        if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            if (!myBoxCollider.isTrigger)
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
            myBoxCollider.isTrigger = true;
            myCapsuleCollider.isTrigger = true;
        }
    }
}

