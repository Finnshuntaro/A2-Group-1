using UnityEngine;

public class FootstepsCode : MonoBehaviour
{
    public AudioClip footstepSound;
    public float footstepInterval = 0.5f;
    private AudioSource audioSource;
    private float timeSinceLastStep = 0f;

    public PlayerMotor playerMotor;

    public float minPitch = 0.9f;
    public float maxPitch = 1.5f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (playerMotor == null)
        {
            playerMotor = GetComponentInParent<PlayerMotor>();
        }
    }

    private void Update()
    {
        float moveInput = Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));

        if (moveInput > 0f && playerMotor != null && playerMotor.IsGrounded())
        {
            timeSinceLastStep += Time.deltaTime;

            if (timeSinceLastStep >= footstepInterval)
            {
                PlayFootstepSound();
                timeSinceLastStep = 0f;
            }
        }
    }

    private void PlayFootstepSound()
    {
        // Makes the pitch of the audio slightly random to reduce Sound Fatigue
        if (footstepSound != null && audioSource != null)
        {
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.PlayOneShot(footstepSound);
            audioSource.pitch = 1.0f;
        }
    }
}
