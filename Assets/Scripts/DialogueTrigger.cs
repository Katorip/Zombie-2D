// Manages when dialogue starts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialogueBox;
    private bool conversation;

    public void Start()
    {
        dialogueBox.SetActive(false);
        conversation = false;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        // Start dialogue
        if (col.tag == "Player" && !conversation)
        {
            dialogueBox.SetActive(true);
            TriggerDialogue();
            conversation = true;
        }
    }
}
