using UnityEngine;

public class IntroNarrativaInitializer : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private DialogueSequence initialNarrative;

    private void Start()
    {
        LoadInitialNarrative();
    }

    public void LoadInitialNarrative()
    {
        DialogueSystem dialogueSystem = FindObjectOfType<DialogueSystem>();
        
        if (dialogueSystem != null && initialNarrative != null)
        {
            dialogueSystem.LoadDialogueSequence(initialNarrative);
        }
        else
        {
            Debug.LogWarning("DialogueSystem or initialNarrative not found! Please assign a DialogueSequence asset.");
        }
    }
}
