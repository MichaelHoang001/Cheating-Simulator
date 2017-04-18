using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DisplayTestQuestionMultiplayerA : MonoBehaviour {
    //These are all for the text gui objects
    public Text questionTextObject;
    public Text answer1TextObject;
    public Text answer2TextObject;
    public Text answer3TextObject;
    public Text answer4TextObject;
    public Text A_label;
    public Text B_label;
    public Text C_label;
    public Text D_label;

    public Text p2questionTextObject;
    public Text p2answer1TextObject;
    public Text p2answer2TextObject;
    public Text p2answer3TextObject;
    public Text p2answer4TextObject;
    public Text p2A_label;
    public Text p2B_label;
    public Text p2C_label;
    public Text p2D_label;

    //Contains the TestQuestionGeneratorMultiplaterA class
    public GameObject characterTestPaper;

    //GameManager object
    public GameObject gameManager;

    public int p1question_number = 0;
    public int p2question_number = 0;
    public int pick_a_question;
    public List<int> clone_of_p1TestQuestions = new List<int>(); //A copy of Player 1's list of questions
    public List<int> clone_of_p2TestQuestions = new List<int>(); //A copy of Player 2's list of questions

    public List<int> p1_indexes_answered = new List<int>();      //Player 1's answered indices
    public List<int> p2_indexes_answered = new List<int>();      //Player 2's answered indices

    public int p1_index = 0;                                     //Index to be used to cycle through the questions
    public int p2_index = 0;                                     //Index to be used to cycle through the questions

    public bool test_questions_finished_generating_flag = false; // turned on when TestQuestionsGenerator finishes creating test questions
        
    public bool buttonup = true;                                 //Used for player 1's dpad controls

    //vars for to check if dpad has be pressed
    public float dpadx;
    public bool locked = false;     //when the dpad is pressed this stops it from always being true since its an axis and not a button

    public bool gamestarted = false;                            //If the game started or not

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gamestarted)
        {
            dpadx = Input.GetAxis("D-Pad X Axis");

            //If player 1 still has more questions too answer and player 1's test is not over
            if (!gameManager.GetComponent<GameManagerMultiplayerA>().p1test_over && (p1question_number - 1) != gameManager.GetComponent<GameManagerMultiplayerA>().number_of_test_questions)
            {
                /*Do this only once after the test questions were finished generating*/
                if (test_questions_finished_generating_flag)
                {
                    showNextQuestionP1();
                    test_questions_finished_generating_flag = false;

                    //Create a clone of p1's test questions
                    foreach (int index in characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p1TestQuestions)
                    {
                        clone_of_p1TestQuestions.Add(index);
                    }
                }

                /*Press the corresponding buttons to pick your answers*/
                /*The answers are stored into an array where TestGrader.cs compares and grades the answers*/

                if (buttonup)
                {//For so button does not get pushed twice by accident
                 /*Answer1 was chosen*/
                    if (Input.GetButtonDown("Y"))
                    {

                        buttonup = false;
                        Tuple temp = new Tuple(characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p1getQuestionIndex(p1_index), answer1TextObject.text);
                        gameManager.GetComponent<GameManagerMultiplayerA>().p1inputted_answers.Add(temp);
                        p1question_number++;


                        if (p1question_number == gameManager.GetComponent<GameManagerMultiplayerA>().number_of_test_questions)
                        {
                            //gameManager.GetComponent<GameManagerMultiplayerA>().all_test_questions_complete = true;
                            gameManager.GetComponent<GameManagerMultiplayerA>().p1test_over = true;
                        }
                        else {
                            p1_indexes_answered.Add(p1_index);
                            nextP1Index();
                            showNextQuestionP1();
                        }

                    }

                    /*Answer2 was chosen*/
                    if (Input.GetButtonDown("B"))
                    {
                        buttonup = false;
                        Tuple temp = new Tuple(characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p1getQuestionIndex(p1_index), answer2TextObject.text);

                        gameManager.GetComponent<GameManagerMultiplayerA>().p1inputted_answers.Add(temp);
                        p1question_number++;

                        if (p1question_number == gameManager.GetComponent<GameManagerMultiplayerA>().number_of_test_questions)
                        {
                            //gameManager.GetComponent<GameManagerMultiplayerA>().all_test_questions_complete = true;
                            gameManager.GetComponent<GameManagerMultiplayerA>().p1test_over = true;
                        }
                        else {
                            p1_indexes_answered.Add(p1_index);
                            nextP1Index();
                            showNextQuestionP1();
                        }
                    }

                    /*Answer3 was chosen*/
                    if (Input.GetButtonDown("X"))
                    {
                        buttonup = false;
                        Tuple temp = new Tuple(characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p1getQuestionIndex(p1_index), answer3TextObject.text);

                        gameManager.GetComponent<GameManagerMultiplayerA>().p1inputted_answers.Add(temp);

                        p1question_number++;

                        if (p1question_number == gameManager.GetComponent<GameManagerMultiplayerA>().number_of_test_questions)
                        {
                            //gameManager.GetComponent<GameManagerMultiplayerA>().all_test_questions_complete = true;
                            gameManager.GetComponent<GameManagerMultiplayerA>().p1test_over = true;
                        }
                        else {
                            p1_indexes_answered.Add(p1_index);
                            nextP1Index();
                            showNextQuestionP1();
                        }
                    }

                    /*Answer4 was chosen*/
                    if (Input.GetButtonDown("A"))
                    {
                        buttonup = false;
                        Tuple temp = new Tuple(characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p1getQuestionIndex(p1_index), answer4TextObject.text);

                        gameManager.GetComponent<GameManagerMultiplayerA>().p1inputted_answers.Add(temp);

                        p1question_number++;

                        if (p1question_number == gameManager.GetComponent<GameManagerMultiplayerA>().number_of_test_questions)
                        {
                            //gameManager.GetComponent<GameManagerMultiplayerA>().all_test_questions_complete = true;
                            gameManager.GetComponent<GameManagerMultiplayerA>().p1test_over = true;
                        }
                        else {
                            p1_indexes_answered.Add(p1_index);
                            nextP1Index();
                            showNextQuestionP1();
                        }
                    }

                    /*Cycle right*/
                    if (!locked)
                    {
                        if (dpadx > 0)
                        {
                            locked = true;
                            nextP1Index();
                            showNextQuestionP1();

                        }

                        /*Cycle left*/
                        if (dpadx < 0)
                        {
                            locked = true;
                            nextP1Index();
                            showNextQuestionP1();
                        }
                    }

                    if (dpadx == 0)
                    {
                        locked = false;
                    } //unlocked it since you are not pressing down

                }

                //Let the player answer questions again
                if (Input.GetButtonUp("A") || Input.GetButtonUp("B") || Input.GetButtonUp("X") || Input.GetButtonUp("Y"))
                {
                    buttonup = true;
                }
            }




            if (Input.GetKeyDown(KeyCode.Space))
            {
                nextP1Index();
                nextP2Index();
                showNextQuestionP1();
                showNextQuestionP2();
            }

            
        }





	}


    //Gets the next index to show the next question for Player 1
    void nextP1Index()
    {
        do
        {
            if (p1_index + 1 < characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p1TestQuestions.Count)
            {
                p1_index++;
            }

            else
            {
                p1_index = 0;
            }
        } while (p1_indexes_answered.Contains(p1_index));
    }

    //Gets the next index to show the next question for Player 2
    void nextP2Index()
    {
        do
        {
            if (p2_index + 1 < characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p2TestQuestions.Count)
            {
                p2_index++;
            }

            else
            {
                p2_index = 0;
            }
        } while (p2_indexes_answered.Contains(p2_index));

    }


    //Displays Player 1's questions
    void showNextQuestionP1()
    {

        List<int> random_answer = new List<int>();

        /*Display the question*/
        questionTextObject.text = characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p1getQuestion(p1_index);

        /*Now finding the corresponding answers to the question chosen*/

        int pick = 0;   //store the picked answer to randomize the placement

            /*Turn on the other labels and questions*/
            answer3TextObject.enabled = true;
            answer4TextObject.enabled = true;
            C_label.enabled = true;
            D_label.enabled = true;
            string[] answers = { characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p1getCorrectAnswer(p1_index),
                                 characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p1getWrongAnswer1(p1_index),
                                 characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p1getWrongAnswer2(p1_index),
                                 characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p1getWrongAnswer3(p1_index) };
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

    //Displays Player 2's questions
    void showNextQuestionP2()
    {

        List<int> random_answer = new List<int>();

        /*Display the question*/
        p2questionTextObject.text = characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p2getQuestion(p2_index);

        /*Now finding the corresponding answers to the question chosen*/

        int pick = 0;   //store the picked answer to randomize the placement

        /*Turn on the other labels and questions*/
        p2answer3TextObject.enabled = true;
        p2answer4TextObject.enabled = true;
        C_label.enabled = true;
        D_label.enabled = true;
        string[] answers = { characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p2getCorrectAnswer(p2_index),
                                 characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p2getWrongAnswer1(p2_index),
                                 characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p2getWrongAnswer2(p2_index),
                                 characterTestPaper.GetComponent<TestQuestionsGeneratorMultiplayerA>().p2getWrongAnswer3(p2_index) };
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
        p2answer1TextObject.text = answers[random_answer[0]];
        p2answer2TextObject.text = answers[random_answer[1]];
        p2answer3TextObject.text = answers[random_answer[2]];
        p2answer4TextObject.text = answers[random_answer[3]];
    }

    /*After all the questions completed turn off the Player 1's display*/
    public void turnOffP1Display()
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

    /*After all the questions completed turn off the Player 2's display*/
    public void turnOffP2Display()
    {

        p2questionTextObject.enabled = false;

        p2answer1TextObject.enabled = false;
        p2answer2TextObject.enabled = false;
        p2answer3TextObject.enabled = false;
        p2answer4TextObject.enabled = false;

        p2A_label.enabled = false;
        p2B_label.enabled = false;
        p2C_label.enabled = false;
        p2D_label.enabled = false;
    }
}
