using System;
using System.Collections;
using UnityEngine;

namespace Scripts
{
    public class BootsControl : MonoBehaviour
    {
        public GameObject attachedPlayer;

        //handles depiction of the boot attack's sprites
        public SpriteRenderer renderer;

        // collection of all used sprites for the boot attack
        [SerializeField] public Sprite[] animations;

        // determines area of player feet for ground collision detection
        public Transform jumpArea;

        // determine strength of player jumping
        public float jumpForce;

        // mask with all tiles the player can stand on
        public LayerMask canStandOn;

        // determines whether player is currently in the air
        public bool isAirborne;
        
        public AudioSource jumpSound;

        public AudioSource AttackSound;

        
        private void Start()
        {
            // color of the attack animation
            renderer.color = Color.white;
            jumpForce = 5f;
        }

        private void Update()
        {
            // if the player character stands on solid ground
            if (!IsAirborne() && Input.GetButtonDown("Jump"))
            {
                    // calculate player jump
                    jumpSound.Play();
                    StartCoroutine(Jump());
                    StartCoroutine(JumpAnimation());

            }

            if (IsAirborne())
            {
                attachedPlayer.GetComponent<PlayerControl>().renderer.sprite = attachedPlayer.GetComponent<PlayerControl>().animations[14];

            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            // if an enemy is hit with the boots
            if (other.CompareTag("Enemy"))
            {
                // jump again
                StartCoroutine("Jump");
                
                AttackSound.Play();
                // show blaster animation
                StartCoroutine("AttackAnimation");
                // kill enemy
                other.gameObject.GetComponent<EnemyControl>().StartCoroutine("EnemyDeath");
            }
            else if (!IsAirborne() && Input.GetButtonDown("Jump")) StartCoroutine("AttackAnimation");
        }

        private IEnumerator AttackAnimation()
        {
            // PLAY ATTACK SOUND

            // go through sprites with adequate waiting time in between
            for (int n = 0; n <= 5; n++)
            {
                renderer.sprite = animations[n];
                yield return new WaitForSecondsRealtime(0.1f);
            }

            yield return null;
        }

        private IEnumerator JumpAnimation()
        {
            //start loop and use animation at index n
            for (int n = 6; n <= 10; n++)
            {
                renderer.sprite = animations[n];
                //wait
                yield return new WaitForSecondsRealtime(0.1f);
            }

            yield return null;
        }

        private IEnumerator Jump()
        {
            // adjust player animation
           
            // get current velocity from player
            float currentVelocity = attachedPlayer.GetComponent<PlayerControl>().body.velocity.x;

            // jump movement calculated by body's velocity and chosen jump force
            attachedPlayer.GetComponent<PlayerControl>().body.velocity = new Vector2(currentVelocity, jumpForce);

            // if not in the air, stop the coroutine
            if (!isAirborne) StopCoroutine(Jump());
            
            yield return null;
        }

        public bool IsAirborne()
        {
            // check if any ground tile collides with the players' feet
            Collider2D collisionWithGround = Physics2D.OverlapCircle(jumpArea.position, 0.2f, canStandOn);

            // if no collision of the feet with the ground was detected
            if (collisionWithGround == null)
            {
                return true;
            }

            return false;
        }

    }
}