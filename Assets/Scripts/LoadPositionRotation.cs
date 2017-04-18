using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System;

public class LoadPositionRotation : MonoBehaviour {
    StreamReader teach_pos = new StreamReader("C: \\Users\\Mark\\Desktop\\(Last Updated 10.17.2016) Cheating Simulator  by Mark");
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

        print(teach_pos.ReadLine());
    }
}
