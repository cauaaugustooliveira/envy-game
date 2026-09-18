using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;

    [Header("Dialogue")]
    [SerializeField] private List<DialogueManager.DialogueLine> dialogueLines;
    public bool dialogueFinished;

    [Header("Scenario")]
    [SerializeField] private Sprite background;

    [Header("Progression")]
    [SerializeField] private NPCDialogueProgression progression;

    private bool playerInside;
    private bool dialogueStarted;
    

    private void Update()
    {
        if (playerInside &&
            !dialogueStarted &&
            Input.GetKeyDown(KeyCode.E))
        {
            dialogueStarted = true;

            dialogueManager.StartDialogue(
                dialogueLines,
                background,
                DialogueFinished
            );
        }
    }

    private void DialogueFinished()
    {
        dialogueStarted = false;
        dialogueFinished = true;

        if (progression != null)
            progression.CompleteCurrentTalk();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
