using UnityEngine;
using System.Collections.Generic;
using System;

public class SFXTriggerSurface : MonoBehaviour {

    [SerializeField] AudioSource movementAudio;
    [SerializeField] AudioSource initialAudio;

    private Sound movement;
    private Sound initial;

    private void Start() {
        movement = new Sound(movementAudio);
        initial = new Sound(initialAudio);
    }

    private void Update() {
        if (!initial.isPlaying()) {
            GlobalListener.removeSoundsPlaying(initial);
        }
        if (!movement.isPlaying()) {
            GlobalListener.removeSoundsPlaying(movement);
        }
        if (initial.isPlaying()) {
            GlobalListener.updateSoundsPlaying(initial);
        }
        if (movement.isPlaying()) {
            GlobalListener.updateSoundsPlaying(movement);
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
