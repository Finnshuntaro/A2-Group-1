using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstepsSound;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.S)))))
        {
            footstepsSound.enabled = true;
        }
        else
        {
            footstepsSound.enabled = false;
        }
    }
}
