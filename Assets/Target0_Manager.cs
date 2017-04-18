using UnityEngine;
using System.Collections;

public class Target0_Manager : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name == "Teacher")
        {
            other.GetComponent<TeacherMovement>().NextPoint(1);
            //we've just hit target1 so now go to target2
            //nextpoint updates the teacher's path to whatever is passed to it
           // Debug.Log("COLLIDED WITH START POSITION");
        }
    }
}