using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Dialogue1 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    public bool isDialoguePlaying { get; private set; } = false;

    private void Start()
    {
        textComponent.text = string.Empty;
        // Commenting out auto-start for better control
        // StartDialogue();
    }

    private void Update()
    {
        // Listen for input to proceed dialogue with the 'F' key
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    // This method is called by DialogueNPC when you want to start/restart the dialogue
    public void RestartDialogue()
    {
        StopAllCoroutines();
        index = 0;
        textComponent.text = string.Empty; // Clear it here just in case
        gameObject.SetActive(true); // Show dialogue box
        isDialoguePlaying = true; // Freeze player movement here

        StartCoroutine(StartTypingNextFrame());
    }

    private IEnumerator StartTypingNextFrame()
    {
        yield return null; // wait 1 frame before starting the typing
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        textComponent.text = string.Empty;

        // Type out each letter of the current line
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    // Move to the next line when 'F' is pressed
    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false); // Hide dialogue box when finished
            isDialoguePlaying = false; // Unfreeze player movement here
        }
    }
}
