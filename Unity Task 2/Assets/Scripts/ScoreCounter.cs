using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // necessary for text object 

public class ScoreCounter : MonoBehaviour
{
    /// <summary>
    ///  In Enemy class muss noch der enemy: ScoreScript.scoreValue += 5; // Bei jedem kill werden 5 punkte gezählt
    ///  für jeden gegner n anderen wert vllt 
    /// </summary>
    public static int scoreValue = 0;

    //creating a connection
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // adding to our "score text object" on display
        score.text = "Score" + scoreValue;
    }
}
