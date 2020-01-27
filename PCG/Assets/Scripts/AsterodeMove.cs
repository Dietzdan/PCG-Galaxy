using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterodeMove : MonoBehaviour {
    float bob;
    // Use this for initialization
    void Start () {
        bob = Random.Range(200,501); //Random.Range(90, 100);
       
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        float x;
        if (this.transform.position.y < 6)
        {
             x = Mathf.Sin(Time.time)/ bob;
        }
        else
        {
             x = Mathf.Sin(Time.time)/ -bob;
        }
        this.transform.Translate(new Vector3(0, x, 0));
    }

    
}
