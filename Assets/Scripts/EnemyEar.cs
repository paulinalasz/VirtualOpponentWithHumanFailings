using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEar : MonoBehaviour {

    private List<Sound> soundsPlaying;

    // Start is called before the first frame update
    void Start() {
        soundsPlaying = new List<Sound>();
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

    public List<Sound> SoundsPlaying {
        get {
            return this.soundsPlaying;
        }

        set {
            this.soundsPlaying = value;
        }
    }
}
