using System;
using UnityEngine;

public class DialogueNPC : Interactable
{
    [SerializeField]
    private GameObject dialogueBox;  // The UI panel that holds the dialogue text

    private Dialogue1 dialogueScript;  // Reference to the Dialogue1 script

    void Start()
    {
        // Get the Dialogue1 script from the dialogue box (panel)
        dialogueScript = dialogueBox.GetComponent<Dialogue1>();

        // Check if Dialogue1 script is attached to the dialogue box
        if (dialogueScript == null)
        {
            Debug.LogWarning("Dialogue1 script not found on dialogueBox!");
        }
    }

    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);

        // Only start the dialogue if it's not already playing
        if (dialogueScript != null && !dialogueScript.isDialoguePlaying)
        {
            // Activate the dialogue box and restart the dialogue
            dialogueBox.SetActive(true);
            dialogueScript.RestartDialogue();
        }
    }
}

