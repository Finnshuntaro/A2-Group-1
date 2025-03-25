using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public AudioSource yeahSound;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            yeahSound.enabled = true;
        }
        else
        {
            yeahSound.enabled = false;
        }
    }
}
