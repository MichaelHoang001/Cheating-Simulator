using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherRayCaster : MonoBehaviour {
    public Camera main_camera;
    public float distance = 1000f;
    public Vector3 camera_position;

    //Need these references to calculate distance between the student and teacher
    public GameObject teacher;
    public GameObject student;

    Vector3 current_student_position;
    Vector3 current_teacher_position;

    public float distance_between_student_and_teacher;
    public string sum;

    public float[] parts_of_sum = new float [18];
  
    //Central Ray

    //15
    Ray center; RaycastHit hit_center;
    Ray deg8; RaycastHit hit_deg8;
    Ray deg15; RaycastHit hit_deg15;
    Ray deg30; RaycastHit hit_deg30;
    Ray deg45; RaycastHit hit_deg45;
    Ray deg60; RaycastHit hit_deg60;
    Ray deg70; RaycastHit hit_deg70;
    Ray deg80; RaycastHit hit_deg80;
    Ray deg90; RaycastHit hit_deg90;
    Ray deg100; RaycastHit hit_deg100;
    Ray degm8; RaycastHit hit_degm8;
    Ray degm15; RaycastHit hit_degm15;
    Ray degm30; RaycastHit hit_degm30;
    Ray degm45; RaycastHit hit_degm45;
    Ray degm60; RaycastHit hit_degm60;
    Ray degm70; RaycastHit hit_degm70;
    Ray degm80; RaycastHit hit_degm80;
    Ray degm90; RaycastHit hit_degm90;
    Ray degm100; RaycastHit hit_degm100;


    int cent = 60;
    int ray15_30 = 48;
    int ray45_60 = 36;
    int ray70_80 = 20;
    int ray90_100 = 8;

    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        current_student_position = student.transform.position;
        current_teacher_position = teacher.transform.position;


        camera_position = main_camera.transform.position;


        //Central Ray

        //60
         center = new Ray(main_camera.transform.position, main_camera.transform.forward * distance);
        Debug.DrawRay(main_camera.transform.position, center.origin + main_camera.transform.forward * distance, Color.blue);

        //Right peripheral
        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(8, main_camera.transform.up) * main_camera.transform.forward * distance, Color.green);
         deg8 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(8, main_camera.transform.up) * main_camera.transform.forward);



        //48
        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(15, main_camera.transform.up) * main_camera.transform.forward * distance, Color.white);
         deg15 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(15, main_camera.transform.up) * main_camera.transform.forward);

        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(30, main_camera.transform.up) * main_camera.transform.forward * distance, Color.yellow);
         deg30 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(30, main_camera.transform.up) * main_camera.transform.forward);


        //36
        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(45, main_camera.transform.up) * main_camera.transform.forward * distance, Color.black);
         deg45 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(45, main_camera.transform.up) * main_camera.transform.forward);

        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(60, main_camera.transform.up) * main_camera.transform.forward * distance, Color.gray);
         deg60 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(60, main_camera.transform.up) * main_camera.transform.forward);


        //20
        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(70, main_camera.transform.up) * main_camera.transform.forward * distance, Color.cyan);
         deg70 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(70, main_camera.transform.up) * main_camera.transform.forward);

       
        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(80, main_camera.transform.up) * main_camera.transform.forward * distance, Color.magenta);
         deg80 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(80, main_camera.transform.up) * main_camera.transform.forward);
        //8
        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(90, main_camera.transform.up) * main_camera.transform.forward * distance, Color.red);
         deg90 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(90, main_camera.transform.up) * main_camera.transform.forward);

        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(100, main_camera.transform.up) * main_camera.transform.forward * distance, Color.red);
         deg100 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(100, main_camera.transform.up) * main_camera.transform.forward);



        //Left peripheral
        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(-8, main_camera.transform.up) * main_camera.transform.forward * distance, Color.green);
         degm8 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(-8, main_camera.transform.up) * main_camera.transform.forward);

        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(-15, main_camera.transform.up) * main_camera.transform.forward * distance, Color.white);
         degm15 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(-15, main_camera.transform.up) * main_camera.transform.forward);

        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(-30, main_camera.transform.up) * main_camera.transform.forward * distance, Color.yellow);
         degm30 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(-30, main_camera.transform.up) * main_camera.transform.forward);

        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(-45, main_camera.transform.up) * main_camera.transform.forward * distance, Color.black);
         degm45 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(-45, main_camera.transform.up) * main_camera.transform.forward);

        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(-60, main_camera.transform.up) * main_camera.transform.forward * distance, Color.gray);
         degm60 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(-60, main_camera.transform.up) * main_camera.transform.forward);

        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(-70, main_camera.transform.up) * main_camera.transform.forward * distance, Color.cyan);
         degm70 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(-70, main_camera.transform.up) * main_camera.transform.forward);

        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(-80, main_camera.transform.up) * main_camera.transform.forward * distance, Color.magenta);
         degm80 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(-80, main_camera.transform.up) * main_camera.transform.forward);

        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(-90, main_camera.transform.up) * main_camera.transform.forward * distance, Color.red);
         degm90 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(-90, main_camera.transform.up) * main_camera.transform.forward);

        Debug.DrawRay(main_camera.transform.position, Quaternion.AngleAxis(-100, main_camera.transform.up) * main_camera.transform.forward * distance, Color.red);
         degm100 = new Ray(main_camera.transform.position, Quaternion.AngleAxis(-100, main_camera.transform.up) * main_camera.transform.forward);




        //Calculate the distance between student and teacher
        distance_between_student_and_teacher = Mathf.Sqrt ( Mathf.Pow((current_student_position.x - current_teacher_position.x), 2) + Mathf.Pow((current_student_position.z - current_teacher_position.z), 2));



       

        //When the ray "center" collides with an object it is stored in the variable "hit"
        //So then we check what that center collide with, by checking the tag of the object contained in hit
        if (Physics.Raycast(center, out hit_center))                                        
        {
          
            //If it is the player character then do calculations
            if (hit_center.collider.gameObject.tag == "Player")                   
            {

                Debug.Log("Center ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[0] = -1;
            }

            else
            {
                 parts_of_sum[0] = 0;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////

        if (Physics.Raycast(deg8, out hit_deg8))
        {

            //If it is the player character then do calculations
            if (hit_deg8.collider.gameObject.tag == "Player")
            {

                Debug.Log("deg8 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[1] = 8;
            }

            else
            {
                parts_of_sum[1] = 0;
            }
        }

        if (Physics.Raycast(degm8, out hit_degm8))
        {

            //If it is the player character then do calculations
            if (hit_degm8.collider.gameObject.tag == "Player")
            {

                Debug.Log("degm8 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[2] = -8;
            }

            else
            {
                parts_of_sum[2] = 0;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////


        if (Physics.Raycast(deg15, out hit_deg15))
        {

            //If it is the player character then do calculations
            if (hit_deg15.collider.gameObject.tag == "Player")
            {

                Debug.Log("deg15 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[3] = 15;
            }

            else
            {
                parts_of_sum[3] = 0;
            }
        }

        if (Physics.Raycast(degm15, out hit_degm15))
        {

            //If it is the player character then do calculations
            if (hit_degm15.collider.gameObject.tag == "Player")
            {

                Debug.Log("degm15 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[4] = -15;
            }

            else
            {
                parts_of_sum[4] = 0;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////

        if (Physics.Raycast(deg30, out hit_deg30))
        {

            //If it is the player character then do calculations
            if (hit_deg30.collider.gameObject.tag == "Player")
            {

                Debug.Log("deg30 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[5] = 30;
            }

            else
            {
                parts_of_sum[5] = 0;
            }
        }

        if (Physics.Raycast(degm30, out hit_degm30))
        {

            //If it is the player character then do calculations
            if (hit_degm30.collider.gameObject.tag == "Player")
            {

                Debug.Log("degm30 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[6] = -30;
            }

            else
            {
                parts_of_sum[6] = 0;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////

        if (Physics.Raycast(degm45, out hit_degm45))
        {

            //If it is the player character then do calculations
            if (hit_degm45.collider.gameObject.tag == "Player")
            {

                Debug.Log("degm45 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[7] = -45;
            }

            else
            {
                parts_of_sum[7] = 0;
            }
        }

        if (Physics.Raycast(deg45, out hit_deg45))
        {

            //If it is the player character then do calculations
            if (hit_deg45.collider.gameObject.tag == "Player")
            {

                Debug.Log("deg45 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[8] = 45;
            }

            else
            {
                parts_of_sum[8] = 0;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////


        if (Physics.Raycast(deg60, out hit_deg60))
        {

            //If it is the player character then do calculations
            if (hit_deg60.collider.gameObject.tag == "Player")
            {

                Debug.Log("deg60 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[9] = 60;
            }

            else
            {
                parts_of_sum[9] = 0;
            }
        }


        if (Physics.Raycast(degm60, out hit_degm60))
        {

            //If it is the player character then do calculations
            if (hit_degm60.collider.gameObject.tag == "Player")
            {

                Debug.Log("degm60 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[10] = -60;
            }

            else
            {
                parts_of_sum[10] = 0;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////

        if (Physics.Raycast(deg70, out hit_deg70))
        {

            //If it is the player character then do calculations
            if (hit_deg70.collider.gameObject.tag == "Player")
            {

                Debug.Log("deg70 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[11] = 70;
            }

            else
            {
                parts_of_sum[11] = 0;
            }
        }

        if (Physics.Raycast(degm70, out hit_degm70))
        {

            //If it is the player character then do calculations
            if (hit_degm70.collider.gameObject.tag == "Player")
            {

                Debug.Log("degm70 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[12] = -70;
            }

            else
            {
                parts_of_sum[12] = 0;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////

        if (Physics.Raycast(deg80, out hit_deg80))
        {

            //If it is the player character then do calculations
            if (hit_deg80.collider.gameObject.tag == "Player")
            {

                Debug.Log("deg80 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[13] = 80;
            }

            else
            {
                parts_of_sum[13] = 0;
            }
        }


        if (Physics.Raycast(degm80, out hit_degm80))
        {

            //If it is the player character then do calculations
            if (hit_degm80.collider.gameObject.tag == "Player")
            {

                Debug.Log("degm80 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[14] = -80;
            }

            else
            {
                parts_of_sum[14] = 0;
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////

        if (Physics.Raycast(deg90, out hit_deg90))
        {

            //If it is the player character then do calculations
            if (hit_deg90.collider.gameObject.tag == "Player")
            {

                Debug.Log("deg90 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[15] = 90;
            }

            else
            {
                parts_of_sum[15] = 0;
            }
        }

        if (Physics.Raycast(degm90, out hit_degm90))
        {

            //If it is the player character then do calculations
            if (hit_degm90.collider.gameObject.tag == "Player")
            {

                Debug.Log("degm90 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[16] = -90;
            }

            else
            {
                parts_of_sum[16] = 0;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////

        if (Physics.Raycast(deg100, out hit_deg100))
        {

            //If it is the player character then do calculations
            if (hit_deg100.collider.gameObject.tag == "Player")
            {

                Debug.Log("deg100 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[17] = 100;
            }

            else
            {
                parts_of_sum[17] = 0;
            }
        }

        if (Physics.Raycast(degm100, out hit_degm100))
        {

            //If it is the player character then do calculations
            if (hit_degm100.collider.gameObject.tag == "Player")
            {

                Debug.Log("degm100 ray collide with player");
                //Calculate what the weight of the ray is
                parts_of_sum[18] = -100;
            }

            else
            {
                parts_of_sum[18] = 0;
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////

        sum = CalcSum();
        
    }

    public string CalcSum()
    {
        string temp = "";
        for(int i = 0; i < parts_of_sum.Length; i++)
        {
            temp += parts_of_sum[i] + "   ";
        }

        return temp;
    }
}
