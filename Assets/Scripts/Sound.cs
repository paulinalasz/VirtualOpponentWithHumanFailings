using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound {

    [SerializeField] AudioSource source;
    private Vector3 origin = Vector3.zero;
    private float volume = 1;

    public Sound(AudioSource source) {
        this.source = source;
        this.Clip = source.clip;
        this.File = this.Clip.name;

        this.source.volume = volume;
    }

    public Vector3 Origin {
        get {
            return this.origin;
        }
        set {
            this.origin = value;
        }
    }

    public void play() {
        if (!this.source.isPlaying) {
            this.source.Play();
        }
    }

    public void stop() {
        this.source.Stop();
    }

    public bool isPlaying() {
        return this.source.isPlaying;
    }

    public void setVolume(float volume) {
        this.source.volume = volume;
    }

    public float getVolume() {
        return this.source.volume;
    }

    public AudioSource Source { get; set; }

    public AudioClip Clip { get; set; }

    public string File { get; set; }
}
