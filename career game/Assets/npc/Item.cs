using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public float respawnTime = 2f;

    public void PickedUp()
    {
        ItemRespawner.Instance.RespawnItem(gameObject, respawnTime);
    }
}