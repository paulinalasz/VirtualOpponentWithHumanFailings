using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

    public Vector3 enemyPlayerPositionGuess;

    [SerializeField] EnemyMovement movement;
    [SerializeField] Ear enemyEar;

    // Update is called once per frame
    void Update() {
        float distance = Vector3.Distance(movement.AgentTransform.position, movement.Agent.destination);

        if (distance < 1f) {
            movement.wander();
        }

        reactToSounds(enemyEar.SoundsHeard);
    }

    private void reactToSounds(List<Sound> soundsPlaying) {
        foreach (Sound sound in soundsPlaying) {
            reactToSound(sound);
        }
    }

    private void reactToSound(Sound sound) {
        switch (sound.File) {
            case "splosh":
                reactToSplosh();
                break;
            case "swimming":
                reactToSwimming();
                break;
            case "mudfootsteps":
                reactToMud();
                break;
            case "metalsteps":
                reactToMetal();
                break;
            default:
                print("no sound detected");
                break;
        }
    }

    private void reactToSplosh() {
        print("this is sploshing and I can hear it!");
    }

    private void reactToSwimming() {
        print("this is sploshing and I can hear it!");
    }

    private void reactToMud() {
        print("this is sploshing and I can hear it!");
    }

    private void reactToMetal() {
        print("this is sploshing and I can hear it!");
    }
}
