using UnityEngine;
using UnityEngine.UI;


public class Collect : MonoBehaviour
{
    private int coinCounter;
    //Textfeld für Score
    public Text scoreText;
    //Textfeld für Highscore
    public Text highscoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        //Score auf 0 setzen
        coinCounter = 0;
        
        //Highscore laden mit dem Key "Highscore"
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Wenn Player mit einen Object mit dem Tag "Coin" collided, dann....
        if (other.tag == "Coin")
        {
            //erhöhe den Score um 1
            coinCounter++;
            //zerstöre das Objekt
            Destroy(other.gameObject);
            //Aktualisiere den Text
            scoreText.text = "Score: " + coinCounter;
            //Send eine Debug-Message aus
            Debug.Log("Coin counter: " + coinCounter);

            //Sobald der Coincounter höher als der Highscore ist
            if (coinCounter > PlayerPrefs.GetInt("Highscore"))
            {
                //aktualisiere ihn aktiv um den coinCounter
                PlayerPrefs.SetInt("Highscore", coinCounter);
                //aktualisiere den Text
                highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
            }

        }
    }
}
