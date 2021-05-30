using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;
    float randomX;
    Vector2 whereToSpawn;
    private int amount;
    

    public float spawnRate = 2f;
    public int maximumAmount;

    float nextSpawn = 0.0f;
    bool triggered = false; 

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
   private void FixedUpdate()
    {
        if (triggered)
        {
            // amount and timerate of spawning enemies
            if (amount <= maximumAmount)
            {
                if (Time.time > nextSpawn)
                {
                    
                    //where/when enemies spawn
                    nextSpawn = Time.time + spawnRate;
                    //random x value on the plattform
                    randomX = Random.Range(40, 43);
                    //location for the prefab to spawn
                    whereToSpawn = new Vector2(randomX, transform.position.y-3.7f);
                    //spawn it
                    Instantiate(enemy, whereToSpawn, Quaternion.identity);
                    //increase amount/counter for the maximum amount comparison
                    amount++;
                }
            }
        }
    }
        
       
    

   private void OnTriggerEnter2D(Collider2D other)
   {
       //If player collides/enters the certain game object
       if (other.CompareTag("Player"))
       {
           //Set triggered to true
           triggered = true;
       }
   }
   
}