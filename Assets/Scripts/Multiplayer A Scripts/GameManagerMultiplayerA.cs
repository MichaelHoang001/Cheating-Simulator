using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManagerMultiplayerA : MonoBehaviour {
    public int number_of_test_questions = 3; //Need to change this later

    public bool p1test_over = false;
    public bool p2test_over = false;
    public bool test_over = false;
    public bool all_test_questions_complete = false;
    public bool caught_cheating = false;
    public bool print_this = true;
   
    public string[] player_test_answers;
    public List<Tuple> p1inputted_answers = new List<Tuple>();
    public List<Tuple> p2inputted_answers = new List<Tuple>();
    public GameObject canvas;   //contains the testdisplay script
	public GameObject fpscontroller;
	public GameObject readyscreen;
	public GameObject teacher;
	public GameObject teachervision;
    public Text test_results;
    public Text p2test_results;



    // Use this for initialization
    void Start () {
		
        player_test_answers = new string[number_of_test_questions];
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.F9)){
			canvas.GetComponent<DisplayTestQuestionMultiplayerA> ().gamestarted = true;
			fpscontroller.GetComponent<RayCasterMultiplayerA> ().gamestarted = true;
			teacher.GetComponent<TeacherMovement> ().gamestarted = true;
			teachervision.GetComponent<TeacherVisionScript> ().gamestarted = true;
			readyscreen.SetActive (false);
		}

            /*IF the player finishes the test*/
            if (p1test_over)
            {
                if (print_this)
                {
                    setFalse(); //Only print once

                    /*Turn off the test display*/
                    canvas.GetComponent<DisplayTestQuestionMultiplayerA>().turnOffP1Display();

                    /*Show results*/
                    test_results.enabled = true;
					//test_results.text = "Test Over" + System.Environment.NewLine + "Number of questions correct: " + GetComponent<TestGrader>().GradeTest();
					test_results.text = "You finished all of your questions" + System.Environment.NewLine;
                }
            }

            /*IF the player finishes the test*/
            if (p2test_over)
            {
                if (print_this)
                {
                    setFalse(); //Only print once

                    /*Turn off the test display*/
                    canvas.GetComponent<DisplayTestQuestionMultiplayerA>().turnOffP2Display();

                    /*Show results*/
                    // test_results.enabled = true;
                    //test_results.text = "Test Over" + System.Environment.NewLine + "Number of questions correct: " + GetComponent<TestGrader>().GradeTest();
                    p2test_results.text = "You finished all of your questions" + System.Environment.NewLine;
                }
            }

            /*If the player is caught cheating*/
            if (caught_cheating)
            {
                if (print_this)
                {
                    setFalse(); //Only print once

                    /*Turn off the test display*/
                    canvas.GetComponent<DisplayTestQuestionMultiplayerA>().turnOffP1Display();
                    canvas.GetComponent<DisplayTestQuestionMultiplayerA>().turnOffP2Display();
                    /*Show results*/
                    test_results.enabled = true;
					test_results.text = "You were caught cheating!" + System.Environment.NewLine + "Try again next time." + System.Environment.NewLine + "Wait for Next Round";
                }
            }
        
	}

    void setFalse()
    {
        print_this = false;
    }


}
