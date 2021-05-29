using System;
using System.Collections;
using UnityEngine;

namespace Scripts
{
    public class BootsControl : MonoBehaviour
    {
        //handles depiction of the boot attack's sprites
        public SpriteRenderer renderer;

        // collection of all used sprites for the boot attack
        [SerializeField] public Sprite[] animations;

        private void Start()
        {
            // color of the attack animation
            renderer.color = Color.white;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            // if an enemy is hit with the boots
            if (other.CompareTag("Enemy")) StartCoroutine("AttackAnimation");
        }

        private IEnumerator AttackAnimation()
        {
            // go through sprites with adequate waiting time in between
            for (int n = 0; n <=5; n++)
            {
                renderer.sprite = animations[n];
                yield return new WaitForSecondsRealtime(0.1f);
            }
           
            yield return null;
        }
    }
}