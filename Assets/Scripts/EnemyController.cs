using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public Vector3 enemyPlayerPositionGuess;

    [SerializeField] Camera cam;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform agentTransform;

    [SerializeField] float wanderSpeed;
    [SerializeField] float guessedSpeed;

    [SerializeField] float destinationSetRadius;
    [SerializeField] float intervalTimer;
    
    private float timer;


    private void Start() {
        agent.speed = wanderSpeed;
        timer = 0;
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        float distance = Vector3.Distance(agentTransform.position, agent.destination);

        if (this.timer >= intervalTimer && distance < 1f) {
            wander();
        }

        guessPlayerPostion();
    }

    //listens to player movement to "guess" player location
    void guessPlayerPostion() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                enemyPlayerPositionGuess = hit.point;

                agent.speed = guessedSpeed;
                agent.SetDestination(enemyPlayerPositionGuess);
            }
        }
    }

    //moves towards random navmesh area
    private void wander() {
        Vector3 newPos = findWanderDestination(agentTransform.position, destinationSetRadius, -1);

        agent.speed = wanderSpeed;
        agent.SetDestination(newPos);
        this.timer = 0;
    }

    //finds random destination within navmesh area
    private Vector3 findWanderDestination(Vector3 origin, float radius, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * radius;
        randDirection += origin;
        NavMeshHit hit;
        NavMesh.SamplePosition(randDirection, out hit, radius, layermask);

        return hit.position;
    }


}
