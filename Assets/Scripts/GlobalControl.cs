using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalControl : MonoBehaviour {

	//This script is used for continuous data throughout each round of the game
	public static GlobalControl Instance;
	//The current Round
	public int round = 1;
	//The test questions that were chosen aleady
	public List<int> oldQuestions = new List<int>();  


	// Use this for initialization
	void Awake () {
	
	

		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		} else if (Instance != this) {
			Destroy (gameObject);
		}
	}

	public void IncreaseRound(){
		round++;
	}

}
