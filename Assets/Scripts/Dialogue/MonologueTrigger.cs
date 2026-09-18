using System.Collections.Generic;
using UnityEngine;

public class MonologueTrigger : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] private DialogueManager dialogueManager;

    [Header("Monologue")]
    [SerializeField] private Sprite background;

    [SerializeField]
    private List<DialogueManager.DialogueLine> monologueLines;

    public void PlayMonologue()
    {
        dialogueManager.StartDialogue(
            monologueLines,
            background
        );
    }
}