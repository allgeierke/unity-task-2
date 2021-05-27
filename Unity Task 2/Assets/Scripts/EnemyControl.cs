using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyControl : MonoBehaviour
{
    public int amount;

   /* public float moveSpeed = 3f;

    Transform leftWay, rightWay;
    Vector3 localScale;
    bool movingRight = true;
    Rigidbody2D rb;*/
    
    // Start is called before the first frame update
    void Start()
    {
        /* localScale = transform.localScale;
         rb = GetComponent<Rigidbody2D>();
         leftWay = GameObject.Find("LeftWay").GetComponent<Transform>();
         rightWay = GameObject.Find("RightWay").GetComponent<Transform>();
     
 */
    }

    // Update is called once per frame
    void Update()
    {
/*
        if (transform.position.x > rightWay.position.x)
            movingRight = false;
        if (transform.position.x > leftWay.position.x)
            movingRight = true;

        if (movingRight)
            moveRight();
        else
            moveLeft();*/
        // amount = Enemy.Count;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // This scene HAS TO BE IN THE BUILD SETTINGS!!!
            SceneManager.LoadScene("EndMenu");
                

        }
    }
/*
    public void moveRight()
    {
        movingRight = true;
        localScale.x = 1f;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);
    }
    
    public void moveLeft()
    {
        movingRight = false;
        localScale.x = -1f;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);
    }*/
}