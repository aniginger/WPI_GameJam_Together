using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    bool active = true;

    public bool forGate;
    public bool forBridge;
    public bool forElevator;
    public bool forWaterfall;
    public bool forFire;

    CapsuleCollider2D myCapsuleCollider;
    Rigidbody2D myRigidbody;

    //Activate items
    public GameObject gate;
    Gate gateScript;
    public GameObject bridge;
    Bridge bridgeScript;
    public GameObject elevator;
    Elevator elevatorScript;
    public GameObject waterfall;
    Waterfall waterfallScript;
    public GameObject fire;

    // Start is called before the first frame update
    void Start()
    {
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
        if (forWaterfall)
        {
            waterfallScript = waterfall.GetComponent<Waterfall>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetPressed();
    }

    void GetPressed()
    {
        if (myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            if (active)
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
                if (forWaterfall)
                {
                    waterfallScript.StopWaterfall();
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
            active = false;
        }
    }
}

