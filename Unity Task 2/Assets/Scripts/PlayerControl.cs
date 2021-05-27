using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Scripts
{
    public class PlayerControl : MonoBehaviour
    {
        //decides if player input is accepted
        public bool playerActing;
        
        // current variable for counting updates. to be replaced
        private float time = 0;
        
        //handles character position in level (unused yet)
        public Transform playerPos; 
        
        //handles depiction of the player character's sprite
        public SpriteRenderer playerSprite;

        //handles physics of the player character's body
        public Rigidbody2D body;
        
        // speed of the player character
        [SerializeField] public float speed;
        
        // left/right movement determined by player input
        private float movement;
        
        // determines area of player feet for ground collision detection
        public Transform playerFeet;

        // determine strength of player jumping
        public float jumpForce = 5f;
        
        // mask with all tiles tagged for allowing jumping
        public LayerMask jumpPlatform;
        
        // collection of all used sprites for player animation
        [SerializeField] public Sprite[] animations;
        
        public void OnEnable()
        {
            playerActing = true;
        }
        
        public void OnDisable()
        {
            playerActing = false;
        }

        private void Update()
        {
            //if the player's not supposed to be acting, don't accept his input
            if (playerActing!)
            {

            }

            if (playerActing)
            {
                // save character's scale in variable
                Vector3 characterScale = transform.localScale;
                
                
                
                // calculates movement with the given x input, the chosen player speed & the body's current velocity
                body.velocity  = new Vector2(movement * speed, body.velocity.y);
                
                // if the player character stands on solid ground
                if (!IsAirborne()) {
                    
                    // load idle animation
                    Idle();
                    
                    //determines player movement on x axis based on adequate key input (e.g. A, D)
                    movement = Input.GetAxisRaw("Horizontal");
                    
                    //for our Input loads, Unity delivers pre-existing key inputs, which fit the player action

                    // if a jump button is pressed
                    if (Input.GetButtonDown("Jump"))
                {
                    // calculate player jump
                    StartCoroutine(Jump());
                }

                // if the player moves in either direction
                    else if (Input.GetAxisRaw("Horizontal") != 0)
                    {
                        // animate movement
                        Move();
                    }
                    // reset x movement when there's no player input
                    else movement = 0;
                    
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
                
                // update character scale
                transform.localScale = characterScale;
                
                // update update method call timer
                time++;
                
                //Debug.Log(time);
            }
        }

        private void FixedUpdate()
        {
            
        }

        private void Idle()
        {
            for (int n = 10; n <= 13; n++)
            {
                if ((int) time % 4 + 10 == n) playerSprite.sprite = animations[(int) (time % 40/10)+10];
            }
        }
        private void Move()
        {
            for (int n = 0; n <= 9; n++)
            {
                if ((int) time%10 == n) playerSprite.sprite = animations[(int) (time%50)/5];
            }
        }
        
        private IEnumerator Jump()
        {
            // jump movement calculated by body's velocity and chosen jump force
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            yield return null;
        }

        public bool IsAirborne()
        {
            // check if any ground tile collides with the players' feet
            Collider2D collisionWithGround= Physics2D.OverlapCircle(playerFeet.position, 0.5f, jumpPlatform);

            // if no collision of the feet with the ground was detected
            if (collisionWithGround == null)
            {
                return true;
            }

            return false;
        }
    }
}