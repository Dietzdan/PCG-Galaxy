﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstrodeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name.StartsWith("Astrorode"))
        {
            //destroys if theres an overlap
            Destroy(collision.gameObject);
           
           // this.transform.localScale += new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
