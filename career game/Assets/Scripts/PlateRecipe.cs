using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateRecipe : MonoBehaviour
{
    public List<GameObject> requiredPrefabs;   // Prefabs required for the recipe
    public GameObject resultPrefab;            // Final dish prefab to spawn

    private List<GameObject> ingredientsOnPlate = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cart"))
        {
            ingredientsOnPlate.Add(other.gameObject);
            CheckRecipe();
        }
    }

    void CheckRecipe()
    {
        if (ingredientsOnPlate.Count < requiredPrefabs.Count)
            return;

        List<GameObject> matched = new List<GameObject>();

        foreach (GameObject ingredient in ingredientsOnPlate)
        {
            foreach (GameObject req in requiredPrefabs)
            {
                if (ingredient.name.Contains(req.name) && !matched.Contains(ingredient))
                {
                    matched.Add(ingredient);
                    break;
                }
            }
        }

        if (matched.Count == requiredPrefabs.Count)
        {
            foreach (GameObject obj in matched)
            {
                ingredientsOnPlate.Remove(obj);
                Destroy(obj);
            }

            Instantiate(resultPrefab, transform.position + Vector3.up * 0.2f, Quaternion.identity);
        }
    }
}