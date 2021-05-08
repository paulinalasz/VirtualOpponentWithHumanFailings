using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ear : MonoBehaviour {
    [SerializeField] Transform agentTransform;

    [SerializeField] float sploshHearingRange;
    [SerializeField] float swimmingHearingRange;
    [SerializeField] float mudfootstepsHearingRange;
    [SerializeField] float metalstepsHearingRange;
    [SerializeField] float footstepsHearingRange;

    // Start is called before the first frame update
    void Start() {
        SoundsHeard = new List<Sound>();
    }

    private void Update() {
        getSoundsHeard();

        print(SoundsHeard.Count);

        foreach (Sound sound in SoundsHeard) {
            print(sound.File);
        }
    }

    private void getSoundsHeard() {
        foreach (Sound sound in GlobalListener.SoundsPlaying) {
            float distance = Vector3.Distance(agentTransform.position, sound.Origin);

            switch (sound.File) {
                case "splosh":
                    if (distance <= sploshHearingRange && !SoundsHeard.Contains(sound)) {
                        SoundsHeard.Add(sound);
                    }
                    break;
                case "swimming":
                    if (distance <= swimmingHearingRange && !SoundsHeard.Contains(sound)) {
                        SoundsHeard.Add(sound);
                    }
                    break;
                case "mudfootsteps":
                    if (distance <= mudfootstepsHearingRange && !SoundsHeard.Contains(sound)) {
                        SoundsHeard.Add(sound);
                    }
                    break;
                case "metalsteps":
                    if (distance <= metalstepsHearingRange && !SoundsHeard.Contains(sound)) {
                        SoundsHeard.Add(sound);
                    }
                    break;
                case "footsteps":
                    if (distance <= footstepsHearingRange && !SoundsHeard.Contains(sound)) {
                        SoundsHeard.Add(sound);
                    }
                    break;
                default:
                    print("no sound detected");
                    break;
            }
        }
    }

    public List<Sound> SoundsHeard { get; set; }
}