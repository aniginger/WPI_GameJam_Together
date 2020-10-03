using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
   //Function called upon clicking the play button
   public void PlayGame()
   {
      //Loads the next indexed scene in the build settings queue
      //(in this case, menu is of index 0 and the first level is of index 1)
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   //Function called upon clicking the quit button
   public void QuitGame()
   {
      //Debug statement that ensures the game is quit in editor
      Debug.Log("Game was quit poggers");
      //Exit the game
      Application.Quit();
   }

}
