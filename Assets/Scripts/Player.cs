using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    //private CharacterController controller; 
    [SerializeField] private int speed = 50;

    private int verticalMovement = 0;
    private int horizontalMovement = 0;
    private Rigidbody rigidBody;

    private Vector3 movement;

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update() {
        movementInput();
    }

    void FixedUpdate() {
        move();
    }

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

    private void move() {
        movement = new Vector3(verticalMovement, 0, horizontalMovement);
        movement = movement * speed;

        rigidBody.AddForce(movement);
    }
}
