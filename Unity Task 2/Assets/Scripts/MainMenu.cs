using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Source: https://www.youtube.com/watch?v=zc8ac_qUXQY
public class MainMenu : MonoBehaviour

// If "Play" is pressed the game will start and we see our Scene
{
  public void Play()
  {
    SceneManager.LoadScene("SampleScene");
  }

  // If "Quit" is pressed, the game will not start and we will see a message in the console that we quit the game
  public void Quit()
  {
    Debug.Log("You Quit!");
    Application.Quit();
  }
}
