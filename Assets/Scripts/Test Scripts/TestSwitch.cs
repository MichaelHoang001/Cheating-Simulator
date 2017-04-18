using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestSwitch : MonoBehaviour {

    /*
   public GameObject testPaper;                  //The Students test sheet, will be used to store the sprite of the image
   public Sprite testPage1;                     //A page of a test
   public Sprite testPage2;                     //A page of the test
   */
   public bool on = true;                       //Turn on the coroutine
    //public bool test_questions_finished_generating_flag = false;                 //unlock a function when the questions are finished generated and chosen
   public bool switch_image = true;             //switch the image
   public float time_interval = 5;             //Number of seconds before the image switches
    public GameObject testQuestionsDisplayObject; //Contains the list of indexes questions chosen
    public GameObject testQuestionPaperObject;  //Contains the entire question list
    public Text answer;
    public int rand = 0;
    public int current = 0;
  

	
	// Update is called once per frame
	void Update () {

        /*Image will periodically switch depending on time limit*/
        /*The time since the level started modulo by the time-interval so every interval the condition is done*/
        if (on)
        {
            StartCoroutine(ChangeImage());
        }
           
    }

    IEnumerator ChangeImage()
    {
        on = false;                                         //Turn of the coroutine so it is called one at a time in the Update() function
        //print(Time.time);                                   //Checking to see if it actually waits 5 seconds



        if (testQuestionPaperObject.GetComponent<TestQuestionsGenerator>().testSwitch_flag) //Do this when the flag is on
        {
            /*Do this only if the question are finished generated and chosen*/

            /*Get a random index number in the chosen question list,
            make sure it is not from an answer from a already answered question*/
            do
            {
                rand = Random.Range(0, testQuestionPaperObject.GetComponent<TestQuestionsGenerator>().userTestQuestions.Count);
            } while (testQuestionsDisplayObject.GetComponent<DisplayTestQuestion>().indexes_answered.Contains(rand));
            // while (rand == current);
            current = rand;
            answer.text = testQuestionPaperObject.GetComponent<TestQuestionsGenerator>().getCorrectAnswer(rand);
           

        }

        yield return new WaitForSeconds(time_interval);     //This makes the function wait before returning to update function to start another cycle

       //print(Time.time);
        on = true;                                          //Turn on the coroutine so it start another cycle 
    }
}
