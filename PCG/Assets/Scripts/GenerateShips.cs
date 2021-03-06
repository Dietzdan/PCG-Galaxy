﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateShips : MonoBehaviour {
  
    public GameObject BigShipHull;
    public GameObject SmallShipHull;
    public GameObject Carrier;

     Vector3 Test = new Vector3(1.75f,-1.0f,-4.0f);
    //public GameObject Sphere;
    // Use this for initialization
    void Start () {

        MakeCarrier();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void MakeSmallShip()
    {
        
        Instantiate(SmallShipHull, transform.position, Quaternion.identity);
        //Tri engine Vector3(0.6f,-2.1f,0.6f)
        //Twin Engine new Vector3(0.35f,-1.3f,0.6f) Ship Hull 2 Scale 1.25f Pos Vector3(0.4f,-1.75f,0.6f)
        // Twin Engine scale Engine.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        
        //Big Engine new Vector3(0.0f,0.0f,0.7f)
      //  Instantiate(Engine, transform.position + new Vector3(0.0f,0.0f,0.7f), Quaternion.identity);
      //  GameObject.Find("Big Engine2(Clone)").transform.SetParent(GameObject.Find("ShipHull2(Clone)").transform);


    }
    void MakeBigShip()
    {

        Instantiate(BigShipHull, transform.position , Quaternion.identity);
        //Tri engine Vector3(0.6f,-2.1f,0.6f)
        //Twin Engine new Vector3(0.35f,-1.3f,0.6f) Ship Hull 2 Scale 1.25f Pos Vector3(0.4f,-1.75f,0.6f)
        // Twin Engine scale Engine.localScale = new Vector3(1.25f, 1.25f, 1.25f);

        //Big Engine new Vector3(0.0f,0.0f,0.7f)
        //  Instantiate(Engine, transform.position + new Vector3(0.0f,0.0f,0.7f), Quaternion.identity);
        //  GameObject.Find("Big Engine2(Clone)").transform.SetParent(GameObject.Find("ShipHull2(Clone)").transform);


    }

    void MakeCarrier()
    {
        Instantiate(Carrier, transform.position, Quaternion.identity);
    }




   public void CarrierDeploy()
    {
        for(int i =0;i<3;i++)
        {
            int shiptype = Random.Range(0, 2);
            if(shiptype == 0)
             {
                MakeSmallShip();
             }

            if(shiptype == 1)
            {
                MakeBigShip();
            }
            Test.z += 2;
        }
    }
    void PyramidFormation()
    {
        for (int i = 0; i < 10; i++)
        {
            int shiptype = Random.Range(0, 2);

            if (shiptype == 0)
            {
                MakeBigShip();
            }
            if (shiptype == 1)
            {
                MakeSmallShip();
            }
            if (i == 0)
            {
                Test.y -= 2.0f;
                Test.x = -4.0f;

            }
            Test.x += 2.0f;
            if (i == 2)
            {
                Test.y -= 2.0f;
                Test.x = -4.0f;
            }

            if (i == 5)
            {
                Test.y -= 2.0f;
                Test.x = -6.0f;
            }
            Test.x += 2.0f;
        }
    }

    void SquareFormation()
    {
        Test.x = 0.0f;

        for (int i = 0; i < 20; i++)
        {
            int shiptype = Random.Range(0, 2);
            if (i % 5 == 0 && i != 0)
            {
                Test.y -= 2.0f;
                Test.x = 0.0f;
            }
            if (shiptype == 0)
            {
                MakeBigShip();
            }
            if (shiptype == 1)
            {
                MakeSmallShip();
            }


            Test.x += 2.0f;
        }
    }

    
}
