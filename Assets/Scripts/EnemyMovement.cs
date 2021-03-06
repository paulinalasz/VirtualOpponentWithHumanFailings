using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    public Vector3 enemyPlayerPositionGuess;

    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform agentTransform;

    [SerializeField] float destinationSetRadius;

    private void Start() {
        //different speeds representing different behaviours
        WanderSpeed = 2f;
        GuessedSpeed = 3f;
        PanicedSpeed = 4f;

        agent.SetDestination(agentTransform.position);
        agent.speed = WanderSpeed;
    }

    //moves towards random navmesh area
    public void wander() {
        Vector3 newPos = findWanderDestination(agentTransform.position, destinationSetRadius, -1);

        agent.speed = WanderSpeed;
        print("wander " + agent.speed);
        agent.SetDestination(newPos);
    }

    //finds random destination within navmesh area
    private Vector3 findWanderDestination(Vector3 origin, float radius, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * radius;
        randDirection += origin;
        NavMeshHit hit;
        NavMesh.SamplePosition(randDirection, out hit, radius, layermask);

        return hit.position;
    }

    public NavMeshAgent Agent {
        get {
            return this.agent;
        }
        set {
            this.agent = value;
        }
    }

    public Transform AgentTransform {
        get {
            return this.agentTransform;
        }
        set {
            this.agentTransform = value;
        }
    }

    public float WanderSpeed { get; set; }
    public float GuessedSpeed { get; set; }
    public float PanicedSpeed { get; set; }
}
