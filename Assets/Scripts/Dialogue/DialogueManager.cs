using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string characterName;

        [TextArea(2, 5)]
        public string text;

        public Sprite portrait;
    }

    [Header("UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text characterNameText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image portraitImage;
    [SerializeField] private Image backgroundImage;

    [Header("Portrait Fade")]
    [SerializeField] private CanvasGroup portraitCanvasGroup;
    [SerializeField] private float fadeDuration = 0.2f;

    private List<DialogueLine> currentDialogue;

    private int currentLine;
    private bool dialogueActive;
    private bool isTransitioning;

    private Action onDialogueFinished;

    private void Awake()
    {
        dialoguePanel.SetActive(false);

        if (portraitCanvasGroup != null)
            portraitCanvasGroup.alpha = 0f;
    }

    private void Update()
    {
        if (!dialogueActive || isTransitioning)
            return;

        if (Input.GetMouseButtonDown(0) ||
            Input.GetKeyDown(KeyCode.E) ||
            Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }
    }

    public void StartDialogue(
        List<DialogueLine> dialogue,
        Sprite background = null,
        Action onFinished = null
    )
    {
        if (dialogue == null || dialogue.Count == 0)
            return;

        currentDialogue = dialogue;
        currentLine = 0;
        dialogueActive = true;
        onDialogueFinished = onFinished;

        dialoguePanel.SetActive(true);

        // Background não possui fade.
        if (background != null)
        {
            backgroundImage.sprite = background;
            backgroundImage.gameObject.SetActive(true);
        }
        else
        {
            backgroundImage.gameObject.SetActive(false);
        }

        StartCoroutine(ShowLine(true));
    }

    private IEnumerator ShowLine(bool firstLine = false)
    {
        isTransitioning = true;

        DialogueLine line = currentDialogue[currentLine];

        // Fade OUT apenas do portrait atual.
        if (!firstLine &&
            portraitImage.gameObject.activeSelf &&
            portraitCanvasGroup.alpha > 0f)
        {
            yield return StartCoroutine(
                FadePortrait(
                    portraitCanvasGroup.alpha,
                    0f
                )
            );
        }

        // Troca nome e texto.
        characterNameText.text = line.characterName;
        dialogueText.text = line.text;

        // Configura novo portrait.
        if (line.portrait != null)
        {
            portraitImage.sprite = line.portrait;
            portraitImage.gameObject.SetActive(true);

            portraitCanvasGroup.alpha = 0f;

            // Fade IN apenas do portrait.
            yield return StartCoroutine(
                FadePortrait(0f, 1f)
            );
        }
        else
        {
            portraitCanvasGroup.alpha = 0f;
            portraitImage.gameObject.SetActive(false);
        }

        isTransitioning = false;
    }

    private IEnumerator FadePortrait(
        float startAlpha,
        float endAlpha
    )
    {
        float elapsed = 0f;

        portraitCanvasGroup.alpha = startAlpha;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;

            float progress = elapsed / fadeDuration;

            portraitCanvasGroup.alpha = Mathf.Lerp(
                startAlpha,
                endAlpha,
                progress
            );

            yield return null;
        }

        portraitCanvasGroup.alpha = endAlpha;
    }

    private void NextLine()
    {
        currentLine++;

        if (currentLine >= currentDialogue.Count)
        {
            StartCoroutine(EndDialogue());
            return;
        }

        StartCoroutine(ShowLine());
    }

    private IEnumerator EndDialogue()
    {
        isTransitioning = true;

        // Fade OUT somente do portrait no final.
        if (portraitImage.gameObject.activeSelf &&
            portraitCanvasGroup.alpha > 0f)
        {
            yield return StartCoroutine(
                FadePortrait(
                    portraitCanvasGroup.alpha,
                    0f
                )
            );
        }

        dialogueActive = false;
        currentDialogue = null;

        portraitImage.gameObject.SetActive(false);

        // Background some instantaneamente.
        backgroundImage.gameObject.SetActive(false);

        dialoguePanel.SetActive(false);

        isTransitioning = false;

        onDialogueFinished?.Invoke();
        onDialogueFinished = null;
    }
}