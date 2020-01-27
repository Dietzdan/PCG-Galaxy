using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShipMaker : MonoBehaviour {
 
    public GameObject BigEngine;
    public GameObject TriEngine;
    public GameObject TwinEngine;
    List<GameObject> Attachments = new List<GameObject>();
    float speed = 2f;
    Vector3 destination;
    Vector3 OrginalPos;
    Color randomcolor;
    // Use this for initialization
    void Start () {

        randomcolor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        GetComponent<Renderer>().material.color = randomcolor;
        for (int x = 0; x < this.transform.childCount; x++)
        {
            Attachments.Add(this.transform.GetChild(x).gameObject);
        }
        chooseEngine();

        
        OrginalPos = this.transform.position;
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
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100);
        
        int x = Random.Range(0, hitColliders.Length);
        print(hitColliders.Length);
        //watch this while loop causes crashes
      if (hitColliders[x].tag == "Ship" || hitColliders[x].tag == "Way")
        {
           x = Random.Range(0, hitColliders.Length);
        }

        return hitColliders[x].transform.position;

    }

    void Move(Vector3 Pos)
    {
        gameObject.transform.LookAt(Pos);
        transform.Rotate(Vector3.left, 180.0f);
        transform.position -= transform.forward * speed * Time.deltaTime;
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

    void chooseEngine()
    {
        int enginetype = Random.Range(0, 3);
        //big engine
        if (enginetype == 0)
        {
            Attachments[0].GetComponent<Renderer>().material.color = randomcolor;
            Destroy(Attachments[1]);
            Destroy(Attachments[2]);
        }
        //twin
        if (enginetype == 1)
        {
            Attachments[2].transform.GetChild(0).GetComponent<Renderer>().material.color = randomcolor;
            Attachments[2].transform.GetChild(1).GetComponent<Renderer>().material.color = randomcolor;
            Destroy(Attachments[0]);
            Destroy(Attachments[1]);
        }
        //tri
        if (enginetype == 2)
        {
            Attachments[1].transform.GetChild(0).GetComponent<Renderer>().material.color = randomcolor;
            Attachments[1].transform.GetChild(1).GetComponent<Renderer>().material.color = randomcolor;
            Attachments[1].transform.GetChild(2).GetComponent<Renderer>().material.color = randomcolor;
            Destroy(Attachments[0]);
            Destroy(Attachments[2]);
        }

    }
    
}
