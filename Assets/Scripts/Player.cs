using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    [SerializeField] private int speed = 50; //player movement speed

    private int verticalMovement = 0;
    private int horizontalMovement = 0;
    private Rigidbody rigidBody;

    private Vector3 movement;

    void Start() {
        rigidBody = GetComponent<Rigidbody>(); //retrieve player rigidbody
    }

    void Update() {
        movementInput();  //every update check for relavent key press
    }

    void FixedUpdate() {
        move();          //every set time apply force to the player based on the key press
    }

    //depending on keyboard input, set the movement direction
    private void movementInput() {
        if (Input.GetKeyDown(KeyCode.W)) {
            verticalMovement = 1;
        }
        if  (Input.GetKeyDown(KeyCode.S)) {
            verticalMovement = -1;
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            horizontalMovement = 1;
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            horizontalMovement = -1;
        }

        if (Input.GetKeyUp(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
            verticalMovement = 0;
        }
        if (Input.GetKeyUp(KeyCode.S) && !Input.GetKey(KeyCode.W)) {
            verticalMovement = 0;
        }
        if (Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
            horizontalMovement = 0;
        }
        if (Input.GetKeyUp(KeyCode.D) && !Input.GetKey(KeyCode.A)) {
            horizontalMovement = 0;
        }
    }

    //Multiply direction by the speed and apply the force to the player
    private void move() {
        movement = new Vector3(verticalMovement, 0, horizontalMovement);
        movement = movement * speed;

        rigidBody.AddForce(movement);
    }
}
