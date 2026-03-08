using UnityEngine;
using System.Collections;

public class ItemRespawner : MonoBehaviour
{
    public static ItemRespawner Instance;

    void Awake()
    {
        Instance = this;
    }

    public void RespawnItem(GameObject item, float time)
    {
        StartCoroutine(Respawn(item, time));
    }

    IEnumerator Respawn(GameObject item, float time)
    {
        item.SetActive(false);

        yield return new WaitForSeconds(time);

        item.SetActive(true);
    }
}