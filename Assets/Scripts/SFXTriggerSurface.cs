using UnityEngine;
using System.Collections.Generic;
using System;

public class SFXTriggerSurface : MonoBehaviour {

    protected AudioSource movementAudio;

    protected Sound movement;

    private void Start() {
        movementAudio = GetComponent<AudioSource>();
        switch (movementAudio.clip.name) {
            case "mudsteps":
                movement = new Sound(movementAudio, 0.5f, 8);
                break;
            default:
                movement = new Sound(movementAudio, 1, 12);
                break;
        }
    }

    private void Update() {
        if (!movement.isPlaying()) {
            GlobalListener.removeSoundsPlaying(movement);
        }
        if (movement.isPlaying()) {
            GlobalListener.updateSoundsPlaying(movement);
        }
    }

    protected void OnTriggerStay(Collider other) {
        if (other.attachedRigidbody.velocity.magnitude > 0.5) {
            float volume = other.attachedRigidbody.mass * 0.5f;
            movement.setVolume(volume);

            movement.play();
            movement.Origin = other.GetComponent<Transform>().position;
        } else if (other.attachedRigidbody.velocity.magnitude < 0.5 && other.attachedRigidbody.velocity.magnitude > 0.01) {
            movement.stop();
        }
    }

    protected void OnTriggerExit(Collider other) {
        movement.stop();
    }
}
