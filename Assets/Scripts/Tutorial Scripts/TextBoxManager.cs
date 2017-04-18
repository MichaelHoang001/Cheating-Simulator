using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TextBoxManager : MonoBehaviour {
    //This script is used to change the text of the textbox whenever the player moves on

    //object for the text box to change the text
    public Text textbox;
  
    //This contains the text that you want to display in order
        string[] texts = {"These are the controls for the game"
                              + System.Environment.NewLine +
                            System.Environment.NewLine +
                             "A, B, X , and Y Buttons Correspond to the Multiple Choice Answers"
                            + System.Environment.NewLine +
                            System.Environment.NewLine +
                            "Left and Right D-Pad Allows You to Shuffle Through Questions"
                            + System.Environment.NewLine +
                                System.Environment.NewLine +
                            "Down/Up D-pad Turns Off/On Cheating"
                             + System.Environment.NewLine +
                                System.Environment.NewLine +
                            System.Environment.NewLine +
                                "Press X to Continue",
            
                            "Now Lets Practice Answering Some Questions"
                            + System.Environment.NewLine +
                              System.Environment.NewLine +
                            "Look Below To See a few Questions and Try to Answer Them",

                               "Now Lets Practice Answering Some Questions"
                            + System.Environment.NewLine +
                              System.Environment.NewLine +
                            "Look Below To See a few Questions and Try to Answer Them",

                            "Good, Now Press X To Continue",

                            "Now Lets Try Cheating"
                          + System.Environment.NewLine +
                              System.Environment.NewLine +
                            "Look Left or Right to Cheat the  Answer to the Question"
                            + System.Environment.NewLine +
                              System.Environment.NewLine +
                            "And Use the Up/Down D-pad to Cheat"
                               + System.Environment.NewLine +
                              System.Environment.NewLine +
                            "Press X to Continue",

                            "Remember if the Teacher Sees you While Cheating"
                             + System.Environment.NewLine +
                              System.Environment.NewLine +
                                   "The Round will End"
                              + System.Environment.NewLine +
                              System.Environment.NewLine +
                            "If You Find an Anwser While Cheating You can use "
                                 + System.Environment.NewLine +
                              System.Environment.NewLine +
                        "Left/Right D-pad to Find the Question For that Answer"
                                   + System.Environment.NewLine +
                              System.Environment.NewLine +
                            "Wait for Lab Personnel"
                                                            };
    
    // Use this for initialization
	void Start () {
	
	}

    //An index for what text to display next
    public int i = -1;
    //lock the text box until a condition is met
    public bool locked = false;

    // Update is called once per frame
    void Update () {

        if (!locked)
        {
            //As long as the index does not past the end of the array
            if (!((i + 1) == texts.Length))
                if (Input.GetButtonDown("X"))
                {
                    //Get the next index and show it in the textbox
                    i++;
                    textbox.text = texts[i];
                }

			if (Input.GetKeyDown(KeyCode.F8))
            {
                if (i+1 == 6)
                {
                    SceneManager.LoadScene("Cheating Demo");
                }
            }
        }



	}

   public void lock_text_box()
    {
        locked = true;
    }

   public void unlock_text_box()
    {
        locked = false;
        //unlock and now show the next message
        i++;
        textbox.text = texts[i];

    }

    public void indexup()
    {
        i++;
    }
}
