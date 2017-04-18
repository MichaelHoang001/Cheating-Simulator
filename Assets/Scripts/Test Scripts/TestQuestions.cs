
using UnityEngine;
using System.Collections;
using System;
public class TestQuestions : MonoBehaviour
{

    public string question;
    public string correct_answer;
    public string wrong_answer1;
    public string wrong_answer2;
    public string wrong_answer3;
    public string type;

    /*Contructor for test question object that contains one right answer and 1 false answers, use this for true false questions*/
    public TestQuestions(string question, string correct_answer, string wrong_answer1, string type)
    {
        this.question = question;
        this.correct_answer = correct_answer;
        this.wrong_answer1 = wrong_answer1;
        this.type = type;
    }

    /*Contructor for test question object that contains one right answer and 3 false answers*/
    public TestQuestions(string question, string correct_answer, string wrong_answer1, string wrong_answer2, string wrong_answer3, string type)
    {
        this.question = question;
        this.correct_answer = correct_answer;
        this.wrong_answer1 = wrong_answer1;
        this.wrong_answer2 = wrong_answer2;
        this.wrong_answer3 = wrong_answer3;
        this.type = type;
    }


}
