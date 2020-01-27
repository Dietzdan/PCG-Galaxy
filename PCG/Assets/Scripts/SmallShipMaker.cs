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

    
    List<GameObject> Attachments = new List<GameObject>();
    Color pink = new Color32(231, 80, 130,0);
    Color orange = new Color32(235, 64, 11,0);
    float speed = 2f;
    Vector3 destination;
    Vector3 OrginalPos;
    Color randomcolor;
    // Use this for initialization
    void Start () {

        randomcolor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        GetComponent<Renderer>().material.color = randomcolor;
        for (int x =0; x < transform.childCount; x++)
        {
            Attachments.Add(transform.GetChild(x).gameObject);
            
            
        }
        chooseEngine();
        chooseWings();
       
      

        OrginalPos = transform.position;
        destination = CheckOverlap();
    }
	
	// Update is called once per frame
	void Update () {
        Move(destination);

        float dist = Vector3.Distance(gameObject.transform.position, destination);
       
        if (dist < 1)
        {
            destination = OrginalPos;
        }
	}

    Vector3 CheckOverlap()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 60);
        int x = Random.Range(0, hitColliders.Length);
        if (hitColliders[x].tag == "Ship" || hitColliders[x].tag == "Way")
        {
            x = Random.Range(0, hitColliders.Length);
        }

        return hitColliders[x].transform.position;

    }

    void Move(Vector3 Pos)
    {
        gameObject.transform.LookAt(Pos);
        transform.Rotate(Vector3.left, 90.0f);
        transform.Rotate(Vector3.forward, 90.0f);
        transform.position -= transform.right * speed * Time.deltaTime;
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

    void chooseEngine()
    {
        int enginetype = Random.Range(0,3);
        //big engine
        if (enginetype == 0)
        {
            Attachments[4].GetComponent<Renderer>().material.color = randomcolor;
            Destroy(Attachments[2]);
            Destroy(Attachments[3]);
            
        } 
        //twin
        if(enginetype == 1)
        {
            Attachments[3].transform.GetChild(0).GetComponent<Renderer>().material.color = randomcolor;
            Attachments[3].transform.GetChild(1).GetComponent<Renderer>().material.color = randomcolor;
            Destroy(Attachments[2]);
            Destroy(Attachments[4]);
        }
        //tri
        if(enginetype == 2)
        {
            Attachments[2].transform.GetChild(0).GetComponent<Renderer>().material.color = randomcolor;
            Attachments[2].transform.GetChild(1).GetComponent<Renderer>().material.color = randomcolor;
            Attachments[2].transform.GetChild(2).GetComponent<Renderer>().material.color = randomcolor;
            Destroy(Attachments[4]);
            Destroy(Attachments[3]);
        }

    }

    void chooseWings()
    {
        int Wingstype = Random.Range(0, 3);
        // no wings
        if(Wingstype == 0)
        {
            Destroy(Attachments[0]);
            Destroy(Attachments[1]);
        }
        //folded wings 
        if(Wingstype == 1)
        {
            Attachments[1].transform.GetChild(0).GetComponent<Renderer>().material.color = randomcolor;
            Attachments[1].transform.GetChild(1).GetComponent<Renderer>().material.color = randomcolor;
            Destroy(Attachments[0]);
        }
        //ponited wings
        if(Wingstype == 2)
        {
            Attachments[0].transform.GetChild(0).GetComponent<Renderer>().material.color = randomcolor;
            Attachments[0].transform.GetChild(1).GetComponent<Renderer>().material.color = randomcolor;
            Destroy(Attachments[1]);
        }
    }
}
