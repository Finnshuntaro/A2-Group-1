using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Public Float means that you can access and edit it in within Unity Editor and another script.
    public float mouseSensitivity = 100f;

    // Reference to the players transform. The transform is respoible for managing position, rotation and scale of object.
    public Transform playerBody;

    float xRotation;
    float yRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Locks cursor to centre of screen.    
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the mouse movements and adds the sensitivity value, Time.deltaTime makes sure mouse movement is consistant across frames. 
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Responsible for rotation based on mouse movement. For example yRotation refers to camera rotating around Y axis depending on horizontal mouse movement
        yRotation += mouseX;
        xRotation -= mouseY;

        // Stops the camera from rotating beyond 90 degrees in any direction
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotates the player 'Physical' body depending on horizontal mouse movement
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

}
