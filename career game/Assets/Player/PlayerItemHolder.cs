using UnityEngine;

public class PlayerItemHolder : MonoBehaviour
{
    public string heldItemName = "";

    public bool HasItem()
    {
        return heldItemName != "";
    }

    public void PickItem(string itemName)
    {
        heldItemName = itemName;
        Debug.Log("Holding: " + itemName);
    }

    public void DropItem()
    {
        Debug.Log("Dropped: " + heldItemName);
        heldItemName = "";
    }

    public void SwapItem(string newItem)
    {
        Debug.Log("Swapped " + heldItemName + " for " + newItem);
        heldItemName = newItem;
    }

    public void ClearItem()
    {
        heldItemName = "";
    }
}