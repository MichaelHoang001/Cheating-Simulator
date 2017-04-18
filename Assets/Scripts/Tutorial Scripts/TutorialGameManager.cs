using UnityEngine;
using System.Collections;

public class TutorialGameManager : MonoBehaviour {


    public GameObject testobj;
    public GameObject canvas;
    public GameObject test1;
    public GameObject test2;
    public GameObject main_camera;
    public GameObject righttest_answer_text;
    public GameObject lefttest_answer_text;
    public Vector3 original_test_positionl;//The original position of the test
    public Quaternion original_test_rotationl;//The original rotation of the test
    public Vector3 original_test_positionr;//The original position of the test
    public Quaternion original_test_rotationr;//The original rotation of the test
    // Use this for initialization
    void Start () {
        original_test_positionl = test1.transform.position;
        original_test_rotationl = test1.transform.rotation;

        original_test_positionr = test2.transform.position;
        original_test_rotationr = test2.transform.rotation;
    }

    public bool doTutorialQuestions = false;
     public bool tutorial_done = true;
    public float dpady;
    // Update is called once per frame
    void Update () {

        //time to start the question answering tutorial
     if(GetComponent<TextBoxManager>().i == 1){
           
             //lock the textbox until the task is completed
             print( "locking");
             GetComponent<TextBoxManager>().lock_text_box();
            print("display test");
            GetComponent<TutorialTestDisplay>().displayTest();
            print("indexingup");
            GetComponent<TextBoxManager>().indexup();
              tutorial_done = false;

            testobj.SetActive(true);
            canvas.SetActive(true);
        }

        //Time to stop the tutorial
        if (GetComponent<TutorialTestDisplay>().index == 3)
        {

            GetComponent<TutorialTestDisplay>().indexup();
            //so unlock the text box
           GetComponent<TextBoxManager>().unlock_text_box();
            tutorial_done = true;
            testobj.SetActive(false);
            canvas.SetActive(false);
        }

        if (!tutorial_done)
        {
            if (Input.GetButtonDown("A"))
            {
                GetComponent<TutorialTestDisplay>().displayTest();
            }

            if (Input.GetButtonDown("B"))
            {
                GetComponent<TutorialTestDisplay>().displayTest();
            }

            if (Input.GetButtonDown("X"))
            {
                GetComponent<TutorialTestDisplay>().displayTest();
            }

            if (Input.GetButtonDown("Y"))
            {
                GetComponent<TutorialTestDisplay>().displayTest();
            }
        }

        dpady = Input.GetAxis("D-Pad Y Axis");
        if ( dpady > 0)
        {


            test1.transform.rotation = main_camera.transform.rotation;
            test2.transform.rotation = main_camera.transform.rotation;
            righttest_answer_text.SetActive(true);
            lefttest_answer_text.SetActive(true);
        }

        else {
          
            //Don't show the answer unless you are holding down the cheating button
            righttest_answer_text.SetActive(false);
            lefttest_answer_text.SetActive(false);
            test1.transform.position = original_test_positionl;
            test1.transform.rotation = original_test_rotationl;

            test2.transform.position = original_test_positionr;
            test2.transform.rotation = original_test_rotationr;
        }
    }
}
