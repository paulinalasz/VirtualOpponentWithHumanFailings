using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyController : MonoBehaviour {

    public Vector3 enemyPlayerPositionGuess;

    [SerializeField] EnemyMovement legs;
    [SerializeField] Ear enemyEar;

    private Transform agentTransform;
    private NavMeshAgent agent;
    private Rigidbody rigidbody;

    private void Start() {
        agentTransform = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        float distance = Vector3.Distance(legs.AgentTransform.position, legs.Agent.destination);

        if (distance < 1.1f || rigidbody.velocity.magnitude < 1.3f) {
            legs.wander();
        }

        //followLastSound(enemyEar.SoundsHeard);
        followLastSoundSploshVolume(enemyEar.SoundsHeard);
    }

    private void followLastSound(List<Sound> soundsHeard) {
        foreach (Sound sound in soundsHeard) {
            agent.speed = legs.GuessedSpeed;
            if (!(Vector3.Distance(sound.Origin, agentTransform.position) < 1)) {
                agent.SetDestination(sound.Origin);
            }
        }
    }

    private void followLastSoundSploshVolume(List<Sound> soundsHeard) {
        foreach (Sound sound in soundsHeard) {
            if (!(Vector3.Distance(sound.Origin, agentTransform.position) < 1)) {
                print(legs.GuessedSpeed);

                if (sound.File == "splosh") {
                    if (sound.getVolume() > 0.3 && sound.getVolume() < 0.8) {
                        agent.SetDestination(sound.Origin);
                    }
                    else if (sound.getVolume() >= 0.8) {
                        agent.speed = legs.PanicedSpeed;
                        agent.SetDestination(sound.Origin);
                    }
                }
                else {
                    agent.SetDestination(sound.Origin);
                }
            }
        }
    }

    private void reactToSounds(List<Sound> soundsHeard) {
        foreach (Sound sound in soundsHeard) {
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
