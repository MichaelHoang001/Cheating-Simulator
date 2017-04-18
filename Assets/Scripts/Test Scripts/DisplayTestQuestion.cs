using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DisplayTestQuestion : MonoBehaviour {
    public Text questionTextObject;

    public Text answer1TextObject;
    public Text answer2TextObject;
    public Text answer3TextObject;
    public Text answer4TextObject;

    public Text A_label;
    public Text B_label;
    public Text C_label;
    public Text D_label;

    public GameObject characterTestPaper;
    public GameObject gameManager;

    public int question_number = 0;
    public int pick_a_question;
    public List<int> clone_of_userTestQuestions = new List<int>();
    public List<int> indexes_answered = new List<int>();
    public int index = 0; //Index to be used to cycle through the questions
    public bool test_questions_finished_generating_flag = false; //this flag is turned on when TestQuestionsGenertor.cs finishes its job of created test questions

    public bool buttonup = true;

    // Use this for initialization
    void Start () {
        
    }

    //vars for to check if dpad has be pressed
    public float dpadx;
    public bool locked = false; //when the dpad is pressed this stops it from always being true since its an axis and not a button
 
	public bool gamestarted = false;
	// Update is called once per frame
	void Update () {
		if (gamestarted) {
			dpadx = Input.GetAxis ("D-Pad X Axis");
       
			/*while the game is not over or if you don't reach the end of the test questions*/
			if (!gameManager.GetComponent<GameManager> ().test_over && (question_number - 1) != gameManager.GetComponent<GameManager> ().number_of_test_questions) {
				/*Do this only once after the test questions were finished generating*/
				if (test_questions_finished_generating_flag) {
					showNextQuestion ();
					test_questions_finished_generating_flag = false;

					foreach (int index in characterTestPaper.GetComponent<TestQuestionsGenerator>().userTestQuestions) {
						clone_of_userTestQuestions.Add (index);
					}
				}


				/*Press the corresponding buttons to pick your answers*/
				/*The answers are stored into an array where TestGrader.cs compares and grades the answers*/

				if (buttonup) {//For so button does not get pushed twice by accident
					/*Answer1 was chosen*/
					if (Input.GetButtonDown ("Y")) {

						buttonup = false;
						Tuple temp = new Tuple (characterTestPaper.GetComponent<TestQuestionsGenerator> ().getQuestionIndex (index), answer1TextObject.text);
						gameManager.GetComponent<GameManager> ().inputted_answers.Add (temp);
						question_number++;


						if (question_number == gameManager.GetComponent<GameManager> ().number_of_test_questions) {
							gameManager.GetComponent<GameManager> ().all_test_questions_complete = true;
							gameManager.GetComponent<GameManager> ().test_over = true;
						} else {
							indexes_answered.Add (index);
							nextIndex ();
							showNextQuestion ();
						}

					}

					/*Answer2 was chosen*/
					if (Input.GetButtonDown ("B")) {
						buttonup = false;
						Tuple temp = new Tuple (characterTestPaper.GetComponent<TestQuestionsGenerator> ().getQuestionIndex (index), answer2TextObject.text);

						gameManager.GetComponent<GameManager> ().inputted_answers.Add (temp);
						question_number++;

						if (question_number == gameManager.GetComponent<GameManager> ().number_of_test_questions) {
							gameManager.GetComponent<GameManager> ().all_test_questions_complete = true;
							gameManager.GetComponent<GameManager> ().test_over = true;
						} else {
							indexes_answered.Add (index);
							nextIndex ();
							showNextQuestion ();
						}
					}

					/*Answer3 was chosen*/
					if (Input.GetButtonDown ("X")) {
						buttonup = false;
						Tuple temp = new Tuple (characterTestPaper.GetComponent<TestQuestionsGenerator> ().getQuestionIndex (index), answer3TextObject.text);

						gameManager.GetComponent<GameManager> ().inputted_answers.Add (temp);

						question_number++;

						if (question_number == gameManager.GetComponent<GameManager> ().number_of_test_questions) {
							gameManager.GetComponent<GameManager> ().all_test_questions_complete = true;
							gameManager.GetComponent<GameManager> ().test_over = true;
						} else {
							indexes_answered.Add (index);
							nextIndex ();
							showNextQuestion ();
						}
					}

					/*Answer4 was chosen*/
					if (Input.GetButtonDown ("A")) {
						buttonup = false;
						Tuple temp = new Tuple (characterTestPaper.GetComponent<TestQuestionsGenerator> ().getQuestionIndex (index), answer4TextObject.text);

						gameManager.GetComponent<GameManager> ().inputted_answers.Add (temp);

						question_number++;

						if (question_number == gameManager.GetComponent<GameManager> ().number_of_test_questions) {
							gameManager.GetComponent<GameManager> ().all_test_questions_complete = true;
							gameManager.GetComponent<GameManager> ().test_over = true;
						} else {
							indexes_answered.Add (index);
							nextIndex ();
							showNextQuestion ();
						}
					}

					/*Cycle right*/
					if (!locked) {
						if (dpadx > 0) {
							locked = true;
							nextIndex ();
							showNextQuestion ();

						}

						/*Cycle left*/
						if (dpadx < 0) {
							locked = true;
							nextIndex ();
							showNextQuestion ();
						}
					}

					if (dpadx == 0) {
						locked = false;
					} //unlocked it since you are not pressing down

				}

				//Let the player answer questions again
				if (Input.GetButtonUp ("A") || Input.GetButtonUp ("B") || Input.GetButtonUp ("X") || Input.GetButtonUp ("Y")) {
					buttonup = true;
				}
			}
 
		}
	}


    void nextIndex()
    {
        
        do
        {
            if (index + 1 < characterTestPaper.GetComponent<TestQuestionsGenerator>().userTestQuestions.Count)
            {
                index++;
            }

            else
            {
                index = 0;
            }
        } while (indexes_answered.Contains(index));

    }

    
    void showNextQuestion()
    {

        List<int> random_answer = new List<int>();

        /*Display the question*/
        questionTextObject.text = characterTestPaper.GetComponent<TestQuestionsGenerator>().getQuestion(index);

        /*Now finding the corresponding answers to the question chosen*/
        
        int pick = 0;   //store the picked answer to randomize the placement
        
        /*If the question has two choices*/
        if(characterTestPaper.GetComponent<TestQuestionsGenerator>().getType(index) == "true/false")
        {
            /*Disable the other two answers spaces on the screen*/
            answer3TextObject.enabled = false;
            answer4TextObject.enabled = false;
            C_label.enabled = false;
            D_label.enabled = false;

            /*Create an array to hold the answers*/
            string[] answers = { characterTestPaper.GetComponent<TestQuestionsGenerator>().getCorrectAnswer(index), characterTestPaper.GetComponent<TestQuestionsGenerator>().getWrongAnswer1(index) };

            /*randomly place the answers on the screen*/
            int i = 0;
            while(i < 2)
            {
                pick = Random.Range(0, answers.Length);
                if (!random_answer.Contains(pick))
                {
                    random_answer.Add(pick);
                    i++;
                }    
            }
            /*Storing the answers strings in the textbox object*/
            answer1TextObject.text = answers[random_answer[0]];
            answer2TextObject.text = answers[random_answer[1]];
        }

        /*Else the question has 4 choices*/
        else
        {
            /*Turn on the other labels and questions*/
            answer3TextObject.enabled = true;
            answer4TextObject.enabled = true;
            C_label.enabled = true;
            D_label.enabled = true;
            string[] answers = { characterTestPaper.GetComponent<TestQuestionsGenerator>().getCorrectAnswer(index), characterTestPaper.GetComponent<TestQuestionsGenerator>().getWrongAnswer1(index), characterTestPaper.GetComponent<TestQuestionsGenerator>().getWrongAnswer2(index), characterTestPaper.GetComponent<TestQuestionsGenerator>().getWrongAnswer3(index) };
            int i = 0;
            while (i < 4)
            {
                pick = Random.Range(0, answers.Length);
               
                if (!random_answer.Contains(pick))
                {

                    random_answer.Add(pick);
                    i++;
                }
            }
            answer1TextObject.text = answers[random_answer[0]];
            answer2TextObject.text = answers[random_answer[1]];
            answer3TextObject.text = answers[random_answer[2]];
            answer4TextObject.text = answers[random_answer[3]];
            
        }
    }

    /*After all the questions completed turn off the display*/
   public void turnOffDisplay()
    {

        questionTextObject.enabled = false;

        answer1TextObject.enabled = false;
      answer2TextObject.enabled = false;
      answer3TextObject.enabled = false;
      answer4TextObject.enabled = false;

      A_label.enabled = false;
      B_label.enabled = false;
      C_label.enabled = false;
      D_label.enabled = false;
}
  
}
