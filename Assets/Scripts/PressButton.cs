using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    BoxCollider2D myBoxCollider;
    CapsuleCollider2D myCapsuleCollider;
    Rigidbody2D myRigidbody;

    //Activate gate
    public GameObject gate;
    Gate gateScript;

    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();

        gateScript = gate.GetComponent<Gate>();
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
                gateScript.LiftGate();
            }
            myBoxCollider.isTrigger = true;
            myCapsuleCollider.isTrigger = true;
        }
    }

}
