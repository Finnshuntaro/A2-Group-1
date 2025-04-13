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

    public void RestartDialogue()
    {
        StopAllCoroutines();
        index = 0;
        textComponent.text = string.Empty; // <- Clear it here too, just in case
        gameObject.SetActive(true);
        isDialoguePlaying = true;

        StartCoroutine(StartTypingNextFrame());
    }

    private IEnumerator StartTypingNextFrame()
    {
        yield return null; // wait 1 frame
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        textComponent.text = string.Empty;

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

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
            gameObject.SetActive(false); // Hide when done
            isDialoguePlaying = false;
        }
    }
}
