using UnityEngine;

public class FootstepsCode : MonoBehaviour
{
    public AudioClip footstepSound; // Drag your footstep sound clip here in the Inspector
    public float footstepInterval = 0.5f; // Interval between footsteps
    private AudioSource audioSource; // AudioSource component
    private float timeSinceLastStep = 0f; // Timer to control when to play the next footstep

    public PlayerMovement playerMovement; // Reference to the PlayerMovement script

    public float minPitch = 0.9f; // Minimum pitch value
    public float maxPitch = 1.5f; // Maximum pitch value

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        if (playerMovement == null)
        {
            playerMovement = GetComponentInParent<PlayerMovement>(); // If not assigned, try to get it from the parent object
        }
    }

    private void Update()
    {
        // Check if the player is grounded and moving (using WASD or Arrow keys)
        float moveInput = Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));

        // If the player is grounded and moving, play footstep sound
        if (moveInput > 0f && playerMovement.isGrounded)
        {
            timeSinceLastStep += Time.deltaTime;

            if (timeSinceLastStep >= footstepInterval)
            {
                PlayFootstepSound();
                timeSinceLastStep = 0f; // Reset the timer
            }
        }
    }

    private void PlayFootstepSound()
    {
        if (footstepSound != null && audioSource != null)
        {
            // **Apply a random pitch**
            audioSource.pitch = Random.Range(minPitch, maxPitch);

            // Play the sound
            audioSource.PlayOneShot(footstepSound);

            Debug.Log("Footstep Pitch: " + audioSource.pitch);

            // Reset pitch to default (so other sounds aren't affected)
            audioSource.pitch = 1.0f;
        }
    }
}
