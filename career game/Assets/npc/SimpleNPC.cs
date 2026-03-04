using UnityEngine;

public class SimpleNPC : MonoBehaviour
{
    [Header("Dialogue")]
    [TextArea(3, 5)]
    public string[] dialogueLines;

    [Header("Interaction")]
    public float interactDistance = 3f;
    public KeyCode interactKey = KeyCode.E;

    [Header("Animation (Optional)")]
    public Animator animator;
    private bool isTalking;

    private Transform player;
    private int currentLine = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= interactDistance && Input.GetKeyDown(interactKey))
        {
            Talk();
        }
    }

    void Talk()
    {
        if (dialogueLines.Length == 0)
            return;

        if (!isTalking)
        {
            isTalking = true;

            // Trigger animation later if added
            if (animator != null)
                animator.SetBool("IsTalking", true);
        }

        Debug.Log(dialogueLines[currentLine]);

        currentLine++;

        if (currentLine >= dialogueLines.Length)
        {
            EndConversation();
        }
    }

    void EndConversation()
    {
        currentLine = 0;
        isTalking = false;

        if (animator != null)
            animator.SetBool("IsTalking", false);
    }
}