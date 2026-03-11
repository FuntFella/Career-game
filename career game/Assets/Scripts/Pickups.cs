using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Pickups : MonoBehaviour
{
    [Header("Pickup Settings")]
    public GameObject pickupPrefab;

    [Header("Spawn Settings")]
    public Transform spawnPoint;
    public float spawnForce = 2f;

    void OnMouseDown()
    {
        if (pickupPrefab == null)
        {
            Debug.LogWarning("Pickup prefab not assigned.");
            return;
        }

        Vector3 spawnPos;

        if (spawnPoint != null)
            spawnPos = spawnPoint.position;
        else
            spawnPos = transform.position + Vector3.up * 0.5f;

        GameObject pickup = Instantiate(pickupPrefab, spawnPos, Quaternion.identity);

        Rigidbody rb = pickup.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // small pop so it feels physical
            rb.AddForce(Vector3.up * spawnForce, ForceMode.Impulse);
        }
    }
}