using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEar : MonoBehaviour {
    [SerializeField] Transform agentTransform;

    private float sploshHearingRange = 15;
    private float swimmingHearingRange = 15;
    private float mudfootstepsHearingRange = 15;
    private float metalstepsHearingRange = 15;

    // Start is called before the first frame update
    void Start() {
        SoundsPlaying = new List<Sound>();
    }

    private void Update() {
        removeDistantSounds();
    }

    public void updateSoundsPlaying(Sound sound) {
        if (!SoundsPlaying.Contains(sound)) {
            this.SoundsPlaying.Add(sound);
        }
        else {
            this.removeSoundsPlaying(sound);
            this.SoundsPlaying.Add(sound);
        }
    }

    public void removeSoundsPlaying(Sound sound) {
        this.SoundsPlaying.Remove(sound);
    }

    private void removeDistantSounds() {
        List<Sound> toRemove = new List<Sound>();;

        foreach (Sound sound in SoundsPlaying) {
            float distance = Vector3.Distance(agentTransform.position, sound.Origin);

            switch (sound.File) {
                case "splosh":
                    if (distance >= sploshHearingRange) {
                        toRemove.Add(sound);
                    }
                    break;
                case "swimming":
                    if (distance >= swimmingHearingRange) {
                        toRemove.Add(sound);
                    }
                    break;
                case "mudfootsteps":
                    if (distance >= mudfootstepsHearingRange) {
                        toRemove.Add(sound);
                    }
                    break;
                case "metalsteps":
                    if (distance >= metalstepsHearingRange) {
                        toRemove.Add(sound);
                    }
                    break;
                default:
                    print("no sound detected");
                    break;
            }
        }
    }

    public List<Sound> SoundsPlaying { get; set; }
}