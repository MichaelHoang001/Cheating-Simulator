using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public class RayCaster : MonoBehaviour {
    public Camera main_camera;          //The camera that is being used, i.e. first person camera
    public RaycastHit previous_hit;
    public float distance = 1000f;      //How long the raycaster will stretch out
    public Vector3 camera_position;     //Position of the camera, though the character is not supposed to move, but can turn its head
    public GameObject otherStudentsTest;//test Object of other students
    public bool isCheating_flag = false;  //If the player is looking at the test and holding space
    Dictionary<float, float> cheatingtimes = new Dictionary<float, float>(); //holds times of start/stop cheating
    StreamWriter sw; // to write to a file
    float starttime;
    string filename;
    public double suspicion; //measure of how much time the student spends looking at the teacher
    public GameObject lefttest;
    public GameObject righttest;
    public GameObject lefttest_answer_text;
    public GameObject righttest_answer_text;
	public GameObject teacher;
	public GameObject game_manager;
	public float teacherposx;
	public float teacherposz;
	public float teacherroty;
    public double cameraViewAngle;
    public double teacherViewAngle;
	public int round_number;

    GameObject prefab;

    // Use this for initialization
    void Start()
    {
		round_number = GlobalControl.Instance.round;
        lefttest = GameObject.Find("Other Student Tests (10)");
        righttest = GameObject.Find("Other Student Tests");
        DateTime date1 = DateTime.Now; //gets full date and time
        filename = date1.ToString();
        string month = date1.Month.ToString();
        string day = date1.Day.ToString();
        string min = date1.Minute.ToString();
		sw = new StreamWriter("10_" + month + "_" + day + "_" + min +  "_Round " + round_number + "_cheatingtimes.txt");
        sw.WriteLine("Session: " + filename);
        suspicion = 0;
        prefab = Resources.Load("Eraser") as GameObject;
    }

    //This is now used for cheating button, if it is possitive you are cheating
    public float dpady;

	public bool gamestarted = false;
	public bool dpad_up = false;

    // Update is called once per frame
    void Update()
    {
        if (gamestarted)
        {
            dpady = Input.GetAxis("D-Pad Y Axis");
            if (dpady > 0)
            {
                dpad_up = true;
            }

            /*The end of ray length that shoots out of the camera, prob used for the cursor*/
            camera_position = main_camera.transform.position + (main_camera.transform.forward * distance);

            /*Creating the ray itself*/
            Ray myRay = new Ray(main_camera.transform.position, main_camera.transform.forward * distance);
            //Debug.Log("endpoint of forward ray is " + (myRay.origin + (main_camera.transform.forward * distance)) + "ray is " + myRay); //check if endpoint is same throughout, it's not
            //Debug.Log("start of forward ray is " + main_camera.transform.position); //check if origin is same throughout, it is (-0.6, .4, 1.4)
            //Debug.Log("ray is " + myRay); //gives (Origin: (-0.6, 0.4, 1.4) Dir: (0.3, 0.4, -0.8) with dir changing throughout
            /*What the ray intersects with is stored in this variable*/

            /*For debugging, can only be seen in the scene window on Unity*/
            //Debug.DrawRay(main_camera.transform.position, main_camera.transform.forward * distance, Color.magenta); //original
            Debug.DrawRay(main_camera.transform.position, myRay.origin + main_camera.transform.forward * distance, Color.magenta);
            if (Input.GetKeyUp(KeyCode.Space) || dpady < 0)
            {
                //if let go of space, record end cheating time
                cheatingtimes[starttime] = Time.time; //end time of cheating
                sw.WriteLine("Cheating Start Time: " + starttime +
                    " Cheating End Time: " + cheatingtimes[starttime] +
                    " Forward Ray end point: " + (main_camera.transform.forward * distance) +
                    " Teacher Position X: " + teacher.transform.position.x +
                    " Teacher Position Z: " + teacher.transform.position.z +
                    " Teacher Rotation Y: " + teacher.transform.rotation.eulerAngles.y);
                sw.Flush();
                dpad_up = false;
                game_manager.GetComponent<PositionRotationRecording>().cheating = false;
            }


            if (Input.GetKeyDown(KeyCode.F)) {
                float up_offset = 0.3f;
                float forward_offset = 1f;
                float up_velocity = 3f;
                float forward_velocity = 8f;
                GameObject eraser = Instantiate(prefab) as GameObject;
                eraser.transform.position = transform.position + (main_camera.transform.forward * forward_offset) + new Vector3(0, up_offset, 0); 
                Rigidbody rb = eraser.GetComponent<Rigidbody>();
                rb.velocity = main_camera.transform.forward * forward_velocity + new Vector3(0, up_velocity, 0);
            }

            // suspicion mechanic - keeps track of how often you look at the teacher or look backwards
            cameraViewAngle = returnAngle((main_camera.transform.forward * distance).x, (main_camera.transform.forward * distance).z);
            teacherViewAngle = returnAngle(teacher.transform.position.x, teacher.transform.position.z);
            //Debug.Log("camera: " + cameraViewAngle + " | teacher: " + teacherViewAngle);

            if (cameraViewAngle - teacherViewAngle > 270)
                teacherViewAngle += 360;
            else if (teacherViewAngle - cameraViewAngle > 270)
                cameraViewAngle += 360;
            double viewAngleDistance = Math.Abs(cameraViewAngle - teacherViewAngle);
            double cameraForwardAngle = cameraViewAngle;
            if (cameraForwardAngle > 180)
                cameraForwardAngle = 360 - cameraForwardAngle;

            // suspicion grows linearly based on two factors:
            // - how closely you look at the teacher
            // - how far to the back you're looking
            double lookAtTeacherAngle = 45; // how close you need to look at the teacher before he grows suspicious - apex when looking directly at him
            double lookBackwardsAngle = 30; // how far backwards you can turn before it is deemed suspicious - apex when looking 180 degrees backwards

            double lookAtTeacherFactor = 4; // suspicion growth scales between 0 (at the edge of suspicion) and these numbers (at the apex of suspicioun)
            double lookBackwardsFactor = 3;

            double decayFactor = 1; // decay of suspicion per frame

            if (viewAngleDistance < lookAtTeacherAngle && cameraForwardAngle > lookBackwardsAngle){
                if (suspicion < 100) {
                    double lookAtTeacherSuspicion = (lookAtTeacherAngle - viewAngleDistance) / lookAtTeacherAngle * lookAtTeacherFactor;
                    double lookBackwardsSuspicion = (cameraForwardAngle - lookBackwardsAngle) / (180-lookBackwardsAngle) * lookBackwardsFactor;
                    suspicion += lookAtTeacherSuspicion * lookBackwardsSuspicion;
                }
                else {
                    // suspicious!!
                    suspicion = 100;
                    teacher.GetComponent<TeacherMovement>().isSuspicious = true;
                }                
            }
            else {
                if (suspicion > 0)
                    suspicion -= decayFactor;
                else if (suspicion <= 0) {
                    suspicion = 0;
                    teacher.GetComponent<TeacherMovement>().isSuspicious = false; // when suspicious, you will not be un-suspicious until suspicion hits 0
                }
            }
            
            /*if (suspicion == 100)
                Debug.Log("SUSPICIOUS!!!!");
            else if (suspicion > 0)
                Debug.Log("Current suspicion:" + suspicion);*/
                

			//When you look at it, the test moves so it is easier to see
			//if holding down space
			if (Input.GetKey (KeyCode.Space) || dpad_up) {

				//This is for tests to the right of you
				//   hit.collider.gameObject.transform.position = new Vector3(-(float)1.35334, (float)0.1603178, (float)2.132282);
				//   hit.collider.gameObject.transform.rotation = Quaternion.Euler((float)12.8727, (float)228.9193, (float)11.30263);
				lefttest.transform.rotation = main_camera.transform.rotation;
				righttest.transform.rotation = main_camera.transform.rotation;
				starttime = Time.time;
				isCheating_flag = true;

				//Show the answer on the classmates tests
				righttest_answer_text.SetActive (true);
				lefttest_answer_text.SetActive (true);
				teacherposx = teacher.transform.position.x;
				teacherposz = teacher.transform.position.z;
				teacherroty = teacher.transform.rotation.eulerAngles.y; 
				game_manager.GetComponent<PositionRotationRecording> ().cheating = true;
			} 
			else {
				isCheating_flag = false;
				//Don't show the answer unless you are holding down the cheating button
				righttest_answer_text.SetActive (false);
				lefttest_answer_text.SetActive (false);
			

			}
		}
    }

    // used in suspicion mechanic
    double returnAngle(double x, double z) {
        double angle = Math.Atan(x / z) * (180 / Math.PI);
        double circular; // 0/360 degrees defined as straight forward, 90 degrees defined as left of default camera position
        if (x > 0 && z < 0)  // top left quadrant, 0-90
            circular = -angle;
        else if (x > 0 && z > 0)  // bottom left quadrant, 90-180
            circular = (90 - angle) + 90;
        else if (x < 0 && z > 0) // bottom right quadrant, 180-270
            circular = -angle + 180;
        else // top right quadrant, 270-360
            circular = (90 - angle) + 270;
        return circular;
    }
}