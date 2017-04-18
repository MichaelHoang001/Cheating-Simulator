using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraserDistract : MonoBehaviour {
    private bool contact;
    public GameObject teacher;

	// Use this for initialization
	void Start () {
        teacher = GameObject.Find("Teacher");
        contact = false;
	}
	
	void OnCollisionEnter (Collision collision) {
        if (!contact) {
            contact = true;
            int distractSeconds = 3;
            teacher.GetComponent<TeacherMovement>().EraserAttention = distractSeconds*30; // 30 frames per second
            teacher.GetComponent<TeacherMovement>().EraserLocation = transform.position;
        }
    }
}
