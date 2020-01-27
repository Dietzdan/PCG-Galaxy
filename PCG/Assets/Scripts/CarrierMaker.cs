using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierMaker : MonoBehaviour {
    float timecounter;
    float speed;
    float height;
    float width;
    List<GameObject> Attachments = new List<GameObject>();
    Color randomcolor;
    // Use this for initialization
    void Start()
    {
        timecounter = 0;
        speed = 0.01f;
        height = 20;
        width = 10;

        randomcolor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        GetComponent<Renderer>().material.color = randomcolor;
        for (int x = 0; x < this.transform.childCount; x++)
        {
            Attachments.Add(this.transform.GetChild(x).gameObject);
        }
        chooseEngine();

        Attachments[3].transform.GetChild(0).GetComponent<Renderer>().material.color = randomcolor;
        Attachments[3].transform.GetChild(1).GetComponent<Renderer>().material.color = randomcolor;
        Attachments[4].transform.GetChild(0).GetComponent<Renderer>().material.color = randomcolor;
        Attachments[4].transform.GetChild(1).GetComponent<Renderer>().material.color = randomcolor;
        //this.transform.Rotate(Vector3.left, 90.0f);
    }

    // Update is called once per frame
    void Update () {
       MoveDorcilFins();
        //Cruise();
	}

    void chooseEngine()
    {
        int enginetype = Random.Range(0, 3);
        //big engine
        if (enginetype == 0)
        {
            Attachments[2].GetComponent<Renderer>().material.color = randomcolor;
            Destroy(Attachments[0]);
            Destroy(Attachments[1]);
        }
        //twin
        if (enginetype == 1)
        {
            Attachments[1].transform.GetChild(0).GetComponent<Renderer>().material.color = randomcolor;
            Attachments[1].transform.GetChild(1).GetComponent<Renderer>().material.color = randomcolor;
            Destroy(Attachments[0]);
            Destroy(Attachments[2]);
        }
        //tri
        if (enginetype == 2)
        {
            Attachments[0].transform.GetChild(0).GetComponent<Renderer>().material.color = randomcolor;
            Attachments[0].transform.GetChild(1).GetComponent<Renderer>().material.color = randomcolor;
            Attachments[0].transform.GetChild(2).GetComponent<Renderer>().material.color = randomcolor;
            Destroy(Attachments[1]);
            Destroy(Attachments[2]);
        }

    }

    void MoveDorcilFins()
    {

        float angle = Mathf.Sin(Time.time);
        //float angle = Mathf.PerlinNoise(-15, 40);
        
        Attachments[3].transform.GetChild(0).Rotate(Vector3.left, angle);
        Attachments[3].transform.GetChild(1).Rotate(Vector3.right, angle);
        Attachments[4].transform.GetChild(0).Rotate(Vector3.left, angle);
        Attachments[4].transform.GetChild(1).Rotate(Vector3.right, angle);

    }

    
   void Cruise()
    {

        //transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
        timecounter += Time.deltaTime * speed;
        
        float x = Mathf.Cos(timecounter) * width;
        float y = Mathf.Sin(timecounter) * height;
        //float z = 0;
        transform.RotateAround(Vector3.zero, new Vector3(0, y, 0), 20 * Time.deltaTime);
        transform.Rotate(new Vector3(x, y, 0), Time.deltaTime);
        //transform.position += new Vector3(x, 0, y);
    }

   
}
