using UnityEngine;

public class NPCRequest : MonoBehaviour
{
    public string[] possibleItems;

    private string requestedItem;
    private bool requestActive = false;

    private PlayerInventory playerInventory;

    void Start()
    {
        playerInventory = GameObject
            .FindGameObjectWithTag("Player")
            .GetComponent<PlayerInventory>();

        ChooseRandomItem();
    }

    void Update()
    {
        if (requestActive && Input.GetKeyDown(KeyCode.E))
        {
            TryGiveItem();
        }
    }

    void ChooseRandomItem()
    {
        int randomIndex = Random.Range(0, possibleItems.Length);
        requestedItem = possibleItems[randomIndex];

        Debug.Log("NPC wants: " + requestedItem);
        requestActive = true;
    }

    void TryGiveItem()
    {
        if (playerInventory.HasItem(requestedItem))
        {
            playerInventory.RemoveItem(requestedItem);

            Debug.Log("NPC received: " + requestedItem);
            requestActive = false;

            ChooseRandomItem();
        }
        else
        {
            Debug.Log("You don't have the item!");
        }
    }
}