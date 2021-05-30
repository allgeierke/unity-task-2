using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Scripts
{
    public class PlayerControl : MonoBehaviour
    {
        // determines if player input is accepted
        public bool playerActing;

        // determines character scale
        public Vector3 characterScale;

        //handles depiction of the player character's sprite
        public SpriteRenderer renderer;

        // collection of all used sprites for player animation
        [SerializeField] public Sprite[] animations;

        //handles physics of the player character's body
        public Rigidbody2D body;

        // speed of the player character
        [SerializeField] public float speed;

        // left/right movement determined by player input
        public float moveInput;

        // determines area of player feet for ground collision detection
        public GameObject techBoots;

        public LayerMask jumpableFoes;

        // variable for counting updates
        public float time;

        // (Unity functions sorted by order of execution)

        // initialization of player object
        private void Start()
        {
            playerActing = true;
            time = 0;
            speed = 200;
            moveInput = 0;
        }

        // physics
        private void FixedUpdate()
        {
            // calculates movement with the given x input, the chosen player speed & the body's current velocity
            body.velocity = new Vector2(moveInput * speed * Time.deltaTime, body.velocity.y);
        }

        // player input & visuals
        private void Update()
        {
            if (playerActing)
            {
                // save character's scale in variable
                characterScale = transform.localScale;

                // (for our Input loads, Unity delivers pre-existing key inputs, which fit the player action)
                //determines player movement on x axis based on adequate key input (e.g. A, D)
                moveInput = Input.GetAxisRaw("Horizontal");


                if (techBoots.GetComponent<BootsControl>().IsAirborne() == false)
                {
                    // load idle animation
                    StartCoroutine(Idle());

                    // if the player moves in either direction
                    if (Input.GetAxisRaw("Horizontal") != 0)
                    {
                        // animate movement
                        StartCoroutine(Move());

                    }

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

                // update character scale
                transform.localScale = characterScale;

                // update update method call timer
                time += 10 * Time.deltaTime;

            }

        }


        private IEnumerator Idle()
        {
            // idle animations from 10 to 13
            for (int n = 10; n <= 13; n++)
            {
                if (moveInput != 0) StopCoroutine(Idle());
                if ((int) time % 4 + 10 == n) renderer.sprite = animations[(int) (time % 4) + 10];
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
                if ((int) time % 10 == n) renderer.sprite = animations[(int) (time % 5)];

            }

            yield return null;
        }


        public void OnTriggerEnter2D(Collider2D other)
        {
            Collider2D bootsTouchEnemy = Physics2D.OverlapCircle(techBoots.transform.position, 0.3f, jumpableFoes);

            if (bootsTouchEnemy == null && other.CompareTag("Enemy") && playerActing == true)
            {
                StartCoroutine("PlayerDeath");
            }
            else if (other.CompareTag("Portal"))
            {
                playerWin();
            }
        }

        private void playerWin()
        {
            SceneManager.LoadScene("WinMenu");
        }

        private IEnumerator PlayerDeath()
        {
            playerActing = false;
            body.velocity /= 2;
            body.constraints = RigidbodyConstraints2D.None;

            for (int n = 14; n <= 21; n++)
            {
                renderer.sprite = animations[n];
                yield return new WaitForSecondsRealtime(0.1f);
               
            }
            SceneManager.LoadScene("EndMenu");
            yield return null;

        }
    }
}