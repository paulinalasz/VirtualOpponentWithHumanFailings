using UnityEngine;
using System.Collections.Generic;
using System;

public class SFXWalkableSurface : MonoBehaviour {

    [SerializeField] AudioSource movementAudio;

    private Sound movement;

    private void Start() {
        movement = new Sound(movementAudio);
    }

    private void Update() {
        if (!movement.isPlaying()) {
            GlobalListener.removeSoundsPlaying(movement);
        }
        if (movement.isPlaying()) {
            GlobalListener.updateSoundsPlaying(movement);
        }
    }

    private void OnCollisionStay(Collision collision) {
        if (collision.collider.attachedRigidbody.velocity.magnitude > 0.5) {
            float volume = collision.collider.attachedRigidbody.mass * 0.5f;
            movement.setVolume(volume);

            movement.play();
            movement.Origin = collision.collider.GetComponent<Transform>().position;
        } else {
            movement.stop();
        }
    }
}
