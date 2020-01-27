using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisScript : MonoBehaviour {
    public int Direction;
   
    // Use this for initialization
    void Start()
    {
        Direction = Random.Range(0, 6);
        int x = Random.Range(0, 360);
        int y = Random.Range(0, 360);
        int z = Random.Range(0, 360);
        int angle = Random.Range(0, 360);

        this.transform.Rotate(new Vector3(x, y, z), angle);
      
       

        //mesh deformation not complete
       // Mesh mesh = GetComponent<MeshFilter>().mesh;
       // Vector3[] vertices = mesh.vertices;
       // Vector3[] normals = mesh.normals;
       // int [] Triangles = mesh.triangles;
        
       // int i = 0;

       //for (i = 0; i < vertices.Length; i++)
       //  {
       //    float x = Random.Range(0, 5);
       //     vertices[i] += new Vector3(x, 0.0f, 0.0f);
       //     print(i+ " "+ vertices[i]);

       // }

       // mesh.vertices = vertices;
        //  rightside 0 1 2 leftside 3 4 5 back 6 7 8 9  bottom 10 11 12 top 13 14 15
        //tip point 1 3 10 13
      
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
        Debris();
    }
    void Debris()
    {

        int RotationAxis = Random.Range(0, 3);
        float angle = Random.Range(0,360);
        //spinng for when a ship explodes then inplement a loop to reduce the 360 to zero to stop spinning once
        //time passed
        float angle2 = Mathf.PerlinNoise(0, 360);

        this.transform.Rotate(-angle2, angle2, angle2, Space.Self);
        //test
        //this.transform.Rotate(0, 0, angle2, Space.Self);
        //this.transform.Rotate(-angle2, 0, 0, Space.Self);
        //this.transform.Rotate(0, angle2, 0, Space.Self);

        // this.transform.Rotate(Vector3.forward,angle2);
        // this.transform.Rotate(Vector3.left, angle2);
        //this.transform.Rotate(Vector3.up,angle2);


    }
}
