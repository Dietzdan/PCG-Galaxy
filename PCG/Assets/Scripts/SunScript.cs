using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour {

    Color randomcolor;
	// Use this for initialization
	void Start () {
        randomcolor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        GetComponent<Light>().color = randomcolor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
