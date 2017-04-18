using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System;

public class PositionRotationRecording : MonoBehaviour {

    //the player character
    public GameObject player;

    //the teacher character
    public GameObject teacher;


    //to write to file for teacher position
   public StreamWriter teach_pos;
    //to write to file for teacher rotation 
	public StreamWriter teach_rot;
    //to write to file for player rotation
	public   StreamWriter player_rot;
	//used for recording scores
	public StreamWriter record;
	//used for recording when player cheats
	public StreamWriter cheating_record;

    public StreamWriter visualAttentionRecord;

	public  string filename;
	public int round_number = -1;
	// Use this for initialization
	void Start () {
		
		round_number = GlobalControl.Instance.round;

        //For setting up file name
        DateTime date1 = DateTime.Now; //gets full date and time
        filename = date1.ToString();
        string month = date1.Month.ToString();
        string day = date1.Day.ToString();
        string min = date1.Minute.ToString();


		//Creating the file to write into
		teach_pos = new StreamWriter("5_" + month + "_" + day + "_" + min + "_" + "Round " +round_number + "_Teacher Position Data.txt");
		teach_pos.WriteLine("Session: " + filename);

		//Creating the file to write into
		teach_rot = new StreamWriter("6_" + month + "_" + day + "_" + min +  "_" +"Round " + round_number + "_Teacher Rotation Data.txt");
		teach_rot.WriteLine("Session: " + filename);

		//Creating the file to write into
		player_rot = new StreamWriter("7_" + month + "_" + day + "_" + min +  "_" + "Round " +round_number + "_Player Rotation Data.txt");
		player_rot.WriteLine("Session: " + filename);

		cheating_record = new StreamWriter("8_" + month + "_" + day + "_" + min +   "_" +"Round " + round_number + "_Cheating Record Data.txt");

        visualAttentionRecord = new StreamWriter( "Visual Attention Data.txt");


    }
    public bool gamestarted = false;
	public bool cheating = false;

    public bool locked = false;
    // Update is called once per frame
    void Update () {
		if (gamestarted) {

			//teach_pos.WriteLine (Time.time + " " + teacher.transform.position.x + " " + teacher.transform.position.y + " " + teacher.transform.position.z);
			//teach_pos.Flush ();

		//	teach_rot.WriteLine (Time.time + " " + teacher.transform.rotation.eulerAngles.x + " " + teacher.transform.rotation.eulerAngles.y + " " + teacher.transform.rotation.eulerAngles.z);
			teach_rot.Flush ();

		//	player_rot.WriteLine (Time.time + " " + player.transform.rotation.eulerAngles.x + " " + player.transform.rotation.eulerAngles.y + " " + player.transform.rotation.eulerAngles.z);
			//player_rot.Flush ();

        if (!locked)
            {
                StartCoroutine(DisplayString());
            }
        
            //Recording when the player is cheating for session playback 
            //0 means not cheating 1 means cheating
            if (cheating) {

			cheating_record.WriteLine (Time.time + " " + 1);
			cheating_record.Flush ();
			} else {
				cheating_record.WriteLine (Time.time + " " + 0);
				cheating_record.Flush ();
			}
		}
	}


   
    IEnumerator DisplayString()
    {

        visualAttentionRecord.WriteLine(Time.time + " " + teacher.GetComponent<TeacherRayCaster>().sum);
        visualAttentionRecord.Flush();
        locked = true;
           
        //Debug.Log("going wait 1 second " + Time.time);
        yield return new WaitForSeconds(1);
          
            //Debug.Log("Waiting 1 second " + Time.time);
         
        locked = false;

    }


    public int num1;
	//This function is called after a round has ended and records the number of correct answered questions
	public void RecordNumCorrectQuestions(){
		
		//record = new StreamWriter ("Round " + round_number +" scores.txt");
		// num1 = GetComponent<TestGrader> ().GradeTest ();
		//record.WriteLine (num1 + "/5");
		//record.Flush ();
	}

	public void RecordCheated(){
		//record = new StreamWriter ("Round " + round_number +" scores.txt");
		//record.WriteLine ("Player was caught cheating, 0 correct");
		//record.Flush ();
	}
}
