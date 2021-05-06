using UnityEngine;
using System.Collections.Generic;
using System;

public class SFXSurface : MonoBehaviour {

    [SerializeField]  EnemyEar enemyEar;

    [SerializeField] AudioSource movementtemp;
    [SerializeField] AudioSource initialtemp;

    private Sound movement;
    private Sound initial;

    private void Start() {
        movement = new Sound(movementtemp);
        initial = new Sound(initialtemp);
    }

    private void Update() {
        if (!initial.isPlaying()) {
            enemyEar.removeSoundsPlaying(initial);
        }
        if (!movement.isPlaying()) {
            enemyEar.removeSoundsPlaying(movement);
        }
        if (initial.isPlaying()) {
            enemyEar.updateSoundsPlaying(initial);
        }
        if (movement.isPlaying()) {
            enemyEar.updateSoundsPlaying(movement);
        }
    }

    private void OnTriggerEnter(Collider other) {
        initial.play();
        initial.Origin = other.GetComponent<Transform>().position;
    }

    private void OnTriggerStay(Collider other) {


        if (other.attachedRigidbody.velocity.magnitude > 0.5) {
            movement.play();
            movement.Origin = other.GetComponent<Transform>().position;
        }
        else if (other.attachedRigidbody.velocity.magnitude < 0.5 && other.attachedRigidbody.velocity.magnitude > 0.01) {
            movement.stop();
        }
    }

    private void OnTriggerExit(Collider other) {
        movement.stop();
    }
}
