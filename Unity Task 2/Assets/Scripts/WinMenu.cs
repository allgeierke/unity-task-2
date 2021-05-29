using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinMenu : MonoBehaviour

{
    
    public GameObject GameWin;
    // Start is called before the first frame update
    
    public void End()
    {
   
        GameWin.SetActive(true);
        Time.timeScale = 0f;
      
    }

    public void PlayAgain()
    {
        //  GameEnd.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

