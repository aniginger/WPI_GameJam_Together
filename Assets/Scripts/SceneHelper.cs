using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class SceneHelper : MonoBehaviour
{
    int nextSceneIndex;
    int lastSceneIndex;
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        lastSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForSceneUpdate();
    }

    void CheckForSceneUpdate()
    {
        if(CrossPlatformInputManager.GetButtonDown("Restart Scene"))
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
        if (CrossPlatformInputManager.GetButtonDown("Scene Up"))
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        if (CrossPlatformInputManager.GetButtonDown("Scene Down"))
        {
            SceneManager.LoadScene(lastSceneIndex);
        }
    }
}
