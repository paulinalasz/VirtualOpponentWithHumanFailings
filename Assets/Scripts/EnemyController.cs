using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

    public Vector3 enemyPlayerPositionGuess;

    [SerializeField] EnemyMovement movement;
    [SerializeField] EnemyEar ear;

    // Update is called once per frame
    void Update() {
        float distance = Vector3.Distance(movement.AgentTransform.position, movement.Agent.destination);

        if (distance < 1f) {
            movement.wander();
        }

        reactToSounds(ear.SoundsPlaying);
    }

    private void reactToSounds(List<Sound> soundsPlaying) {
        foreach (Sound sound in soundsPlaying) {
            reactToSound(sound);
        }
    }

    private void reactToSound(Sound sound) {
        switch (sound.File) {
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

    private void reactToSplosh() {

    }
}
