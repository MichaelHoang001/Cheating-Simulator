using UnityEngine;
using System.Collections;

public class Reticle : MonoBehaviour {
    public Camera player_camera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player_camera.transform.position + player_camera.transform.forward;
      //  print(player_camera.transform.position);
      //  print(transform.position);
	}
}
