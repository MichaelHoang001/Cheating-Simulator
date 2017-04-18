using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int number_of_test_questions = 3; //Need to change this later
    public bool test_over = false;
    public bool all_test_questions_complete = false;
    public bool caught_cheating = false;
    public bool print_this = true;
   
    public string[] player_test_answers;
    public List<Tuple> inputted_answers = new List<Tuple>();
    public GameObject canvas;   //contains the testdisplay script
	public GameObject fpscontroller;
	public GameObject readyscreen;
	public GameObject teacher;
	public GameObject teachervision;

    public Text test_results;



    // Use this for initialization
    void Start () {
		
        player_test_answers = new string[number_of_test_questions];
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.F9)){
			canvas.GetComponent<DisplayTestQuestion> ().gamestarted = true;
			fpscontroller.GetComponent<RayCaster> ().gamestarted = true;
			GetComponent<PositionRotationRecording> ().gamestarted = true;
			teacher.GetComponent<TeacherMovement> ().gamestarted = true;
			teachervision.GetComponent<TeacherVisionScript> ().gamestarted = true;
			readyscreen.SetActive (false);
		}

        if (test_over)
        {
            /*IF the player finishes the test*/
            if (all_test_questions_complete)
            {
                if (print_this)
                {
                    setFalse(); //Only print once

                    /*Turn off the test display*/
                    canvas.GetComponent<DisplayTestQuestion>().turnOffDisplay();

                    /*Show results*/
                    test_results.enabled = true;
					//test_results.text = "Test Over" + System.Environment.NewLine + "Number of questions correct: " + GetComponent<TestGrader>().GradeTest();
					test_results.text = "Test Over" + System.Environment.NewLine + "Wait for Next Round";
					GetComponent<PositionRotationRecording> ().RecordNumCorrectQuestions ();
                }

				//restart the scene for another round
				if (GlobalControl.Instance.round != 3) {
					if (Input.GetKeyDown (KeyCode.F9)) {
						GlobalControl.Instance.round = GlobalControl.Instance.round + 1;
						//	GetComponent<PositionRotationRecording> ().round_number = globalcontrol.GetComponent<GlobalControl> ().round;
						//SceneManager.LoadScene("Cheating Demo");
						Application.LoadLevel (Application.loadedLevel);
					}
				}
            }

            /*If the player is caught cheating*/
            if (caught_cheating)
            {
                if (print_this)
                {
                    setFalse(); //Only print once

                    /*Turn off the test display*/
                    canvas.GetComponent<DisplayTestQuestion>().turnOffDisplay();

                    /*Show results*/
                    test_results.enabled = true;
					test_results.text = "You were caught cheating!" + System.Environment.NewLine + "Try again next time." + System.Environment.NewLine + "Wait for Next Round";
					GetComponent<PositionRotationRecording> ().RecordCheated ();
                }
				//restart the scene for another round
				if(GlobalControl.Instance.round != 3){
				if (Input.GetKeyDown (KeyCode.F9)) {
					GlobalControl.Instance.round = GlobalControl.Instance.round + 1;
					//GetComponent<PositionRotationRecording> ().round_number = globalcontrol.GetComponent<GlobalControl> ().round;
					//SceneManager.LoadScene("Cheating Demo");
					Application.LoadLevel(Application.loadedLevel);
					}}
            }
        }
	}

    void setFalse()
    {
        print_this = false;
    }


}
