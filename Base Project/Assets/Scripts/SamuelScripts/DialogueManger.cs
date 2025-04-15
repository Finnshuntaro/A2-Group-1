using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Use the TMPro namespace for TextMeshPro components


public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;   // The panel that will show the dialogue UI
    public TextMeshProUGUI nameText;   // The TextMeshProUGUI component for displaying the NPC's name
    public TextMeshProUGUI dialogueText; // The TextMeshProUGUI component for displaying the dialogue
    public float textSpeed; // How fast the text is typed out in the dialogue box

    private Queue<string> sentences;   // Queue to hold all the sentences of dialogue
    private bool isDialogueActive = false;  // Flag to check if dialogue is active
    private Coroutine typingCoroutine; // Keeps track of the currently running typing effect so it can be stopped if needed

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
        if (isDialogueActive && Input.GetKeyDown(KeyCode.F))
        {
            if (typingCoroutine != null)
            {
                // Instantly finish typing the current line
                StopCoroutine(typingCoroutine);
                dialogueText.text = sentences.Peek(); // Show whole sentence
                typingCoroutine = null;
            }
            else
            {
                DisplayNextSentence();
            }
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
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeSentence(sentence));           // Display it in the dialogue box
    }

    // End the dialogue when all sentences are displayed
    private void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);  // Hide the dialogue panel
    }

    private IEnumerator TypeSentence(string sentence) // 
    {
        dialogueText.text = "";

        foreach (char letter in sentence)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        typingCoroutine = null; // Reset when done
    }
}