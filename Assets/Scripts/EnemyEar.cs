using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEar : MonoBehaviour {

    private List<Sound> soundsPlaying;

    // Start is called before the first frame update
    void Start() {
        soundsPlaying = new List<Sound>();
    }

    // Update is called once per frame
    void Update() {
        foreach (Sound sound in soundsPlaying) {
            reactToSound(sound);
        } 
    }

    public void reactToSound(Sound sound) {
        switch(sound.File) {
            case "splosh":
                print("splosh: " + sound.Origin);
                break;
            case "swimming":
                print("swim: " + sound.Origin);
                break;
            case "mudfootsteps":
                print("mud: " + sound.Origin);
                break;
            case "metalsteps":
                print("metal: " + sound.Origin);
                break;
            default:
                print("no sound detected");
                break;
        }
    }

    public List<Sound> SoundsPlaying {
        get {
            return this.soundsPlaying;
        }

        set {
            this.soundsPlaying = value;
        }
    }

    public void updateSoundsPlaying(Sound sound) {
        if (!soundsPlaying.Contains(sound)) {
            this.soundsPlaying.Add(sound);
        } else {
            this.removeSoundsPlaying(sound);
            this.soundsPlaying.Add(sound);
        }
    }

    public void removeSoundsPlaying(Sound sound) {
        this.soundsPlaying.Remove(sound);
    }
}
