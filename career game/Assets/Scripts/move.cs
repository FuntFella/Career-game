using UnityEngine;

public class Move : MonoBehaviour
{
    private float horizontalInput;
    public float moveSpeed = 2.0f;
    public Rigidbody rb;
    // Magnitude of upwards force
    public float jumpForce = 10.0f;
    public bool isFalling = true;
    void Start()
    {
        // Adds an instantaneous upwards force (magnitude: upForce), ignoring rigidbody mass.
        
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.position += Vector3.forward * moveSpeed * horizontalInput * Time.deltaTime;
        if (!isFalling){
            if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        print("OnCollisionEnter");
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = false;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = true;
        }
    }
}