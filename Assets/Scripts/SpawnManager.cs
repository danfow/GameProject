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

    public float laserSpeed = 20;
    float floorLazerStartDelay = 2;
    float floorLazerSpawnIntervalLowerBound = 3;
    float floorLazerSpawnIntervalUpperBound = 6;

    // Start is called before the first frame update
    void Start()
    {
        hallwayWidth = Hallway.GetComponent<Collider>().bounds.size.x;
        hallwayHeight = Hallway.GetComponent<Collider>().bounds.size.y;
        hallwayLength = Hallway.GetComponent<Collider>().bounds.size.z;

        for (int i = 0; i < 30; i++)
        {
            Vector3 coinSpawnPos = new Vector3(Random.Range(Hallway.transform.position.x, Hallway.transform.position.x + hallwayWidth - 1), 2, Random.Range(Hallway.transform.position.z, hallwayLength));
            Instantiate(thingsToSpawn[0], coinSpawnPos, thingsToSpawn[0].transform.rotation);
        }
        //Debug.Log("Hallway width is" + hallwayWidth);

        for (int i = 0; i < 5;i++)
        {
            Vector3 lightSpawnPos = new Vector3(Random.Range(Hallway.transform.position.x +  (hallwayWidth/2)-2, Hallway.transform.position.x + (hallwayWidth / 2)+2), (Hallway.transform.position.y + hallwayHeight)-1, Random.Range(Hallway.transform.position.z + 2, hallwayLength));
            Instantiate(thingsToSpawn[3], lightSpawnPos, thingsToSpawn[3].transform.rotation);
        }
        InvokeRepeating("spawnFloorLasers", floorLazerStartDelay, Random.Range(floorLazerSpawnIntervalLowerBound,floorLazerSpawnIntervalUpperBound));
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void spawnFloorLasers()
    {
        Vector3 floorLaserPos = new Vector3(Hallway.transform.position.x, 2, Hallway.transform.position.z + hallwayLength -3);
        Instantiate(thingsToSpawn[2], floorLaserPos, thingsToSpawn[2].transform.rotation);

    }
}
