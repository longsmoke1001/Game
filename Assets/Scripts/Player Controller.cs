using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Horizontal/vertical move speed (m/s)")]
    public float speed = 5f;
    [Tooltip("Upwards impulse applied when jumping")]
    public float jumpForce = 5f;
    [Tooltip("Maximum distance to consider the player grounded")]
    public float groundCheckDistance = 0.1f;
    [Tooltip("Layers considered ground")]
    public LayerMask groundMask;

    [Header("Interaction")]
    [Tooltip("Key to interact")]
    public KeyCode interactKey = KeyCode.E;
    [Tooltip("Max distance for interaction raycast")]
    public float interactRange = 2f;

    private Rigidbody rb;
    private bool jumpRequested;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Prevent physics from rotating the player accidentally.
        rb.freezeRotation = true;
    }       

    // Update is called once per frame
    void Update()
    {
        // Read jump input in Update so it's responsive
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpRequested = true;
        }

        // Interaction
        if (Input.GetKeyDown(interactKey))
        {
            Interact();
        }
    }

    void FixedUpdate()
    {
        Move();
        if (jumpRequested)
        {
            DoJump();
            jumpRequested = false;
        }
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Movement relative to player orientation
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        Vector3 horizontalVelocity = move.normalized * speed;

        // Preserve current Y velocity (gravity / jump)
        Vector3 newVelocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.z);
        rb.velocity = newVelocity;
    }

    private void DoJump()
    {
        // Replace Y velocity with jump impulse for consistent jumps
        Vector3 v = rb.velocity;
        v.y = 0f;
        rb.velocity = v;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }

    private bool IsGrounded()
    {
        // Cast a short ray downward to check for ground
        Vector3 origin = transform.position + Vector3.up * 0.1f;
        return Physics.Raycast(origin, Vector3.down, groundCheckDistance + 0.1f, groundMask);
    }

    private void Interact()
    {
        // Raycast from the camera if available, otherwise from player forward
        Camera cam = Camera.main;
        Vector3 origin;
        Vector3 dir;

        if (cam != null)
        {
            origin = cam.transform.position;
            dir = cam.transform.forward;
        }
        else
        {
            origin = transform.position + Vector3.up * 1.0f;
            dir = transform.forward;
        }

        if (Physics.Raycast(origin, dir, out RaycastHit hit, interactRange))
        {
            // Try common interaction patterns
            // 1) Call an interface method if present
            var interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.OnInteract();
                return;
            }

            // 2) SendMessage fallback (calls method named "OnInteract" if present)
            hit.collider.gameObject.SendMessage("OnInteract", SendMessageOptions.DontRequireReceiver);
        }
    }
}

// Simple interaction interface you can implement on other objects
public interface IInteractable
{
    void OnInteract();
}
