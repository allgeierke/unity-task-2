using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Source: https://www.youtube.com/watch?v=JivuXdrIHK0&t=541s
public class PauseMenu : MonoBehaviour
{

    // the game is not paused 
   public static bool PausedGame = false;

    public GameObject pauseMenu;
    // Update is called once per frame

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
            SceneManager.LoadScene("PauseMenu");

     /*   {
                if (PausedGame)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        */
        
    }


    public void Pause()
    {
        // if (Input.GetKeyDown(KeyCode.P)) 
        // SceneManager.LoadScene("PauseMenu");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        // PausedGame = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
       SceneManager.LoadScene("SampleScene");
       

    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Debug.Log("Exit ...");
        Application.Quit();


        // quits the game also in console not only in build

        /* oder  Debug.Log ("You have quit the game");
        if (UnityEditor.EditorApplication.isPlaying == true) {
            UnityEditor.EditorApplication.isPlaying = false;
        } else {
            Application.Quit ();
        }*/
    }
}
    

