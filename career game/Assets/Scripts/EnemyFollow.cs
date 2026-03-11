using UnityEngine;
using UnityEngine.AI; // Required for NavMeshAgent

public class EnemyFollow : MonoBehaviour
{
    public float speed = 3.5f; //
    public float chaseDistance = 10f; // Distance to start chasing
    private Transform playerTarget;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        // Find the player object by tag
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the NavMeshAgent component
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent != null)
        {
            navMeshAgent.speed = speed;
        }
    }

    void Update()
    {
        if (playerTarget != null && navMeshAgent != null)
        {
            // Calculate the distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);

            if (distanceToPlayer <= chaseDistance)
            {
                // Set the destination to the player's position to start chasing
                navMeshAgent.SetDestination(playerTarget.position);
            }
            else
            {
                // Stop moving if the player is out of range
                navMeshAgent.SetDestination(transform.position);
            }
        }
    }
}
