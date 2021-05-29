using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyControl : MonoBehaviour
{
    // decides whether the enemy is alive/active or not
    public bool enemyActing;
    // handles rendering of the enemy sprite
    public SpriteRenderer renderer;
    // breathing animation
    public Animator breathing;
    //handles physics of the enemy character's body
    public Rigidbody2D body;
    // enemy's collider
    public BoxCollider2D collider;
    // determines area of enemy feet for ground collision detection
    public Transform edgeDetector;
    // speed of the player character
    [SerializeField] public float speed;
    // left/right movement determined by algorithm in update
    public float movement;
    // mask with all tiles the enemy can stand on
    public LayerMask canStandOn;

    // Start is called before the first frame update
    void Start()
    {
        enemyActing = true;
        speed = 50;
        movement = 1;
        body.velocity = new Vector2(movement * speed * Time.deltaTime, body.velocity.y);

    }

    private void FixedUpdate()
    {
        if (enemyActing)
        {
            if (checkForEdge())
            {
                movement *= -1;
                body.velocity = new Vector2(movement * speed * Time.deltaTime, body.velocity.y);

            }
        }
        
    }

    private IEnumerator EnemyDeath()
    {
        // like literally lol
        breathing.speed = 0;
        // enemy can't act anymore
        enemyActing = false;
        // change to space gravity
        body.gravityScale = 0;
        // unfreeze rotation (no working muscles anymore)
        body.constraints = RigidbodyConstraints2D.None;
        // float away
        body.velocity = new Vector2(body.velocity.x, body.velocity.y-0.2f);
        // allows bumping into player and obstacles
        collider.isTrigger = false;
        // change sprite color (now red for blood/wounds)
        renderer.color = Color.red;
        // disable the script
        this.enabled = false;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        // save character's scale in variable
        Vector3 characterScale = transform.localScale;
        
        // turn enemy sprite left if going left
        if (movement > 0)
        {
            characterScale.x = -5;
        }
        // turn right if going right
        else if (movement < 0)
        {
            characterScale.x = 5;
        }
        
        // update character scale
        transform.localScale = characterScale;

    }
    
    public bool checkForEdge()
    {
        // check if any ground tile collides with the edge detector transform
        Collider2D detectGround = Physics2D.OverlapCircle(edgeDetector.position, 0.5f, canStandOn);

        // if no collision of the detector with the ground was detected
        if (detectGround == null)
        {
            return true;
        }

        return false;
    }

}