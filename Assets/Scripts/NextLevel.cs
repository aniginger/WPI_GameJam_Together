using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    int nextSceneIndex;
    BoxCollider2D myBoxCollider;
    public GameObject player1;
    public GameObject player2;
    Player player1Script;
    Player player2Script;


    // Start is called before the first frame update
    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        myBoxCollider = GetComponent<BoxCollider2D>();
        player1Script = player1.GetComponent<Player>();
        player2Script = player2.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        LevelUp();
    }

    void LevelUp()
    {
        if (player1Script.myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Next Level")) &&
           player2Script.myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Next Level")))
        {
            Debug.Log("true");
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}

