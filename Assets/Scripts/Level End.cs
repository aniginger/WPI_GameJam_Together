using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    BoxCollider2D myBoxCollider;
    GameObject player1;
    GameObject player2;
    Player player1Script;
    Player player2Script;

    int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();
        player1Script = player1.GetComponent<Player>();
        player2Script = player2.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        NextLevel();
    }

    void NextLevel()
    {
        if(player1Script.myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Level End")) &&
           player2Script.myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Level End")))
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
