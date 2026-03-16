using UnityEngine;

public class NewBossChase : MonoBehaviour
{
    public Transform player;       // Assign your player in the Inspector
    public float moveSpeed = 3f;   // Movement speed
    public float rotationSpeed = 5f; // How fast the boss turns
    public float chaseDistance = 20f; // How far the boss can detect the player

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= chaseDistance)
        {
            MoveAndFacePlayer();
        }
    }

    void MoveAndFacePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
}