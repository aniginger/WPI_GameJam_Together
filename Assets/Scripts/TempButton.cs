using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempButton : MonoBehaviour
{

    public bool forWaterfall;

    CapsuleCollider2D myCapsuleCollider;
    Rigidbody2D myRigidbody;

    //Activate items
    public GameObject waterfall;
    Waterfall waterfallScript;

    // Start is called before the first frame update
    void Start()
    {
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();

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
            {
                if (forWaterfall)
                {
                    waterfallScript.StopWaterfall();
                }
            }
        }
        else
        {
            if (forWaterfall)
            {
                waterfallScript.StartWaterfall();
            }
        }
    }
}
