using UnityEngine;
using TMPro;

public class NPCRequest : MonoBehaviour
{
    public string[] possibleItems;
    public GameObject exclamationMark;
    public TextMeshPro itemText;

    private string requestedItem;
    private bool isRequesting;

    private Transform player;
    private PlayerItemHolder playerHolder;
    private NPCManager manager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHolder = player.GetComponent<PlayerItemHolder>();
        manager = FindObjectOfType<NPCManager>();

        exclamationMark.SetActive(false);
        itemText.text = "";
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
            requestedItem = possibleItems[Random.Range(0, possibleItems.Length)];

            itemText.text = requestedItem;
        }
        else
        {
            itemText.text = "";
        }
    }

    void TryGiveItem()
    {
        if (playerHolder.heldItemName == requestedItem)
        {
            playerHolder.ClearItem();

            FindObjectOfType<LevelGoalManager>().ItemDelivered();

            SetActiveRequest(false);

            manager.ChooseRandomNPC();
        }
    }
}