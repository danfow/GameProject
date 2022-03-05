using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackwards : MonoBehaviour    
{
    public float moveBackSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            gameObject.transform.Translate(Vector3.back * moveBackSpeed * Time.deltaTime);
        
    }
}
