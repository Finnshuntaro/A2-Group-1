using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform; // Assign this in the Inspector (Main Camera)

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 0.4f;
    public float reduceJump = 0.5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;

    void Update()
    {
        // Check if the player is touching the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Capture movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Get camera-relative movement direction
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        // Flatten camera vectors to prevent unintended vertical movement
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // Create movement vector relative to camera
        Vector3 move = camRight * x + camForward * z;

        // **Fix: Normalize the movement vector to prevent diagonal speed boost**
        if (move.magnitude > 1)
        {
            move.Normalize();
        }

        // Apply movement
        controller.Move(move * speed * Time.deltaTime);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity) * reduceJump;
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
