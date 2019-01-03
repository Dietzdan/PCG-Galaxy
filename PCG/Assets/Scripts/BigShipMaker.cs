using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShipMaker : MonoBehaviour {
 
    public GameObject BigEngine;
    public GameObject TriEngine;
    public GameObject TwinEngine;
    // Use this for initialization
    void Start () {
        PlaceEngine();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlaceEngine()
    {
        //Tri engine Vector3(0.6f,-2.1f,0.6f)
        //Twin Engine new Vector3(0.35f,-1.3f,0.6f) Ship Hull 2 Scale 1.25f Pos Vector3(0.4f,-1.75f,0.6f)
        // Twin Engine scale Engine.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        int enginetype = Random.Range(0, 3);
            //Random.Range(0, 2);


        if (enginetype == 0)
        {
            BigEngine.transform.localScale = new Vector3(0.35f, 0.4f, 0.2f);
            Instantiate(BigEngine, transform.position + new Vector3(0.0f, 0.0f, 0.7f), Quaternion.identity);
        }

        if(enginetype == 1)
        {
            TwinEngine.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
            Instantiate(TwinEngine, transform.position + new Vector3(0.4f, -1.75f, 0.6f), Quaternion.identity);
        }

        if (enginetype == 2)
        {
            TriEngine.transform.localScale = new Vector3(1.5f, 1.37f, 1.25f);
            Instantiate(TriEngine, transform.position + new Vector3(0.5f, -2.1f, 0.6f), Quaternion.identity);
        }
    }
}
