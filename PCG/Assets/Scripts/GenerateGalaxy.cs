using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGalaxy : MonoBehaviour {
    public GameObject Astrorode;
    public GameObject Astrorode2;
    public GameObject Astrorode3;


    //public GameObject Sphere;
    // Use this for initialization
    void Start () {
        
        SpawnStars();
        
       //add parent 
       // GameObject.Find("Big Engine2(Clone)").transform.SetParent(GameObject.Find("ShipHull2(Clone)").transform);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnStars()
    {
       
        
        float distance;
        float angle;
        float height;
        for (int i =0; i < 100; i++)
        {
            angle = Random.Range(0, 360);
            distance = Random.Range(0, 20);
            
            angle *= Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * distance;
            float z = Mathf.Sin(angle) * distance;
            height = Mathf.PerlinNoise(x, z)*10;

            int num = Random.Range(0, 3);
            if (num == 0)
            {
                Instantiate(Astrorode, transform.position + new Vector3(x, height, z), Quaternion.identity);
            }

            if (num == 1)
            {
                Instantiate(Astrorode2, transform.position + new Vector3(x, height, z), Quaternion.identity);
            }

            if (num == 2)
            {
                Instantiate(Astrorode3, transform.position + new Vector3(x, height, z), Quaternion.identity);
            }



            //transform.position + new Vector3(x, 0, y);
        }


    }

    void SpiralStars()
    {
        float A = 40f;
        float B = 11.12f;
        float N = 0.706f;

        for (int i = 0;i<360*5;i++)
        {
            float anglerads = i * Mathf.Deg2Rad;
            float dist = A / Mathf.Log10(B * Mathf.Tan(anglerads / (2 * N)));
            float offset = Random.Range(-10f, 10f) * Mathf.Deg2Rad;
            float x = Mathf.Cos(anglerads) * dist;
            float z = Mathf.Sin(anglerads) * dist;

            if (dist < Mathf.Abs(A))
            {
                Instantiate(Astrorode, transform.position + new Vector3(x, 0, z), Quaternion.identity);
            }

        }

    }

  

}
