using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    public Vector3 enemyPlayerPositionGuess;

    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform agentTransform;

    [SerializeField] float wanderSpeed;
    [SerializeField] float guessedSpeed;

    [SerializeField] float destinationSetRadius;

    private void Start() {
        agent.SetDestination(agentTransform.position);
        agent.speed = wanderSpeed;
    }

    //moves towards random navmesh area
    public void wander() {
        Vector3 newPos = findWanderDestination(agentTransform.position, destinationSetRadius, -1);

        agent.speed = wanderSpeed;
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
}
