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

    private Sound soundFollowing;

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
            agent.speed = legs.GuessedSpeed;

            if (!(Vector3.Distance(sound.Origin, agentTransform.position) < 1)) {
                if (sound.File == "splosh") {
                    reactToSploshLoudness(sound);
                } else {
                    agent.SetDestination(sound.Origin);
                }
            }
        }
    }

    private void followLoudestSound(List<Sound> soundsHeard) {

    }

    private void reactToSploshLoudness(Sound sound) {
        if (sound.getVolume() > 0.3 && sound.getVolume() < 0.8) {
            agent.SetDestination(sound.Origin);
        }
        else if (sound.getVolume() >= 0.8) {
            agent.speed = legs.PanicedSpeed;
            agent.SetDestination(sound.Origin);
        }
    }
}
