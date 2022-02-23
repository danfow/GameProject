using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float frontBackMove;
    private float sideMove;
    public float playerSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sideMove = Input.GetAxis("Horizontal");
        frontBackMove = Input.GetAxis("Vertical");

        transform.Translate(Vector3.left * sideMove * Time.deltaTime * playerSpeed);
        transform.Translate(Vector3.back * frontBackMove * Time.deltaTime * playerSpeed);

    }
}
