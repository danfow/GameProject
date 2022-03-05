using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upDown : MonoBehaviour
{
    public GameObject Hallway;
    float hallwayWidth;
    float hallwayHeight;
    float hallwayLength;
    float moveSpeed;
    public bool hitTop = false;
    public bool hitDown = false;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(2,9);
        Hallway = GameObject.Find("Long hallway (1)");
        hallwayWidth = Hallway.GetComponent<Collider>().bounds.size.x;
        hallwayHeight = Hallway.GetComponent<Collider>().bounds.size.y;
        hallwayLength = Hallway.GetComponent<Collider>().bounds.size.z;
        Debug.Log("Hallway height is " + hallwayHeight);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >  Hallway.transform.position.y + hallwayHeight -1)
        {
            hitTop = true;
            hitDown = false;
            
            
        }
        else if (transform.position.y  < Hallway.transform.position.y + .5 )
        {
            hitDown = true;
            hitTop = false;
            
        }

        if (hitTop == true)
        {
           gameObject.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }

        else if (hitDown == true)
        {
            gameObject.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        


      

    }
}
