using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScreen : MonoBehaviour
{
   
   
    public static bool Gameisfinished = false;

    public GameObject GameEnd;
    
   /* public GameObject avatar1, avatar2;
    private int Alien;
    //private int playerHealth;
    void Start()
    {
        avatar1.gameObject.SetActive(false);
        avatar2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().curHealth;
      // Alien = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyControl>().amount;

        //If health is at 0 the Lose screen pops up and the game will stop
        
        {
            avatar1.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        // And if there are no more asteroids the Win screen shows up and the game stop
        if (Alien == 0)
        {
            avatar2.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }*/
   void Update()
   {
            if (Input.GetKeyDown(KeyCode.M))
            SceneManager.LoadScene("EndMenu");

        
    }
   
   public void End()
   {
   
       GameEnd.SetActive(true);
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
