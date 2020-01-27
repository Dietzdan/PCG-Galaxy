using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierAi : MonoBehaviour {
    public GameObject[] Waypoints; 
    int num;
    int shipcounter;

   public float minDist;
   public float speed;

    public bool go;
    bool shipsDeployed;
    

    List<GameObject> Attachments = new List<GameObject>();

    public GameObject BigShipHull;
    public GameObject SmallShipHull;

    Vector3 Test;
    // Use this for initialization
    void Start () {
      Test = new Vector3(1.75f, -1.0f, -4.0f);
        int shipcounter = 0;
        go = true;
        shipsDeployed = false;
        Waypoints = GameObject.FindGameObjectsWithTag("Way");
        num = Random.Range(0, Waypoints.Length);
        

        speed = 5.0f;
        minDist = 20.0f;

       // this.GetComponent<GenerateShips>().CarrierDeploy();

        for (int x = 0; x < this.transform.childCount; x++)
        {
            Attachments.Add(this.transform.GetChild(x).gameObject);
        }
       
        
       
    }
	
	// Update is called once per frame
	void Update () {
        if (Waypoints.Length < 1)
        {
            Waypoints = GameObject.FindGameObjectsWithTag("Way");
        }
        FindWaypoint();
        if (go == false && shipsDeployed == false)
        {
            Hover();
        }

        if(shipcounter == 6)
        {
            go = true;
            shipsDeployed = false;
            shipcounter = 0;
        }

    }
    void FindWaypoint()
    {
        
        
        float dist = Vector3.Distance(gameObject.transform.position, Waypoints[num].transform.position);

        if (go == true)
        {
            if(dist>minDist)
            {
                Move();
            }
            else
            {
                num = Random.Range(0, Waypoints.Length);
            }
        }
    }

    void Move()
    {
        gameObject.transform.LookAt(Waypoints[num].transform.position);
        transform.Rotate(Vector3.left, 90.0f);
        transform.Rotate(Vector3.forward, 90.0f);
        transform.position -= transform.right * speed * Time.deltaTime;
    }



    public void CarrierDeploy()
    {
        for (int i = 0; i < 3; i++)
        {
            int shiptype = Random.Range(0, 2);
            if (shiptype == 0)
            {
                MakeSmallShip();
            }

            if (shiptype == 1)
            {
                MakeBigShip();
            }
           
        }

        
        //go = true;
       
        
    }

    void MakeBigShip()
    {
        Instantiate(BigShipHull, transform.position, Quaternion.identity);
 
    }

    void MakeSmallShip()
    {

        Instantiate(SmallShipHull, transform.position, Quaternion.identity);
      
    }

    void Hover()
    {

        
        
            transform.position += Vector3.up * speed * Time.deltaTime;
           

        if (transform.position.y > 15)
        {
           
            CarrierDeploy();
            shipsDeployed = true;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name.StartsWith("Waypoint") )
        {
            print("Waypoint");
            go = false;
            int temp = num;
            num = Random.Range(0, Waypoints.Length);
            while (num == temp)
            {
                num = Random.Range(0, Waypoints.Length);
            }


        }

        if (collision.name.StartsWith("Ship"))
        {
            shipcounter++;
            if(shipcounter > 3)
            {
                Destroy(collision.gameObject);
            }
        }

        

        
    }
}
