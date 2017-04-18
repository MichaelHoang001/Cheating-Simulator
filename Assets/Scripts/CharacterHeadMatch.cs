using UnityEngine;
using System.Collections;

public class CharacterHeadMatch : MonoBehaviour {

    public GameObject fps_camera;
    public Animator animator;
    bool turn_off_animation = false;
	// Use this for initialization
	void Start () {
		animator.enabled = true;
	}


   // int i = 0;
	// Update is called once per frame
	void Update () {

        /*
                if(!turn_off_animation)
                {
                    StartCoroutine(StopAnimation());
                    animator.enabled = false;
                    turn_off_animation = true;
                }
        */
        //I want to have the animation run and then freeze so the model stays sitting.
       // if(i < 5) { i++; } //Lets the animation play.
       // if(i == 5) { } //Then pauses the animation to stay sitting.
        //Now I can move the head of the character now that the animation stopped.

		if (Input.GetKeyDown (KeyCode.F9)) {
			animator.enabled = false; 
		}

        transform.rotation = fps_camera.transform.rotation;
    }

    IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(1);
        animator.enabled = false;
        turn_off_animation = true;
       
    }
}


