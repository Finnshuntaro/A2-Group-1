using System;
using UnityEngine;

public class DialogueNPC : Interactable

{
    [SerializeField]
    private GameObject dialogueTrigger;

    private Dialogue1 dialogueScript;

    void Start()
    {
        dialogueScript = dialogueTrigger.GetComponent<Dialogue1>();

        if (dialogueScript == null)
        {
            Debug.LogWarning("Dialogue1 script not found on dialogueTrigger!");
        }
    }

    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        {
            var dialogueScript = dialogueTrigger.GetComponent<Dialogue1>();

            if (dialogueScript != null && !dialogueScript.isDialoguePlaying)
            {
                dialogueTrigger.SetActive(true);
                dialogueScript.RestartDialogue();
            }
        }
    }
}
