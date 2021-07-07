using UnityEngine;
using System.Collections.Generic;
using System;

public class SFXWalkableSurface : MonoBehaviour {

    [SerializeField] AudioSource movementAudio;

    private Sound movement;

    private void Start() {
        switch(movementAudio.clip.name) {
            case "footsteps":
                movement = new Sound(movementAudio, 0.5f, 5);
                break;
            default:
                movement = new Sound(movementAudio, 1, 10);
                break;
        }
        print("distance hEEEeard: " + movement.distanceHeard + " of " + movement.File);
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
