using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // necessary for text object 

public class ScoreCounter : MonoBehaviour
{

   
    /// <summary>
    ///  In Enemy class muss noch: ScoreScript.scoreValue += 5; // Bei jedem kill werden 5 punkte gezählt
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
        score.text = "Score" + scoreValue;
    }
}
