using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    CapsuleCollider2D myBody;
    BoxCollider2D myFeet;
    Rigidbody2D myRigidBody;

    public bool playerDying;
    Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        myRigidBody = GetComponent<Rigidbody2D>();
        playerScript = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        KillPlayer();
    }

    public void KillPlayer()
    {
        IEnumerator WaitForSceneLoad()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (myBody.IsTouchingLayers(LayerMask.GetMask("Enemy")) || myFeet.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            playerDying = true;
            myRigidBody.gravityScale = 0;
            myRigidBody.bodyType = RigidbodyType2D.Static;
            myBody.isTrigger = true;
            myFeet.isTrigger = true;
            StartCoroutine(WaitForSceneLoad());
        }
    }
}
