using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound {

    [SerializeField] AudioSource source;
    private Vector3 origin;

    public Sound(AudioSource source) {
        this.source = source;
        this.Clip = source.clip;
        this.File = this.Clip.name;

        this.origin = Vector3.zero;
    }

    public AudioSource Source {
        get {
            return this.Source;
        }

        set {
            this.source = value;
        }
    }

    public AudioClip Clip { get; set; }

    public string File { get; set; }

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
}
