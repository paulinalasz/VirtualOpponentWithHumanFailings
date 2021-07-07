using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ear : MonoBehaviour {
    [SerializeField] Transform agentTransform;

    // Start is called before the first frame update
    void Start() {
        SoundsHeard = new List<Sound>();
    }

    private void Update() {
        getSoundsHeard();
    }

    private void getSoundsHeard() {
        List<Sound> temp = new List<Sound>(0);

        foreach (Sound sound in GlobalListener.SoundsPlaying) {
            float distance = Vector3.Distance(agentTransform.position, sound.Origin);

            //print("distance heard: " + sound.distanceHeard + " of " + sound.File);
            if (distance <= sound.distanceHeard && !SoundsHeard.Contains(sound)) {
                temp.Add(sound);
            }
        }

        this.SoundsHeard = temp;
    }

    public List<Sound> SoundsHeard { get; set; }
}