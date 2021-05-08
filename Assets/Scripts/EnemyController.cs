using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

    public Vector3 enemyPlayerPositionGuess;

    [SerializeField] EnemyMovement movement;
    [SerializeField] Ear enemyEar;

    private Transform agentTransform;
    private NavMeshAgent agent;

    private void Start() {
        agentTransform = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        float distance = Vector3.Distance(movement.AgentTransform.position, movement.Agent.destination);

        if (distance < 2f) {
            movement.wander();
        }

        //reactToSounds(enemyEar.SoundsHeard);
    }

    private void reactToSounds(List<Sound> soundsPlaying) {
        foreach (Sound sound in soundsPlaying) {
            reactToSound(sound);
        }
    }

    private void reactToSound(Sound sound) { 
        switch (sound.File) {
            case "splosh":
                reactToSplosh(sound);
                break;
            case "swimming":
                reactToSwimming(sound);
                break;
            case "mudfootsteps":
                reactToMud(sound);
                break;
            case "metalsteps":
                reactToMetal(sound);
                break;
            case "footsteps":
                reacttoFootsteps(sound);
                break;
            default:
                print("no sound detected");
                break;
        }
    }

    private void reactToSplosh(Sound sound) {
        if (Vector3.Distance(sound.Origin, agentTransform.position) < 1) {
            print("that was my own splosh and I can ignore it!");
        }
        else {
            agent.SetDestination(sound.Origin);
        }
    }

    private void reactToSwimming(Sound sound) {
        if (Vector3.Distance(sound.Origin, agentTransform.position) < 1) {
            print("that was my own swim and I can ignore it!");
        }
        else {
            agent.SetDestination(sound.Origin);
        }
    }

    private void reactToMud(Sound sound) {
        if (Vector3.Distance(sound.Origin, agentTransform.position) < 1) {
            print("that was my own mud and I can ignore it!");
        }
        else {
            agent.SetDestination(sound.Origin);
        }
    }

    private void reactToMetal(Sound sound) {
        if (Vector3.Distance(sound.Origin, agentTransform.position) < 1) {
            print("that was my own metal and I can ignore it!");
        }
        else {
            agent.SetDestination(sound.Origin);
        }
    }

    private void reacttoFootsteps(Sound sound) {
        if (Vector3.Distance(sound.Origin, agentTransform.position) < 1) {
            print("that was my own footsteps and I can ignore it!");
        }
        else {
            agent.SetDestination(sound.Origin);
        }
    }
}
