using UnityEngine;
using UnityEngine.UI;


public class Collect : MonoBehaviour
{
    private int coinCounter;
    public Text scoreText;
    public Text highscoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        coinCounter = 0;
        
        //load highscore
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            coinCounter++;
            Destroy(other.gameObject);
            scoreText.text = "Score: " + coinCounter;
            Debug.Log("Coin counter: " + coinCounter);

            if (coinCounter > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", coinCounter);
                highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
            }

        }
    }
}
