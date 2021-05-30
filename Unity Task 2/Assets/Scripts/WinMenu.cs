using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinMenu : MonoBehaviour

{
    
    public GameObject GameWin;
    // Start is called before the first frame update
    
    //Game stops (and we win)
    public void End()
    {
   
        GameWin.SetActive(true);
        Time.timeScale = 0f;
      
    }

    //Play again button starts our game from beginning
    public void PlayAgain()
    {
        //  GameEnd.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }
    
    //Main menu button shows our main menu
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

