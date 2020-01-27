using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadShipScript : MonoBehaviour {

   public GameObject Explosion;
   public GameObject Debris1;//folded
   public GameObject Debris2;//pointed
   public GameObject Debris3;//tri
   public GameObject Debris4;//big
   public GameObject Debris5;//twin
   public GameObject Debris6;//twin
    List<GameObject> Attachments = new List<GameObject>();
    List<GameObject> SpawnedDebris = new List<GameObject>();
    float range = 2.0f;
    int counter = 0;
    int enginetype;
    // Use this for initialization
    void Start()
    {
       
        for (int x = 0; x < this.transform.childCount; x++)
        {
            Attachments.Add(this.transform.GetChild(x).gameObject);
        }
        chooseEngine();
        // float angle = Random.Range(0, 360);
        this.transform.Rotate(Vector3.back, 90);

        //SelfDestruct();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void chooseEngine()
    {
         enginetype = Random.Range(0, 3);
        //big engine
        if (enginetype == 0)
        {
            Destroy(Attachments[1]);
            Destroy(Attachments[2]);
        }
        //twin
        if (enginetype == 1)
        {
            Destroy(Attachments[0]);
            Destroy(Attachments[1]);
        }
        //tri
        if (enginetype == 2)
        {
            Destroy(Attachments[0]);
            Destroy(Attachments[2]);
        }

    }
    
    void SelfDestruct(int Number)
    {
        if (Number > 5)
        {
            Explosion.transform.localScale = this.transform.localScale;
            Instantiate(Explosion, transform.position, Quaternion.identity);

            Vector3 RandomPos = Random.insideUnitSphere * range;
            if (enginetype == 0)
            {
                SpawnedDebris.Add(Instantiate(Debris4, transform.position + RandomPos, Quaternion.identity));
            }
            if (enginetype == 1)
            {
                SpawnedDebris.Add(Instantiate(Debris5, transform.position + RandomPos, Quaternion.identity));
            }
            if (enginetype == 2)
            {
                SpawnedDebris.Add(Instantiate(Debris3, transform.position + RandomPos, Quaternion.identity));
            }


            for (int i = 0; i < 4; i++)
            {
                int debristype = Random.Range(0, 3);
                RandomPos = Random.insideUnitSphere * range;
                if (debristype == 0)
                {
                    SpawnedDebris.Add(Instantiate(Debris1, transform.position + RandomPos, Quaternion.identity));

                }
                if (debristype == 1)
                {
                    SpawnedDebris.Add(Instantiate(Debris2, transform.position + RandomPos, Quaternion.identity));

                }
                if (debristype == 2)
                {
                    SpawnedDebris.Add(Instantiate(Debris6, transform.position + RandomPos, Quaternion.identity));


                }
            }




            Destroy(this.gameObject);

        }
    }

    void DisperseDebris()
    {
        float speed = 50.0f;
        int Direction;
        for (int x = 1; x < this.transform.childCount; x++)
        {
            DebrisScript DS = (DebrisScript)this.transform.GetChild(x).GetComponent("DebrisScript");
            Direction = DS.Direction;
            print(Direction);
            if (Direction == 0)
            {
                this.transform.GetChild(x).transform.position += Vector3.forward * Time.deltaTime * speed;
            }
            if (Direction == 1)
            {
                this.transform.GetChild(x).transform.position += Vector3.back * Time.deltaTime * speed;
            }
            if (Direction == 2)
            {
                this.transform.GetChild(x).transform.position += Vector3.left * Time.deltaTime * speed;
            }
            if (Direction == 3)
            {
                this.transform.GetChild(x).transform.position += Vector3.right * Time.deltaTime * speed;
            }
            if (Direction == 4)
            {
                this.transform.GetChild(x).transform.position += Vector3.up * Time.deltaTime * speed;
            }
            if (Direction == 5)
            {
                this.transform.GetChild(x).transform.position += Vector3.down * Time.deltaTime * speed;
            }
            
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name.StartsWith("Ship"))
        {
            int BoomNumber = Random.Range(0, 10);
            print("hit dectected");
            print(BoomNumber);
            SelfDestruct(BoomNumber);
        }
    }
}
