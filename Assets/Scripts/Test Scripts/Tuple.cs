using UnityEngine;
using System.Collections;

public class Tuple : MonoBehaviour {

    public int question_index;
    public string player_answer;

public Tuple(int question_index, string player_answer)
    {
        this.question_index = question_index;
        this.player_answer = player_answer;
    }
}
