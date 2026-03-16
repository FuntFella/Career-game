using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Camera playerCamera;
    public float pickupRange = 456f;
    public float holdDistance = 2f;
    public KeyCode pickupKey = KeyCode.E;

    private GameObject heldObject;
    private Rigidbody heldRb;

    void Update()
    {
        if (Input.GetKeyDown(pickupKey))
        {
            if (heldObject == null)
                TryPickup();
            else
                DropObject();
        }

        if (heldObject != null)
            HoldObject();
    }

    void TryPickup()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Cart"))
            {
                heldObject = hit.collider.gameObject;
                heldRb = heldObject.GetComponent<Rigidbody>();

                heldRb.useGravity = false;
                heldRb.velocity = Vector3.zero;
                heldRb.angularVelocity = Vector3.zero;

                // Optional: make it kinematic for smoother movement
                heldRb.isKinematic = true;
            }
        }
    }

    void HoldObject()
    {
        // Position in front of camera
        Vector3 targetPosition = playerCamera.transform.position + playerCamera.transform.forward * holdDistance;
        heldObject.transform.position = targetPosition;

        // Rotate to match player's Y rotation only
        heldObject.transform.rotation = Quaternion.Euler(
            0f,
            playerCamera.transform.eulerAngles.y,
            0f
        );
    }

    void DropObject()
    {
        heldRb.useGravity = true;
        heldRb.isKinematic = false;

        heldObject = null;
        heldRb = null;
    }
}