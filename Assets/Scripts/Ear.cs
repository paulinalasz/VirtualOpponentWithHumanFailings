using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ear : MonoBehaviour {
    [SerializeField] Transform agentTransform;

    [SerializeField] float sploshHearingRange;
    [SerializeField] float swimmingHearingRange;
    [SerializeField] float mudfootstepsHearingRange;
    [SerializeField] float metalstepsHearingRange;

    // Start is called before the first frame update
    void Start() {
        SoundsHeard = new List<Sound>();
    }

    private void Update() {
        getSoundsHeard();

        foreach (Sound sound in SoundsHeard) {
            print(sound.File);
        }
    }

    private void getSoundsHeard() {
        foreach (Sound sound in GlobalListener.SoundsPlaying) {
            float distance = Vector3.Distance(agentTransform.position, sound.Origin);
            List<Sound> temp = new List<Sound>();

            switch (sound.File) {
                case "splosh":
                    if (distance <= sploshHearingRange) {
                        temp.Add(sound);
                    }
                    break;
                case "swimming":
                    if (distance <= swimmingHearingRange) {
                        temp.Add(sound);
                    }
                    break;
                case "mudfootsteps":
                    if (distance <= mudfootstepsHearingRange) {
                        temp.Add(sound);
                    }
                    break;
                case "metalsteps":
                    if (distance <= metalstepsHearingRange) {
                        temp.Add(sound);
                    }
                    break;
                default:
                    print("no sound detected");
                    break;
            }

            this.SoundsHeard = temp;
        }
    }

    public List<Sound> SoundsHeard { get; set; }
}