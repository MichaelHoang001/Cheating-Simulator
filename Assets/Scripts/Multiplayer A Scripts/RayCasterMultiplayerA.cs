using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System;
using UnityEngine.UI;

public class RayCasterMultiplayerA : MonoBehaviour
{


    public Camera p1_cam;                   //Camera for player 1
    public Camera p2_cam;                   //Camera for player 2
    public bool isCheating_flag = false;    //If any player is cheating this is true
    public bool p1_isCheating = false;      //If only player 1 is cheating
    public bool p2_isCheating = false;      //If only plater 2 is cheating
    public GameObject lefttest;             //The test to the left of player 2
    public GameObject righttest;            //The test to the right of player 1
    public GameObject lefttest_answer_text; //Accompany text
    public GameObject righttest_answer_text;//Accompany text
	public GameObject game_manager;

    // Use this for initialization
    void Start()
    {
		//round_number = GlobalControl.Instance.round;
        lefttest = GameObject.Find("Other Student Tests (10)");
        righttest = GameObject.Find("Other Student Tests");
    }

    //This is now used for cheating button, if it is possitive you are cheating
    public float dpady;
	public bool gamestarted = false;
	public bool dpad_up = false;
    // Update is called once per frame
    void Update()
    {
		if (gamestarted) {
			dpady = Input.GetAxis ("D-Pad Y Axis");
			if (dpady > 0) {
				dpad_up = true;
			}

            //Axis cannot be booleans, so this is making it boolean value
			if (Input.GetKeyUp (KeyCode.Space) || dpady < 0) {
				dpad_up = false;
			}

			
			//If Player 1 holds down the dpad then the right test is shown
			if (dpad_up || Input.GetKey(KeyCode.M)) {

				//This is for tests to the right of Player 1
				righttest.transform.rotation = p1_cam.transform.rotation;
                p1_isCheating = true;

				//Show the answer on the classmates tests
				righttest_answer_text.SetActive (true);
				
			}
            else
            {
                p1_isCheating = false;
                righttest_answer_text.SetActive(false);
            }

            //When you look at it, the test moves so it is easier to see
            //If Player 2 holds down the space bar then the left test is shown
            if (Input.GetKey(KeyCode.Space))
            {

                //This is for tests to the right of you
                lefttest.transform.rotation = p2_cam.transform.rotation;
                p2_isCheating = true;

                //Show the answer on the classmates tests
                lefttest_answer_text.SetActive(true);
            }
            else {
                p2_isCheating = false;
				//Don't show the answer unless you are holding down the cheating button	
				lefttest_answer_text.SetActive (false);
			}

            if (p1_isCheating || p2_isCheating)
            {
                isCheating_flag = true;
            }
            else
            {
                isCheating_flag = false;
            }
		}
    }
}