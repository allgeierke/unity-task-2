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
            // anzahl der gespawnten enemies
            if (amount <= 5)
            {
                if (Time.time > nextSpawn)
                {


                    //statt mit time.time evtl wenn finalBoss dead + spawnRate
                    nextSpawn = Time.time + spawnRate;
                    randomX = Random.Range(26, 36);
                    Debug.Log(randomX);
                    whereToSpawn = new Vector2(randomX + 5, transform.position.y);
                    Instantiate(enemy, whereToSpawn, Quaternion.identity);
                    amount++;
                }
            }
        }
    }
        
       
    

   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Spawner")) ;
        triggered = true;
    }
   
}