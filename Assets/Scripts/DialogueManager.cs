// Manages dialogue

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // UI elements
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;

    // Dialogue texts
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.SetActive(false);
    }

    // Start the dialogue
    public void StartDialogue(Dialogue dialogue)
    {
        // Set who is speaking
        nameText.text = dialogue.name;

        sentences.Clear();

        // Set dialogue sentences
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        // Check if there is any sentences left
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        // Get next dialogue sentence
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // Type sentence letter by letter
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }
}
