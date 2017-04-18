using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System;

public class TeacherVisionScript : MonoBehaviour {

    public GameObject gameManager;
    public List<float> caught_times = new List<float>(); //holds times of start/stop cheating
    public StreamWriter sw; // to write to a file that will hold all the times the teacher caught the student
	string filename;
	public int round_number;
    void Start()
    {
		round_number = GlobalControl.Instance.round;
		DateTime date1 = DateTime.Now; //gets full date and time
		filename = date1.ToString();
		string month = date1.Month.ToString();
		string day = date1.Day.ToString();
		string min = date1.Minute.ToString();


		sw = new StreamWriter("9_" + month + "_" + day + "_" + min + "_" + "Round " +round_number +"_caught_times.txt"); //THE FILE IS CREATED OR OVERWRITTEN OUTSIDE THE ASSESTS FOLDER.
    }

	public bool gamestarted = false;
    void OnTriggerEnter(Collider other)
    {
		if(gamestarted){
        /*If the teacher sees the player*/
			if (other.gameObject.tag == "Player") {
				/*If the player is currently cheating*/
				if (other.gameObject.GetComponent<RayCaster> ().isCheating_flag) {
					//print("you cheated");
					/*You got caught cheating so end the game*/
					caught_times.Add (Time.time);
					sw.WriteLine ("Caught Cheating At: " + Time.time);
					sw.Flush ();
					gameManager.GetComponent<GameManager> ().caught_cheating = true;
					gameManager.GetComponent<GameManager> ().test_over = true;
				}
			}
        }
    }

}
