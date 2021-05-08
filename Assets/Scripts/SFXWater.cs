using UnityEngine;
using System.Collections.Generic;
using System;

public class SFXWater : SFXTriggerSurface {

    //[SerializeField] AudioSource initialAudio;

    //private Sound initial;

    private void Start() {
        //initialAudio = GetComponent<AudioSource>();
        //initial = new Sound(initialAudio);
    }

    private void Update() {
        /*if (!initial.isPlaying()) {
            GlobalListener.removeSoundsPlaying(initial);
        }
        /*if (!movement.isPlaying()) {
            GlobalListener.removeSoundsPlaying(movement);
        }
        if (initial.isPlaying()) {
            GlobalListener.updateSoundsPlaying(initial);
        }
        if (movement.isPlaying()) {
            GlobalListener.updateSoundsPlaying(movement);
        }

        print(initial.File);
        print(movement.File);*/
    }

    /*private void OnTriggerEnter(Collider other) {
        initial.play();
        initial.Origin = other.GetComponent<Transform>().position;
    }*/
}
