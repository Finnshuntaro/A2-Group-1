using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Use the TMPro namespace for TextMeshPro components


public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;   // The panel that will show the dialogue UI
    public TextMeshProUGUI nameText;   // The TextMeshProUGUI component for displaying the NPC's name
    public TextMeshProUGUI dialogueText; // The TextMeshProUGUI component for displaying the dialogue
    private Queue<string> sentences;   // Queue to hold all the sentences of dialogue
    private bool isDialogueActive = false;  // Flag to check if dialogue is active

    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);  // Initially hide the dialogue panel
    }

    // Method to start the dialogue for an NPC
    public void StartDialogue(NPCScript npc)
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);  // Show the dialogue panel
        nameText.text = npc.npcName;    // Display the NPC's name in the UI
        sentences.Clear();              // Clear any previous sentences

        // Add each sentence from the NPC's dialogue lines to the queue
        foreach (string sentence in npc.dialogueLines)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();  // Display the first sentence
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.F))  // If dialogue is active, and the player presses F
        {
            DisplayNextSentence();  // Display the next sentence in the dialogue
        }
    }

    // Display the next sentence in the queue
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();  // Get the next sentence from the queue
        dialogueText.text = sentence;           // Display it in the dialogue box
    }

    // End the dialogue when all sentences are displayed
    private void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);  // Hide the dialogue panel
    }
}