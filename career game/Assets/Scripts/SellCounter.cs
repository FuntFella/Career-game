using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;

public class SellCounter : MonoBehaviour
{
    [Header("Sellable Objects")]
    public List<GameObject> sellablePrefabs;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip sellSound;

    private void OnTriggerEnter(Collider other)
    {
        GameObject incomingObject = other.gameObject;

        foreach (GameObject prefab in sellablePrefabs)
        {
            // Check if the object matches a sellable prefab by name
            if (incomingObject.name.Contains(prefab.name))
            {
                SellObject(incomingObject);
                return;
            }
        }
    }

    void SellObject(GameObject obj)
    {
        // Play sound
        if (audioSource != null && sellSound != null)
        {
            audioSource.PlayOneShot(sellSound);
        }

        // Destroy object
        Destroy(obj);
    }
}