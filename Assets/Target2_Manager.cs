using UnityEngine;
using System.Collections;

public class Target2_Manager : MonoBehaviour
{

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
            other.GetComponent<TeacherMovement>().NextPoint(3);
            //we've just hit target2 so now go to target3
            //nextpoint updates the teacher's path to whatever is passed to it
            //Debug.Log("COLLIDED WITH TARGET TWO");
        }
    }
}
