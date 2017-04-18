using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuestionsGeneratorMultiplayerA : MonoBehaviour {

    public TextAsset textfile;                                          //Text file holding all of the questions and answers
    public GameObject GameManager;                                      //Reference to the GameManager object
    public TestQuestions[] totalTestQuestions = new TestQuestions[50];  //Stores the total question list
    public List<int> p1TestQuestions = new List<int>();                 //Player 1's test questions
    public List<int> p2TestQuestions = new List<int>();                 //Player 2's test questions
    public int number_of_questions_created = 0;                         //Number of questions created
    public bool testSwitch_flag = false;
    // Use this for initialization
    void Start () {
        //Create testquestion objects
        GenerateTotalTestQuestions();
        //Divide the test questions between two players
        GenerateUserTestQuestions();
        GameObject.Find("Canvas").GetComponent<DisplayTestQuestionMultiplayerA>().test_questions_finished_generating_flag = true;
        testSwitch_flag = true;
    }

    /*This takes in the text file and create test question objects and stores it into totalTestQuestions[]*/
    void GenerateTotalTestQuestions()
    {
        /*Split the txt file by line and store it into an array*/
        string[] linesinFile = textfile.text.Split('\n');

        int i = 0;
        int j = 0;
        string question;
        string correct_answer;
        string wrong_answer1;
        string wrong_answer2;
        string wrong_answer3;

        /*For each line is a corresponding question and answers, so create a new TestQuestion object 
        and store it into the testquestion array*/
        while (i < linesinFile.Length)
        {
            question = linesinFile[i];
            i++;
            correct_answer = linesinFile[i];
            i++;
            wrong_answer1 = linesinFile[i];
            i++;
            wrong_answer2 = linesinFile[i];
            i++;
            wrong_answer3 = linesinFile[i];
            i++;
            i++;
            totalTestQuestions[j] = new TestQuestions(question, correct_answer, wrong_answer1, wrong_answer2, wrong_answer3, "multiple");
            j++;
            number_of_questions_created++;
        }
    }

    /*Choose test questions from the list of questions for both player 1 and player 2*/
    /*Half of which are in common, and the other half are different from eachother*/
    void GenerateUserTestQuestions()
    {
        /*From the entire list of questions choosing a a specified number of questions to be used and displayed*/
        /*Going to randomly choose a question from the question list and make sure it is not repeated, find a index*/
        /*will crash the game if this infinite loop happens, so don't reach the end of all the questions*/

        int rand_index = 0;
        int num_picked = 0;
        int limit = GameManager.GetComponent<GameManagerMultiplayerA>().number_of_test_questions;

        //First randomly choose half of the questions that are similar to one another
        while (num_picked != (limit/2))
        {
            rand_index = UnityEngine.Random.Range(0, number_of_questions_created);
            if (!p1TestQuestions.Contains(rand_index))
            {
                    p1TestQuestions.Add(rand_index);
                    p2TestQuestions.Add(rand_index);
                    num_picked++;
            }
        }

        //Fill player 1's questions
        while (p1TestQuestions.Count != limit)
        {
            rand_index = UnityEngine.Random.Range(0, number_of_questions_created);
            if (!p1TestQuestions.Contains(rand_index))
            {
                    p1TestQuestions.Add(rand_index);
            }
        }

        //Fill player 2's questions which differ to player 1
        while (p2TestQuestions.Count != limit)
        {
            rand_index = UnityEngine.Random.Range(0, number_of_questions_created);
            if (!p1TestQuestions.Contains(rand_index))
            {
                p2TestQuestions.Add(rand_index);
            }
        }
    }


    public string p1getQuestion(int index)
    {
        return totalTestQuestions[p1TestQuestions[index]].question;
    }

    public string p1getCorrectAnswer(int index)
    {
        return totalTestQuestions[p1TestQuestions[index]].correct_answer;
    }

    public string p1getWrongAnswer1(int index)
    {
        return totalTestQuestions[p1TestQuestions[index]].wrong_answer1;
    }

    public string p1getWrongAnswer2(int index)
    {
        return totalTestQuestions[p1TestQuestions[index]].wrong_answer2;
    }

    public string p1getWrongAnswer3(int index)
    {
        return totalTestQuestions[p1TestQuestions[index]].wrong_answer3;
    }

    public string p1getType(int index)
    {
        return totalTestQuestions[p1TestQuestions[index]].type;
    }

    public int p1getQuestionIndex(int index)
    {
        return p1TestQuestions[index];
    }




    public string p2getQuestion(int index)
    {
        return totalTestQuestions[p2TestQuestions[index]].question;
    }

    public string p2getCorrectAnswer(int index)
    {
        return totalTestQuestions[p2TestQuestions[index]].correct_answer;
    }

    public string p2getWrongAnswer1(int index)
    {
        return totalTestQuestions[p2TestQuestions[index]].wrong_answer1;
    }

    public string p2getWrongAnswer2(int index)
    {
        return totalTestQuestions[p2TestQuestions[index]].wrong_answer2;
    }

    public string p2getWrongAnswer3(int index)
    {
        return totalTestQuestions[p2TestQuestions[index]].wrong_answer3;
    }

    public string p2getType(int index)
    {
        return totalTestQuestions[p2TestQuestions[index]].type;
    }

    public int p2getQuestionIndex(int index)
    {
        return p2TestQuestions[index];
    }

}
