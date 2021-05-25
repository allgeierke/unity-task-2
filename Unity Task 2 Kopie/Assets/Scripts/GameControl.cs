using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for more info on the the OnEnable and Update methods
//see: https://docs.unity3d.com/Manual/ExecutionOrder.html

namespace Scripts
{
    public class GameControl : MonoBehaviour
    {
        [SerializeField] public PlayerControl playerControl;

        //determines if the game has been started
        public bool gameRunning;

        private float startingTime;

        // Start = called before the first frame update
        void Start()
        {
            //mark game as having started in the beginning
            gameRunning = true;

            playerControl.enabled = true;
        }

        //onEnable = Unity runtime function called after game component is enabled
        public void OnEnable()
        {
            //mark game as running upon enabling
            //gameRunning = true;
            Debug.Log("Game has started!");
            //initialize starting time to be assessed time
            startingTime = Time.time;
        }

        //onDisable = Unity runtime function called after game component is disabled
        private void OnDisable()
        {
            //if script is disabled, game is marked as stopped (really needed though?)
            //gameRunning = false;
        }

        // Update is called once per frame
        public void Update()
        {
            //if the game is running, press 1 to end it
            if (gameRunning!)
            { 
                //don't accept player input if the game is not running anymore
                // if (plCon.playerActing) plCon.playerActing = false;
            }

            if (gameRunning)
            {
                //test for checking if game is actually running
                //Debug.Log("Game is running.");

                //end game if "1" is pressed
                if (Input.GetKey(KeyCode.Alpha1))
                {
                    gameRunning = false;
                    playerControl.enabled = false;
                    Debug.Log("Game ended!");
                }
            }
        }
    }
}