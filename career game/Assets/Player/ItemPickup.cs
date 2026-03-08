using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public KeyCode pickupKey = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(pickupKey))
        {
            float distance = Vector3.Distance(
                GameObject.FindGameObjectWithTag("Player").transform.position,
                transform.position
            );

            if (distance < 3f)
            {
                PlayerInventory inventory = GameObject
                    .FindGameObjectWithTag("Player")
                    .GetComponent<PlayerInventory>();

                inventory.AddItem(item.itemName);
                Destroy(gameObject);
            }
        }
    }
}