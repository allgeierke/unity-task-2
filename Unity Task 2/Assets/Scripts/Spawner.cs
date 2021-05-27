using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;
    float randomX;
    Vector2 whereToSpawn;

    public float spawnRate =2f;
    float nextSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randomX = Random.Range(41.0f, 52.0f);
            whereToSpawn = new Vector2(randomX, transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }        
    }
}
