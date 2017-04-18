using UnityEngine;
using System.Collections;

public class Origina_Position : MonoBehaviour {

    public Vector3 original_test_position;//The original position of the test
    public Quaternion original_test_rotation;//The original rotation of the test


    // Use this for initialization
    void Start () {

      original_test_position = transform.position;
      original_test_rotation = transform.rotation;
    }

    void Update()
    {
        /*If the player is not looking at the test and trying to cheat then return the test to its original position*/
        
            transform.position = original_test_position;
            transform.rotation = original_test_rotation;
       
        
    }


}
