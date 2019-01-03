using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpawners : MonoBehaviour {

   public GameObject AstrodeSpawner;
   public GameObject ShipSpawner;

	// Use this for initialization
	void Start () {
        //SpawnAsteriodsFields();
        SpawnSpaceShips();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnAsteriodsFields()
    {
        for (int i = 0; i < 5; i++)
        {
            int x = Random.Range(0, 200);
            int z = Random.Range(0, 200);
            Instantiate(AstrodeSpawner, transform.position + new Vector3(x, 0, z), Quaternion.identity);
        }
    }

    void SpawnSpaceShips()
    {
        for(int i = 0; i<5;i++)
        {
            int x = Random.Range(0, 200);
            int z = Random.Range(0, 200);
            Instantiate(ShipSpawner, transform.position + new Vector3(x, 0, z), Quaternion.identity);
        }
    }
}
