using UnityEngine;

public class NPCRequest : MonoBehaviour
{
    public string requestedItem;
    public GameObject exclamationMark;

    private bool isRequesting = false;
    private Transform player;
    private PlayerItemHolder playerHolder;
    private NPCManager manager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHolder = player.GetComponent<PlayerItemHolder>();
        manager = FindObjectOfType<NPCManager>();

        exclamationMark.SetActive(false);
    }

    void Update()
    {
        if (!isRequesting) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < 3f && Input.GetKeyDown(KeyCode.E))
        {
            TryGiveItem();
        }
    }

    public void SetActiveRequest(bool active)
    {
        isRequesting = active;
        exclamationMark.SetActive(active);

        if (active)
        {
            Debug.Log(gameObject.name + " wants: " + requestedItem);
        }
    }

    void TryGiveItem()
    {
        if (playerHolder.heldItemName == requestedItem)
        {
            Debug.Log("Correct item!");

            playerHolder.ClearItem();

            SetActiveRequest(false);

            manager.ChooseRandomNPC();
        }
        else
        {
            Debug.Log("Wrong item");
        }
    }
}