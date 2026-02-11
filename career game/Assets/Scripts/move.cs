using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public Rigidbody rigidbody;
    // Magnitude of upwards force
    public float upForce = 10.0f;

    void Start()
    {
        // Adds an instantaneous upwards force (magnitude: upForce), ignoring rigidbody mass.
        
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        // Calls Jump only on the frame the space bar was pressed.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * upForce, ForceMode.VelocityChange);
        }
        transform.position += Vector3.forward * moveSpeed * horizontalInput * Time.deltaTime;
    }
}