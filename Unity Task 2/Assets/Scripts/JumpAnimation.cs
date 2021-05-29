using System;
using System.Collections;
using UnityEngine;

namespace Scripts
{
    public class JumpAnimation : MonoBehaviour
    {
        //handles depiction of the player character's sprite
        public SpriteRenderer animationSprite;

        // collection of all used sprites for player animation
        [SerializeField] public Sprite[] animations;

        private void Start()
        {
            animationSprite.color = Color.white;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy")) StartCoroutine("AttackAnimation");
        }

        private IEnumerator AttackAnimation()
        {
            animationSprite.sprite = animations[0];
            yield return new WaitForSecondsRealtime(0.2f);
            animationSprite.sprite = animations[1];
            yield return new WaitForSecondsRealtime(0.2f);
            animationSprite.sprite = animations[2];
            yield return new WaitForSecondsRealtime(0.2f);
            animationSprite.sprite = animations[3];
            yield return new WaitForSecondsRealtime(0.2f);
            animationSprite.sprite = animations[4];
            yield return new WaitForSecondsRealtime(0.2f);
            animationSprite.sprite = animations[5];
            yield return null;
        }
    }
}