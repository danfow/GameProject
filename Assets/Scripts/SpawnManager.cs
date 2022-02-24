using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] thingsToSpawn;
    public GameObject Hallway;
    float hallwayWidth;
    float hallwayHeight;
    float hallwayLength;

    // Start is called before the first frame update
    void Start()
    {
        hallwayWidth = Hallway.GetComponent<Collider>().bounds.size.x;
        hallwayHeight = Hallway.GetComponent<Collider>().bounds.size.y;
        hallwayLength = Hallway.GetComponent<Collider>().bounds.size.z;
        Debug.Log("Hallway width is" + hallwayWidth);

        for (int i  = 0; i < 30; i++ )
        {
            Vector3 coinSpawnPos = new Vector3(Random.Range(Hallway.transform.position.x, Hallway.transform.position.x + hallwayWidth - 1), 2, Random.Range(Hallway.transform.position.z, hallwayLength));
            Instantiate(thingsToSpawn[0], coinSpawnPos, thingsToSpawn[0].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
