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
                    
                    //where enemies spawn
                    nextSpawn = Time.time + spawnRate;
                    randomX = Random.Range(40, 43);
                    whereToSpawn = new Vector2(randomX, transform.position.y-3.7f);
                    Instantiate(enemy, whereToSpawn, Quaternion.identity);
                    amount++;
                }
            }
        }
    }
        
       
    

   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Player")) ;
        triggered = true;
    }
   
}