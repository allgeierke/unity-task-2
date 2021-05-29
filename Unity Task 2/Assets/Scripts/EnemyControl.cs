using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyControl : MonoBehaviour
{
    public int amount;

    public bool enemyActing;
    
    public SpriteRenderer enemySprite;
    // collection of all used sprites for player animation
    [SerializeField] public Sprite[] animations;
    //handles physics of the enemy character's body
    public Rigidbody2D body;
    // determines area of enemy feet for ground collision detection
    public Transform enemyFeet;
    // speed of the player character
    [SerializeField] public float speed;
    // left/right movement determined by algorithm in update
    public float direction;
    // variable for counting updates
    public float time;
    // mask with all tiles the enemy can stand on
    public LayerMask canStandOn;

    public BoxCollider2D collider;

    public Animator anim;
    
   /* public float moveSpeed = 3f;
    Transform leftWay, rightWay;
    Vector3 localScale;
    bool movingRight = true;
    Rigidbody2D rb;*/
    
    // Start is called before the first frame update
    void Start()
    {
        enemyActing = true;
        speed = 50;
        direction = 1;
        time = 0;
        body.velocity = new Vector2(direction * speed * Time.deltaTime, body.velocity.y);


        /* localScale = transform.localScale;
         rb = GetComponent<Rigidbody2D>();
         leftWay = GameObject.Find("LeftWay").GetComponent<Transform>();
         rightWay = GameObject.Find("RightWay").GetComponent<Transform>();
     
 */
    }

    private void FixedUpdate()
    {
        if (enemyActing)
        {
            if (checkForEdge())
            {
                direction *= -1;
                body.velocity = new Vector2(direction * speed * Time.deltaTime, body.velocity.y);

            }
        }
        
    }

    private void OnDisable()
    {


    }

    private IEnumerator EnemyDeath()
    {

        anim.speed = 0;
        enemyActing = false;
        body.gravityScale = 0;
        body.constraints = RigidbodyConstraints2D.None;
        body.velocity = new Vector2(body.velocity.x, body.velocity.y-0.2f);
        collider.isTrigger = false;
        enemySprite.color = Color.red;
        this.enabled = false;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        // save character's scale in variable
        Vector3 characterScale = transform.localScale;
    
        // calculates movement with the given x input, the chosen player speed & the body's current velocity
        //if (time % 5 == 0)
        
        
        // turn enemy sprite left if facing left
        if (direction > 0)
        {
            characterScale.x = -5;
        }
        // turn right if facing right
        else if (direction < 0)
        {
            characterScale.x = 5;
        }
        
        // update character scale
        transform.localScale = characterScale;
        
        Debug.Log(direction);
        time ++;
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
    
    public bool checkForEdge()
    {
        // check if any ground tile collides with the players' feet
        Collider2D collisionWithGround = Physics2D.OverlapCircle(enemyFeet.position, 0.5f, canStandOn);

        // if no collision of the feet with the ground was detected
        if (collisionWithGround == null)
        {
            return true;
        }

        return false;
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