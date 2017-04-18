using UnityEngine;
using System.Collections;

public class TestGrader : MonoBehaviour {

    public GameObject testQuestionsDisplayObject; //Contains the list of indexes questions chosen
    public GameObject testQuestionPaperObject;  //Contains the entire question list
    public GameObject testQuestionGeneratorObject;
    public int GradeTest()
    {
        int limit = GetComponent<GameManager>().number_of_test_questions;
        int number_of_questions_correct = 0;
        //Using the index list to pick the questions in the entire question list to compare to the answer list

        for(int i = 0; i < limit; i++)
        {
         if(testQuestionGeneratorObject.GetComponent<TestQuestionsGenerator>().totalTestQuestions[GetComponent<GameManager>().inputted_answers[i].question_index].correct_answer == GetComponent<GameManager>().inputted_answers[i].player_answer)
            {
                number_of_questions_correct++;
            }
        }
        return number_of_questions_correct;
    }
}
