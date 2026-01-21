
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Move : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float airControlMultiplier = 0.6f;

    [Header("Jumping")]
    public float jumpHeight = 2f;
    public float gravity = -20f;

    [Header("Platformer Feel")]
    public float coyoteTime = 0.15f;     // Time allowed to jump after leaving ground
    public float jumpBufferTime = 0.15f; // Time jump input is remembered

    private CharacterController controller;
    private Vector3 velocity;

    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        ApplyGravity();
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        float control = controller.isGrounded ? 1f : airControlMultiplier;
        controller.Move(move * moveSpeed * control * Time.deltaTime);
    }

    void HandleJump()
    {
        // Update coyote time
        if (controller.isGrounded)
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;

        // Update jump buffer
        if (Input.GetButtonDown("Jump"))
            jumpBufferCounter = jumpBufferTime;
        else
            jumpBufferCounter -= Time.deltaTime;

        // Perform jump
        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpBufferCounter = 0f;
            coyoteTimeCounter = 0f;
        }
    }

    void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0f)
            velocity.y = -2f; // Keeps player grounded

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}