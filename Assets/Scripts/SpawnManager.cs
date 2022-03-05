using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] thingsToSpawn;
    public GameObject Hallway;
    public TextMeshProUGUI score;
    public TextMeshProUGUI winningText;
    public TextMeshProUGUI losingText;
    public GameObject player;
    public AudioSource cameraAudioSource;
    public AudioClip alarmSound;
    public Camera playerCamera;
    int alarmOccurence =0;
    public bool isGameOver = false;
    public bool gotHit = false;
    float hallwayWidth;
    float hallwayHeight;
    float hallwayLength;
    public int scoreValue = 0;
    public float laserSpeed = 20;
    float floorLazerStartDelay = 2;
    float floorLazerSpawnIntervalLowerBound = 3;
    float floorLazerSpawnIntervalUpperBound = 6;


    // Start is called before the first frame update
    void Start()
    {
        winningText.enabled = false;
        losingText.enabled = false;

        hallwayWidth = Hallway.GetComponent<Collider>().bounds.size.x;
        hallwayHeight = Hallway.GetComponent<Collider>().bounds.size.y;
        hallwayLength = Hallway.GetComponent<Collider>().bounds.size.z;

        for (int i = 0; i < 30; i++)
        {
            Vector3 coinSpawnPos = new Vector3(Random.Range(Hallway.transform.position.x, Hallway.transform.position.x + hallwayWidth - 1), 2, Random.Range(Hallway.transform.position.z, hallwayLength));
            Instantiate(thingsToSpawn[0], coinSpawnPos, thingsToSpawn[0].transform.rotation);
        }
        //Debug.Log("Hallway width is" + hallwayWidth);

        for (int i = 0; i < 8;i++)
        {
            Vector3 lightSpawnPos = new Vector3(Random.Range(Hallway.transform.position.x +  (hallwayWidth/2)-1, Hallway.transform.position.x + (hallwayWidth / 2)+1), (Hallway.transform.position.y + hallwayHeight)-1, Random.Range(Hallway.transform.position.z + 15, hallwayLength));
            Instantiate(thingsToSpawn[3], lightSpawnPos, thingsToSpawn[3].transform.rotation);
        }

        for (int i = 0; i < 5; i++)
        {
            Vector3 upDownPos = new Vector3(Hallway.transform.position.x, .5f, Random.Range(Hallway.transform.position.z + 10, Hallway.transform.position.z + hallwayLength -2));
            Instantiate(thingsToSpawn[4], upDownPos, thingsToSpawn[4].transform.rotation);
        }

        InvokeRepeating("spawnFloorLasers", floorLazerStartDelay, Random.Range(floorLazerSpawnIntervalLowerBound,floorLazerSpawnIntervalUpperBound));
        


    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == false)
        {
            score.text = "Score is " + scoreValue;
        }

        else if (isGameOver == true && gotHit == true)
        {
            playerCamera.GetComponent<CinemachineBrain>().enabled = false;
            losingText.text = "You were detected!";
            losingText.enabled = true;
            CancelInvoke("spawnFloorLasers");
            player.GetComponent<ThirdPersonMovement>().enabled = false;
            destroyLasers();
            //cameraAudioSource.clip = alarmSound;

            if (alarmOccurence < 1)
            {
                alarmOccurence++;
                cameraAudioSource.PlayOneShot(alarmSound);
            }


        }
        else if (isGameOver == true && gotHit == false)
        {
            playerCamera.GetComponent<CinemachineBrain>().enabled = false;
            winningText.text = "You won with a total of " + scoreValue + " coins!";
            winningText.enabled = true;
            score.enabled = false;
            player.GetComponent<ThirdPersonMovement>().enabled = false; 
            CancelInvoke("spawnFloorLasers");
            destroyLasers();
           

        }
        
    }

    

    void spawnFloorLasers()
    {
        Vector3 floorLaserPos = new Vector3(Hallway.transform.position.x, 2, Hallway.transform.position.z + hallwayLength -3);
        Instantiate(thingsToSpawn[2], floorLaserPos, thingsToSpawn[2].transform.rotation);

    }

    void destroyLasers()
    {
        GameObject[] lasers;
        lasers = GameObject.FindGameObjectsWithTag("laserParticle");
        foreach (GameObject laser in lasers)
        {
            laser.GetComponent<ParticleSystem>().Stop();
            Destroy(laser);
        }
    }
}
