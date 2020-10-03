using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerDefend : MonoBehaviour
{
    public bool defending;
    public Collider2D defendTrigger;
    Player playerScript;
    [SerializeField] bool canDefend;

    private void Awake()
    {
        playerScript = GetComponent<Player>();
        defendTrigger.enabled = false;
    }

    private void Update()
    {
        BasicDefend();
    }

    void BasicDefend()
    {
        if (CrossPlatformInputManager.GetButton("Defend") && playerScript.isGrounded && canDefend)
        {
            defending = true;
            defendTrigger.enabled = true;
        }
        else
        {
            defending = false;
            defendTrigger.enabled = false;
        }

        if (!playerScript.isGrounded)
        {
            defending = false;
            defendTrigger.enabled = false;
        }
    }
}
