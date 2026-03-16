using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttable : MonoBehaviour
{
    public GameObject resultPrefab; // Prefab to spawn after cutting
    public int hitsToCut = 3;

    private int hitCount = 0;

    public void Hit()
    {
        hitCount++;

        if (hitCount >= hitsToCut)
        {
            Cut();
        }
    }

    void Cut()
    {
        Instantiate(resultPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}