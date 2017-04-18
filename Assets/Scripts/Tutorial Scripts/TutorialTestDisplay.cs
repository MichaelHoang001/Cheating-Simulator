using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialTestDisplay : MonoBehaviour {

    //Lists that contain answers and questions
    public string[] questions = {"1 + 1 =", "Are you a...", "Today is a.." };
    public string[] answersA = {"4", "Senior", "Monday" };
    public string[] answersB = {"3", "Teen", "Holiday" };
    public string[] answersX = {"2", "Adult", "Weeekend" };
    public string[] answersY = {"1", "Child", "Weekday" };

    //The objects that you store the answers text in
    public Text Questext;
    public Text Atext;
    public Text Btext;
    public Text Xtext;
    public Text Ytext;
    public int index = -1;
    // Use this for initialization
    void Start () {
	
	}
    //index for to show next questions
   

	// Update is called once per frame
	void Update () {
	 

	}

    public void displayTest()
    {
        //Gets the next question
        index++;

        if(index == 3)
        {
            GetComponent<TutorialGameManager>().tutorial_done = true;
        }

        if (index < 3)
        {
            //Get the next answers and questions
            Questext.text = questions[index];
            Atext.text = answersA[index];
            Btext.text = answersB[index];
            Xtext.text = answersX[index];
            Ytext.text = answersY[index];
        }

    }

    public void indexup()
    {
        index++;
    }
}
