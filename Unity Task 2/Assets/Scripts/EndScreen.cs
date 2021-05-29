using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScreen : MonoBehaviour
{
   
   
    public static bool Gameisfinished = false;

    //"Button" in Inspector for the EndMenu
    public GameObject GameEnd;


    void Update()
   {
       
   }

   
    
    //When gameover = Screen is freezed and EndMenu is set true
    
    public void End()
   {
   
       GameEnd.SetActive(true);
       Time.timeScale = 0f;
      
   }

    //When button PlayAgain is pressed, the game/scene will reload from the beginning
    // Game is not freezed
    public void PlayAgain()
    {
    
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }
    
    //When button "Main menu" is pressed, the scene "MainMenu" is on the screen
    public void Menu()
    {
       // Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
