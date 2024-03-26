using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Visuals")]
    public GameObject model;

    [Header("Movements")]
    public float movingVelocity = 5;
    public float jumpingVelocity = 10;
    private Rigidbody playerRigidbody;
    private bool canJump;

    //public bool 
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast to identify if the player can jump
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.01f)) {
            canJump = true;
        }   

        ProcessInput();

    }

    void ProcessInput() {

        playerRigidbody.velocity = new Vector3 (
                0,
                playerRigidbody.velocity.y,
                0
            );
        
        // Move in the XZ plane
        if (Input.GetKey("right")) {
            playerRigidbody.velocity = new Vector3 (
                movingVelocity,
                playerRigidbody.velocity.y,
                playerRigidbody.velocity.z
            );

            model.transform.localEulerAngles = new Vector3 (0, 270, 0);
        }

        if (Input.GetKey("left")) {
            playerRigidbody.velocity = new Vector3 (
                -movingVelocity,
                playerRigidbody.velocity.y,
                playerRigidbody.velocity.z
            );

            model.transform.localEulerAngles = new Vector3 (0, 90, 0);
        }

        if (Input.GetKey("up")) {
            playerRigidbody.velocity = new Vector3 (
                playerRigidbody.velocity.x,
                playerRigidbody.velocity.y,
                movingVelocity
            );

            model.transform.localEulerAngles = new Vector3 (0, 180, 0);
        }

        if (Input.GetKey("down")) {
            playerRigidbody.velocity = new Vector3 (
                playerRigidbody.velocity.x,
                playerRigidbody.velocity.y,
                -movingVelocity
            );

            model.transform.localEulerAngles = new Vector3 (0, 0, 0);
        }

        // Check for jump
        if (canJump && Input.GetKey("space")) {
            canJump = false;
            playerRigidbody.velocity = new Vector3 (
                playerRigidbody.velocity.x,
                jumpingVelocity,
                playerRigidbody.velocity.z
            );
        }
    }
}
