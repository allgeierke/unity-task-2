using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Scripts
{
    public class PlayerControl : MonoBehaviour
    {
        private int time = 0;
        
        //input for game control from player-chosen action
        public Action playerAction;

        //decides if player input is accepted
        public bool playerActing;
        
        //handles character position in level
        public Transform playerPos; 
        
        //handles depiction of the player character's sprite
        public SpriteRenderer playerSprite;

        [SerializeField]   public Sprite[] animations;
        
        //handles physics of the player character's body
        public Rigidbody2D body;
        
        public float speed;
        private float move_x;

        // determine strength of player jumping
        public float jumpForce = 5f;

        public Transform playerFeet;

        public LayerMask jumpPlatform;
        
        
        
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
                Vector3 characterScale = transform.localScale;
                
                //for our Input loads, Unity delivers pre-existing key inputs, which fit the player action

                //determines player movement on x axis based on adequate key input (e.g. A, D)
                move_x = Input.GetAxisRaw("Horizontal");
                
                // if the player character stands on solid ground
                if (!IsAirborne()) {
                    
                    Idle();
                    
                if (Input.GetButtonDown("Jump"))
                {
                    StartCoroutine(Jump());
                }

                // if the player moves in either direction
                
                else if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    Move();
                    
                }

                }
                
                if (Input.GetAxis("Horizontal") < 0)
                {
                    characterScale.x = -5;
                }

                if (Input.GetAxis("Horizontal") > 0)
                {
                    characterScale.x = 5;
                }
                
                transform.localScale = characterScale;
                time++;
                
                //Debug.Log(time);
            }
        }

        private void FixedUpdate()
        {
            Vector2 movement = new Vector2(move_x * speed, body.velocity.y);
            body.velocity = movement;
        }

        private void Idle()
        {
            for (int n = 10; n <= 13; n++)
            {
                if ((time % 4) + 10 == n) playerSprite.sprite = animations[((time % 200)/50)+10];
            }
        }
        private void Move()
        {
            for (int n = 0; n <= 9; n++)
            {
                if (time%10 == n) playerSprite.sprite = animations[(time%300)/30];
            }
        }
        
        private IEnumerator Jump()
        {
            var jumpTime = 0f;
            var jumpDuration = 10f;
            Vector2 movement = new Vector2(body.velocity.x, jumpForce);
            body.velocity = movement;

            while (jumpTime < jumpDuration)
            {
                jumpTime += Time.deltaTime;
                var currentTime = jumpTime / jumpDuration;
                if (currentTime < jumpDuration)
                {
                    
                }
                
            }

            yield return null;
        }

        private IEnumerator GameTest()
        {
            yield return null;
        }

        public bool IsAirborne()
        {
            // check if any ground tile collides with the players' feet
            Collider2D isOnGround = Physics2D.OverlapCircle(playerFeet.position, 0.5f, jumpPlatform);

            // if no collision of the feet with the ground was detected
            if (isOnGround == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}