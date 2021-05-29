using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//for more info on the the OnEnable and Update methods
//see: https://docs.unity3d.com/Manual/ExecutionOrder.html

namespace Scripts
{
    public class GameControl : MonoBehaviour
    {
        // Start = called before the first frame update
        void Start()
        {

        }
 
        //onEnable = Unity runtime function called after game component is enabled
        public void OnEnable()
        {
            Debug.Log("Game has started!");
        }

        //onDisable = Unity runtime function called after game component is disabled
        private void OnDisable()
        {
            
        }

        // Update is called once per frame
        public void Update()
        {
            //test case if "1" is pressed
                if (Input.GetKey(KeyCode.Alpha1))
                {

                }
                //test case if "2" is pressed
                if (Input.GetKey(KeyCode.Alpha2))
                {

                }
                //test case if "3" is pressed
                if (Input.GetKey(KeyCode.Alpha3))
                {

                }
                
        }
    }
}