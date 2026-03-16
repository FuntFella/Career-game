using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Fell! You Lose!");
        }

        if (other.CompareTag("Boss"))
        {
            Debug.Log("Boss Fell! You Win!");
        }
    }
}