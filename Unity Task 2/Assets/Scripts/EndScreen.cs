using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScreen : MonoBehaviour
{
   
   
    public static bool Gameisfinished = false;

    public GameObject GameEnd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            SceneManager.LoadScene("EndMenu");

        
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
