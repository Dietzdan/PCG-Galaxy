using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallShipMaker : MonoBehaviour {
    public GameObject PointedLWings;
    public GameObject PointedRWings;
    public GameObject FoldWings;
    public GameObject BigEngine;
    public GameObject TriEngine;
    public GameObject TwinEngine;
    // Use this for initialization
    void Start () {
        placeEngine();
        placeWings();
        this.transform.Rotate(Vector3.left, 90.0f);
        this.transform.Rotate(Vector3.back, 90.0f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void placeEngine()
    {
        int enginetype = Random.Range(0, 3);
        if (enginetype == 0)
        {
            BigEngine.transform.localScale = new Vector3(0.25f, 0.14f, 0.1f);
            Instantiate(BigEngine, transform.position + new Vector3(0.0f, -0.12f, 0.8f), Quaternion.identity);
        }

        if(enginetype == 1)
        {
            //twin Enigine
             TwinEngine.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
             Instantiate(TwinEngine, transform.position + new Vector3(0.23f, -1.2f, .8f), Quaternion.identity);
        }
        
        if(enginetype == 2)
        {
            //TriEnigine 
            TriEngine.transform.localScale = new Vector3(1f, 0.5f, 0.5f);
            Instantiate(TriEngine, transform.position + new Vector3(0.31f, -0.9f, 0.8f), Quaternion.identity);
        }
        
    }
    void placeWings()
    {
        //pointed wings
        
        Instantiate(FoldWings, transform.position + new Vector3(-2.0f, -.25f, 0.2f), Quaternion.Euler(new Vector3(0.0f,-90.0f,0.0f)));
        
    }
}
