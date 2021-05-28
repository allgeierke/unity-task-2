using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Scripts
{
    public class PlayerControl : MonoBehaviour
    {
        //handles depiction of the player character's sprite
        public SpriteRenderer playerSprite;
        // collection of all used sprites for player animation
        [SerializeField] public Sprite[] animations;
        //handles physics of the player character's body
        public Rigidbody2D body;
        // determines area of player feet for ground collision detection
        public Transform playerFeet;
        // speed of the player character
        [SerializeField] public float speed;
        // determine strength of player jumping
        public float jumpForce;
        // left/right movement determined by player input
        public float moveInput;
        // mask with all tiles the player can stand on
        public LayerMask canStandOn;
        // determines whether player is currently in the air
        public bool isAirborne;
        
        // current variable for counting updates. to be replaced
        private float time;
        
        // (Unity functions sorted by order of execution)
        
        // initialization of player object
        private void Start()
        {
            time = 0;
            jumpForce = 5f;
            speed = 200;
            moveInput = 0;
        }
        
        // physics
        private void FixedUpdate()
        {
            // (for our Input loads, Unity delivers pre-existing key inputs, which fit the player action)

            if (!IsAirborne()) {
                
            // calculates movement with the given x input, the chosen player speed & the body's current velocity
            body.velocity = new Vector2(moveInput * speed * Time.deltaTime, body.velocity.y);
            
            
            }
        }
        
        // player input & visuals
        private void Update()
        {
            // save character's scale in variable
            Vector3 characterScale = transform.localScale;
            
            // if the player character stands on solid ground
            if (!IsAirborne())
            {
                //determines player movement on x axis based on adequate key input (e.g. A, D)
                moveInput = Input.GetAxisRaw("Horizontal");
                
                // if a jump button is pressed
                if (Input.GetButtonDown("Jump"))
                {
                    // calculate player jump
                    StartCoroutine(Jump());
                } else {
                    
                    // load idle animation
                StartCoroutine(Idle());
                
                // if the player moves in either direction
                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    // animate movement
                    StartCoroutine(Move());
                    
                }

                // turn player sprite left if facing left
                if (Input.GetAxis("Horizontal") < 0)
                {
                    characterScale.x = -5;
                }
                // turn right if facing right
                else if (Input.GetAxis("Horizontal") > 0)
                {
                    characterScale.x = 5;
                }
                }
            }

            // update character scale
            transform.localScale = characterScale;

            // update update method call timer
            time += 10 * Time.deltaTime;

            //Debug.Log(time);
        }


        private IEnumerator Idle()
        {
            // idle animations from 10 to 13
            for (int n = 10; n <= 13; n++)
            {
                if (moveInput != 0) StopCoroutine(Idle());
                if ((int) time % 4 + 10 == n) playerSprite.sprite = animations[(int) (time % 4) + 10];
            }

            yield return null;
        }

        private IEnumerator Move()
        {
            float start = Time.time;

            // move animations from 0 - 9
            for (int n = 0; n <= 9; n++)
            {
                if (moveInput == 0) StopCoroutine(Move());
                if ((int) time % 10 == n) playerSprite.sprite = animations[(int) (time % 5)];
                
                 //PlayerSprite.sprite = animations[n];
                 //yield return new WaitForSeconds(50f* Time.deltaTime);

            }
            yield return null;
        }

        private IEnumerator Jump()
        {
            // jump movement calculated by body's velocity and chosen jump force
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            if (!isAirborne) StopCoroutine(Jump());
            yield return null;
        }

        public bool IsAirborne()
        {
            // check if any ground tile collides with the players' feet
            Collider2D collisionWithGround = Physics2D.OverlapCircle(playerFeet.position, 0.5f, canStandOn);

            // if no collision of the feet with the ground was detected
            if (collisionWithGround == null)
            {
                return true;
            }

            return false;
        }
    }
}