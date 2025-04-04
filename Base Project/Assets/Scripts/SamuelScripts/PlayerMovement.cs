using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 0.4f;
    public float reduceJump = 0.5f;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded; 
    
    void Update()
    {
        // Makes small sphere to check to see if player is touching ground, it will ignore anything not layered with 'Ground' layer.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        /* Use to capture keyboard or controller input for movement  
         * you can assign what Horizontal and Vertical are key binded with in input manager in project settings.*/
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Move across the x and z axis freely
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity) * reduceJump;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity);

        
    }
}
