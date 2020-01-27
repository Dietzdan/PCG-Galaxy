using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpawners : MonoBehaviour {

   public GameObject AstrodeSpawner;
   public GameObject ShipSpawner;
    public GameObject DebrisSpawner;
    public GameObject Waypoint;

    // Use this for initialization
    void Start () {
     SpawnAsteriodsFields();
        SpawnSpaceShips();
        SpawnDebris();
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
            Instantiate(Waypoint, transform.position + new Vector3(x, 0, z), Quaternion.identity);
        }
    }

    void SpawnSpaceShips()
    {
        for(int i = 0; i<5;i++)
        {
            int y = Random.Range(0, 10);
            int z = Random.Range(0, 200);
            Instantiate(ShipSpawner, transform.position + new Vector3(-100, 0, z), Quaternion.identity);
        }
    }

    void SpawnDebris()
    {
        for (int i = 0; i < 5; i++)
        {
            int x = Random.Range(0, 200);
            int z = Random.Range(0, 200);
            Instantiate(DebrisSpawner, transform.position + new Vector3(x, 0, z), Quaternion.identity);
            Instantiate(Waypoint, transform.position + new Vector3(x, 0, z), Quaternion.identity);
        }
    }
}
