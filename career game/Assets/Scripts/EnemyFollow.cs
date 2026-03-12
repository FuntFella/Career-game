using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 3.5f;
    public float chaseDistance = 10f;

    private Transform playerTarget;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTarget = player.transform;
        }

        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent != null)
        {
            navMeshAgent.speed = speed;
        }
    }

    void Update()
    {
        if (playerTarget == null || navMeshAgent == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);

        if (distanceToPlayer <= chaseDistance)
        {
            navMeshAgent.SetDestination(playerTarget.position);
        }
        else
        {
            navMeshAgent.ResetPath();
        }
    }
}