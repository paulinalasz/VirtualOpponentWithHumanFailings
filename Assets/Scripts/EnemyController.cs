using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyController : MonoBehaviour {

    public Vector3 enemyPlayerPositionGuess;

    [SerializeField] Camera cam;
    [SerializeField] EnemyMovement legs;
    [SerializeField] Ear enemyEar;

    private Transform agentTransform;
    private NavMeshAgent agent;
    private Rigidbody rigidbody;

    private Sound lastLoudestSound;

    private void Start() {
        agentTransform = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        float distance = Vector3.Distance(legs.AgentTransform.position, legs.Agent.destination);

        moveToMouseClick();

        if (distance < 1.1f || rigidbody.velocity.magnitude < 1.3f) {
            this.lastLoudestSound = null;
            legs.wander();
        }
        
        if (enemyEar.SoundsHeard.Count > 0) {
            //followLastSound(enemyEar.SoundsHeard);
            //followLastSoundSploshVolume(enemyEar.SoundsHeard);
            followLoudestSound(enemyEar.SoundsHeard);
        }
    }

    private void moveToMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                enemyPlayerPositionGuess = hit.point;

                agent.speed = legs.GuessedSpeed;
                agent.SetDestination(enemyPlayerPositionGuess);
            }
        }
    }

    private void followLastSound(List<Sound> soundsHeard) {
        foreach (Sound sound in soundsHeard) {
            agent.speed = legs.GuessedSpeed;
            if (!(Vector3.Distance(sound.Origin, agentTransform.position) < 1)) {
                print("heard sound: " + sound.File);
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

    private void reactToSploshLoudness(Sound sound) {
        if (sound.getVolume() > 0.3 && sound.getVolume() < 0.8) {
            print("speed: " + agent.speed);
            agentFollowSound(sound);
        }
        else if (sound.getVolume() >= 0.8) {
            agent.speed = legs.PanicedSpeed;
            print("speed: " + agent.speed);
            agentFollowSound(sound);
        }
    }


    private void followLoudestSound(List<Sound> soundsHeard) {
        retrieveLoudestSound(soundsHeard);

        agent.speed = legs.GuessedSpeed;

        if (!(Vector3.Distance(this.lastLoudestSound.Origin, agentTransform.position) < 1)) {
            switch (this.lastLoudestSound.File) {
                case "splosh":
                    reactToSploshLoudness(this.lastLoudestSound);
                    break;
                default:
                    agentFollowSound(this.lastLoudestSound);
                    break;
            }
        }

    }

    private void retrieveLoudestSound(List<Sound> soundsHeard) {
        Sound loudestSound;

        if (lastLoudestSound != null) {
            loudestSound = this.lastLoudestSound;
        } else {
            loudestSound = soundsHeard.ElementAt(0);
        }

        foreach (Sound sound in soundsHeard) {
            if (sound.getVolume() > loudestSound.getVolume()) {
                loudestSound = sound;
            }
        }

        if (lastLoudestSound != null) {
            print("the loudest sound i remember is: " + lastLoudestSound.File);
        }
            
        this.lastLoudestSound = loudestSound;
    }

    private void agentFollowSound(Sound sound) {
        lastLoudestSound = sound;
        this.agent.SetDestination(sound.Origin);
    }
}
