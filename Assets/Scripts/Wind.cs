using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public bool windActive;
    [SerializeField] float windSpeed = 2f;

    public GameObject player1;
    Player player1Script;
    public GameObject player2;
    Player player2Script;

    // Start is called before the first frame update
    void Start()
    {
        player1Script = player1.GetComponent<Player>();
        player2Script = player2.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivateWind();
    }

    void ActivateWind()
    {
        if (windActive)
        {
            player1Script.windSpeed = windSpeed;
            player2Script.windSpeed = windSpeed;
        }
        else
        {
            player1Script.windSpeed = 0;
            player2Script.windSpeed = 0;
        }
    }
}
