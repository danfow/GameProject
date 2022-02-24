using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSounds : MonoBehaviour
{
    public GameObject ObjectToMakeSound;
    private AudioSource objectAudio;
    public AudioClip audioClip;
    private float clipDuration = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        objectAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Coin"))
        {
            //objectAudio.PlayOneShot(audioClip, clipDuration);
            AudioSource.PlayClipAtPoint(audioClip, ObjectToMakeSound.transform.position);
            Destroy(ObjectToMakeSound);
        }
    }

    
        
    
}

