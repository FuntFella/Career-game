using UnityEngine;

public class PlayerItemHolder : MonoBehaviour
{
    public string heldItemName;

    public bool HasItem()
    {
        return heldItemName != "";
    }

    public void PickItem(string itemName)
    {
        heldItemName = itemName;
        Debug.Log("Holding: " + itemName);
    }

    public void ClearItem()
    {
        heldItemName = "";
    }
}