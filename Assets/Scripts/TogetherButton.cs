using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogetherButton : MonoBehaviour
{
    public bool forGate;
    public bool forBridge;
    public bool forFire;

    BoxCollider2D b1BoxCollider;
    CapsuleCollider2D b1CapsuleCollider;
    Rigidbody2D b1Rigidbody;
    BoxCollider2D b2BoxCollider;
    CapsuleCollider2D b2CapsuleCollider;
    Rigidbody2D b2Rigidbody;

    //Activate gate
    public GameObject button1;
    public GameObject button2;
    public GameObject gate;
    Gate gateScript;
    public GameObject bridge;
    Bridge bridgeScript;
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

        if (forGate)
        {
            gateScript = gate.GetComponent<Gate>();
        }
        if (forBridge)
        {
            bridgeScript = bridge.GetComponent<Bridge>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetPressed();
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
