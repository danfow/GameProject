using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 2, -3);
    private Vector3 previousCameraPosition;
    public float cameraRotateSpeed = 5;
    [SerializeField]  private GameObject playerToFollow;
    [SerializeField] private Camera cam;
    private Rigidbody playerRb;
    public Vector3 direction;
    private Vector3 playerMovementVector;
    private Vector3 movement;
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);

    public float sideMove;
    public float frontBackMove;
    public float playerSpeed = .5f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = playerToFollow.GetComponent<Rigidbody>();
        //cam.transform.Translate(offset);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        sideMove = Input.GetAxis("Horizontal");
        frontBackMove = Input.GetAxis("Vertical");

        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

       
        if (Input.GetMouseButtonDown(1))
        {
            previousCameraPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        {

        }
        if (Input.GetMouseButton(1))
        {
            // transform.eulerAngles += cameraRotateSpeed * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0); //rotate camera with holding of mouse click
            //playerToFollow.transform.eulerAngles += cameraRotateSpeed * new Vector3(0, Input.GetAxis("Mouse X"), 0);

            direction = previousCameraPosition - cam.ScreenToViewportPoint(Input.mousePosition);
            cam.transform.position = playerToFollow.transform.position;
            cam.transform.Rotate(new Vector3(1, 0, 0),  direction.y * 180);
            cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180,Space.World);
            cam.transform.Translate(new Vector3(0, 2, -3));
            //playerToFollow.Translate(cam.transform.right * sideMove * Time.deltaTime * playerSpeed);
            //playerToFollow.Translate(cam.transform.forward * frontBackMove * Time.deltaTime * playerSpeed);
            //playerToFollow.transform.Translate(Vector3.left * sideMove * Time.deltaTime * playerSpeed);
            //playerToFollow.transform.Translate(Vector3.back * frontBackMove * Time.deltaTime * playerSpeed);

            //playerToFollow.transform.Rotate(new Vector3(1, 0, 0), -direction.y * 180);
            //playerToFollow.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180 , Space.World);

            Quaternion deltaRotation = Quaternion.Euler(0, -direction.x * 180, 0);
            playerRb.MoveRotation(playerRb.rotation * deltaRotation);
            //movePlayer();





            previousCameraPosition = cam.ScreenToViewportPoint(Input.mousePosition);
           
        }

        else
        {
            cam.transform.position = playerToFollow.transform.position;
            cam.transform.Translate(new Vector3(0, 2, -3));

            //playerMovementVector = new Vector3(sideMove, 0f, frontBackMove);

            //playerToFollow.transform.Translate(Vector3.left * sideMove * Time.deltaTime * playerSpeed);
            //playerToFollow.transform.Translate(Vector3.back * frontBackMove * Time.deltaTime * playerSpeed);
           
            //moveCharacter();
            
        }
        */
    }

    private void FixedUpdate()
    {
        //moveCharacter();
    }

    private void movePlayer()
    {
        Vector3 MoveVector = (playerToFollow.transform.TransformDirection(playerMovementVector))  * playerSpeed;
        playerRb.velocity = new Vector3(MoveVector.x, playerRb.velocity.y, MoveVector.z);
    }

    private void moveCharacter()
    {
        //playerRb.MovePosition(playerToFollow.transform.position + ((ddirection) * playerSpeed * Time.deltaTime));
        //playerRb.MovePosition(playerToFollow.transform.position + (playerToFollow.transform.forward *-1) * (frontBackMove * playerSpeed * Time.deltaTime));
        //playerRb.MovePosition(playerToFollow.transform.position + (playerToFollow.transform.right * -1) * (sideMove * playerSpeed * Time.deltaTime));

        playerRb.MovePosition(playerToFollow.transform.position + (((playerToFollow.transform.forward * -1 * frontBackMove) + (playerToFollow.transform.right*-1 * sideMove)) * (playerSpeed * Time.deltaTime) )  ); //the horror




    }

    private void LateUpdate()
    {
        
    }
}
