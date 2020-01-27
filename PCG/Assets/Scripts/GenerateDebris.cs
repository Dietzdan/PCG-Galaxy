using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDebris : MonoBehaviour {
    public GameObject WingDebris;
    public GameObject WingDebris2;
    public GameObject EngineDebris;
    public GameObject EngineDebris2;
    public GameObject EngineDebris3;
    public GameObject DeadShip;
    List<GameObject> DebrisParts = new List<GameObject>();
    // Use this for initialization
    void Start () {
        DebrisParts.Add(WingDebris);
        DebrisParts.Add(WingDebris2);
        DebrisParts.Add(EngineDebris);
        DebrisParts.Add(EngineDebris2);
        DebrisParts.Add(EngineDebris3);
        DebrisParts.Add(DeadShip);

        SpawnDebris();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnDebris()
    {
       
        int NumDebris = Random.Range(10, 50);
        for (int i = 0; i < NumDebris; i++)
        {
            int debrisitem = Random.Range(0, 6);
            float angle = Random.Range(0, 360);
            float distance = Random.Range(0, 20);
            angle *= Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * distance;
            float z = Mathf.Sin(angle) * distance;
            float height = Mathf.PerlinNoise(x, z) * 10;
            Instantiate(DebrisParts[debrisitem], transform.position + new Vector3(x, height, z), Quaternion.identity);
        }
    }
}
