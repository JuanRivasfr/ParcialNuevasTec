using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Image avatarImage;
    [SerializeField] private TextMeshProUGUI speakerNameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Button nextButton;
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI progressText;

    [Header("Avatar Sprites")]
    [SerializeField] private Sprite narratorAvatar;
    [SerializeField] private Sprite systemAvatar;
    [SerializeField] private Sprite zevenAvatar;

    [Header("Settings")]
    [SerializeField] private float textSpeed = 0.05f;
    [SerializeField] private bool autoAdvance = false;

    private DialogueSequence currentSequence;
    private int currentLineIndex = 0;
    private bool isDisplayingText = false;
    private Coroutine textDisplayCoroutine;

    private void Start()
    {
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(OnNextClicked);
        }

        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
    }

    public void LoadDialogueSequence(DialogueSequence sequence)
    {
        if (sequence == null || sequence.dialogueLines == null || sequence.dialogueLines.Length == 0)
        {
            Debug.LogError("Dialogue sequence is null or empty!");
            return;
        }

        currentSequence = sequence;
        currentLineIndex = 0;
        
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(true);
        }

        DisplayCurrentLine();
    }

    private void DisplayCurrentLine()
    {
        if (currentSequence == null || currentLineIndex >= currentSequence.dialogueLines.Length)
        {
            EndDialogue();
            return;
        }

        DialogueSequence.DialogueLine line = currentSequence.dialogueLines[currentLineIndex];

        // Set speaker name
        if (speakerNameText != null)
        {
            speakerNameText.text = $"> {line.speakerName}";
        }

        // Set avatar based on speaker type
        SetAvatar(line.speakerType);

        // Display text
        if (textDisplayCoroutine != null)
        {
            StopCoroutine(textDisplayCoroutine);
        }
        textDisplayCoroutine = StartCoroutine(TypeText(line.dialogueText));

        // Update progress
        UpdateProgress();

        // Auto advance if configured
        if (line.autoAdvanceDelay > 0)
        {
            Invoke(nameof(OnNextClicked), line.autoAdvanceDelay);
        }
    }

    private void SetAvatar(DialogueSequence.SpeakerType speakerType)
    {
        if (avatarImage == null) return;

        Sprite avatarSprite = null;
        switch (speakerType)
        {
            case DialogueSequence.SpeakerType.Narrator:
                avatarSprite = narratorAvatar;
                break;
            case DialogueSequence.SpeakerType.System:
                avatarSprite = systemAvatar;
                break;
            case DialogueSequence.SpeakerType.Zeven:
                avatarSprite = zevenAvatar;
                break;
        }

        if (avatarSprite != null)
        {
            avatarImage.sprite = avatarSprite;
            avatarImage.enabled = true;
        }
        else
        {
            avatarImage.enabled = false;
        }
    }

    private IEnumerator TypeText(string text)
    {
        isDisplayingText = true;
        if (dialogueText != null)
        {
            dialogueText.text = "";
            foreach (char letter in text)
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(textSpeed);
            }
        }
        isDisplayingText = false;
    }

    private void UpdateProgress()
    {
        if (currentSequence == null) return;

        float progress = (float)(currentLineIndex + 1) / currentSequence.dialogueLines.Length;
        
        if (progressBar != null)
        {
            progressBar.fillAmount = progress;
        }

        if (progressText != null)
        {
            progressText.text = $"{currentLineIndex + 1}/{currentSequence.dialogueLines.Length}";
        }
    }

    public void OnNextClicked()
    {
        if (isDisplayingText)
        {
            // Skip typing animation
            if (textDisplayCoroutine != null)
            {
                StopCoroutine(textDisplayCoroutine);
            }
            if (dialogueText != null && currentSequence != null && currentLineIndex < currentSequence.dialogueLines.Length)
            {
                dialogueText.text = currentSequence.dialogueLines[currentLineIndex].dialogueText;
            }
            isDisplayingText = false;
            return;
        }

        currentLineIndex++;
        DisplayCurrentLine();
    }

    private void EndDialogue()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }

        // Load next scene (CiberDojo)
        SceneRouter.Instance?.LoadCiberDojo();
    }

    public void LoadInitialNarrative()
    {
        // This will be called from the scene or another manager
        // For now, you can create a DialogueSequence asset and assign it
        Debug.Log("Load initial narrative - Assign a DialogueSequence asset to load it");
    }
}
