using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 4f;
    public TextMeshProUGUI itemNameText;

    private Camera cam;
    private PlayerItemHolder holder;

    void Start()
    {
        cam = GetComponent<Camera>();
        holder = GetComponentInParent<PlayerItemHolder>();
    }

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            Item item = hit.collider.GetComponent<Item>();

            if (item != null)
            {
                itemNameText.text = item.itemName;
                itemNameText.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!holder.HasItem())
                    {
                        holder.PickItem(item.itemName);
                    }
                    else
                    {
                        holder.SwapItem(item.itemName);
                    }

                    item.PickedUp();
                }

                return;
            }
        }

        itemNameText.enabled = false;
    }
}