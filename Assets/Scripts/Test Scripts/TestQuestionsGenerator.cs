using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;

public class TestQuestionsGenerator : MonoBehaviour {
   public TextAsset textfile;
   public GameObject GameManager;
   public TestQuestions[] totalTestQuestions = new TestQuestions[50];          //The total question list
   public List<int> userTestQuestions = new List<int>();                      //The question list used for the actual answering in game, it is a list of indexes used to get the question from TotalQuestions[]
   public int number_of_questions_created = 0;
    public bool testSwitch_flag = false;
    // Use this for initialization
    void Start () {

        GenerateTotalTestQuestions();
        GenerateUserTestQuestions();
        GameObject.Find("Canvas").GetComponent<DisplayTestQuestion>().test_questions_finished_generating_flag = true;
        testSwitch_flag = true;
    }

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

            //If the last question is a true and false then don't bother checking the rest of the file and break out
            if (i == linesinFile.Length)
            {

                totalTestQuestions[j] = new TestQuestions(question, correct_answer, wrong_answer1, "true/false");
                number_of_questions_created++;
                break;
            }

            wrong_answer2 = linesinFile[i];
            i++;
            /*If the test question is true false question*/
            if (wrong_answer2.Equals(""))
            {
                totalTestQuestions[j] = new TestQuestions(question, correct_answer, wrong_answer1, "true/false");
                number_of_questions_created++;
            }

            /*If the test question multiple choice*/
            else
            {
                wrong_answer3 = linesinFile[i];
                i++;
                i++;
                totalTestQuestions[j] = new TestQuestions(question, correct_answer, wrong_answer1, wrong_answer2, wrong_answer3, "multiple");
                j++;
                number_of_questions_created++;
            }


        }


    }


    /*These are the test questions the user will answer*/
    /*Going to store the indexes of the questions I want to use*/
    void GenerateUserTestQuestions()
    {
        /*From the entire list of questions choosing a a specified number of questions to be used and displayed*/
        /*Going to randomly choose a question from the question list and make sure it is not repeated, find a index*/
        /*will crash the game if this infinite loop happens, so don't reach the end of all the questions*/

        int rand_index = 0;
        int num_picked = 0;
        int limit = GameManager.GetComponent<GameManager>().number_of_test_questions;
        while (num_picked != limit)
        {
            rand_index = UnityEngine.Random.Range(0, number_of_questions_created);
            if (!userTestQuestions.Contains(rand_index))
            {
				if (!GlobalControl.Instance.oldQuestions.Contains (rand_index)) {
					userTestQuestions.Add(rand_index);
					num_picked++;
					GlobalControl.Instance.oldQuestions.Add (rand_index);
				}
         
            }
        }
    }

    public string getQuestion(int index)
    {
        return totalTestQuestions[userTestQuestions[index]].question;
    }

    public string getCorrectAnswer(int index)
    {
        return totalTestQuestions[userTestQuestions[index]].correct_answer;
    }

    public string getWrongAnswer1(int index)
    {
        return totalTestQuestions[userTestQuestions[index]].wrong_answer1;
    }

    public string getWrongAnswer2(int index)
    {
        return totalTestQuestions[userTestQuestions[index]].wrong_answer2;
    }

    public string getWrongAnswer3(int index)
    {
        return totalTestQuestions[userTestQuestions[index]].wrong_answer3;
    }

    public string getType(int index)
    {
        return totalTestQuestions[userTestQuestions[index]].type;
    }

    public int getQuestionIndex(int index)
    {
        return userTestQuestions[index];
    }
}
