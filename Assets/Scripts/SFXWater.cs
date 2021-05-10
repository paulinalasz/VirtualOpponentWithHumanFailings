using UnityEngine;
using System.Collections.Generic;
using System;

public class SFXWater : MonoBehaviour {

    [SerializeField] AudioSource initialAudio;
    [SerializeField] AudioSource movementAudio;

    private Sound initial;
    private Sound movement;

    private void Start() {
        initial = new Sound(initialAudio);
        movement = new Sound(movementAudio);
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

    protected void OnTriggerStay(Collider other) {
        if (other.attachedRigidbody.velocity.magnitude > 0.5) {
            movement.play();
            movement.Origin = other.GetComponent<Transform>().position;
        }
        else if (other.attachedRigidbody.velocity.magnitude < 0.5 && other.attachedRigidbody.velocity.magnitude > 0.01) {
            movement.stop();
        }
    }

    protected void OnTriggerExit(Collider other) {
        movement.stop();
    }
}
