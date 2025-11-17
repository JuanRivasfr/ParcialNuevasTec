using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Dialogue Sequence", menuName = "Code Fighters/Dialogue Sequence")]
public class DialogueSequence : ScriptableObject
{
    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName;
        public SpeakerType speakerType;
        public string dialogueText;
        public float autoAdvanceDelay = 0f; // 0 = manual, >0 = auto advance after seconds
    }

    public enum SpeakerType
    {
        Narrator,
        System,
        Zeven
    }

    public DialogueLine[] dialogueLines;
}
