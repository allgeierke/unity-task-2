using Scripts;
using UnityEngine;
using UnityEngine.UI;


public class Collect : MonoBehaviour
{
    private int coinCounter;
    //Textfield for score
    public Text scoreText;
    //Textfield for highscore
    public Text highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        //set score to 0
        coinCounter = 0;
        
        //Load highscore using the key "highscore"
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //If player collides with a objects, using the coin tag then...
        if (other.tag == "Coin")
        {
            //increase score by 1
            coinCounter++;
            //destroy the coin
            Destroy(other.gameObject);
            //update the text
            scoreText.text = "Score: " + coinCounter;
            //Send a debug message(was for testing purpose
            Debug.Log("Coin counter: " + coinCounter);

            //As soon as the coinCounter is bigger than the higherscore..
            if (coinCounter > PlayerPrefs.GetInt("Highscore"))
            {
                //update the highscore actively by the coincounter
                PlayerPrefs.SetInt("Highscore", coinCounter);
                //update the text
                highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
            }

        }

        if (other.tag == "Enemy")
        {
            Debug.Log("ENEMY COLLIDED");
            Debug.Log(other.gameObject.GetComponent<EnemyControl>().enabled);
            
            if (other.gameObject.GetComponent<EnemyControl>().enabled == false)
            {
                Debug.Log("ENEMY KILLED");
                coinCounter++;
                scoreText.text = "Score: " + coinCounter;
            
                if (coinCounter > PlayerPrefs.GetInt("Highscore"))
                {
                    PlayerPrefs.SetInt("Highscore", coinCounter);
                    highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
                }
            }
        }
    }
}
