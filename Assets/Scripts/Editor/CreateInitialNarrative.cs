using UnityEngine;
using UnityEditor;

public class CreateInitialNarrative : EditorWindow
{
    [MenuItem("Tools/Create Initial Narrative Dialogue")]
    public static void CreateDialogueSequence()
    {
        // Crear el DialogueSequence
        DialogueSequence dialogue = ScriptableObject.CreateInstance<DialogueSequence>();
        
        // Configurar las líneas de diálogo
        dialogue.dialogueLines = new DialogueSequence.DialogueLine[]
        {
            new DialogueSequence.DialogueLine
            {
                speakerName = "NARRATOR",
                speakerType = DialogueSequence.SpeakerType.Narrator,
                dialogueText = "En la edad 2099, la humanidad vive dentro del Ciberdojo, un sistema virtual controlado por codigo puro.",
                autoAdvanceDelay = 0f
            },
            new DialogueSequence.DialogueLine
            {
                speakerName = "NARRATOR",
                speakerType = DialogueSequence.SpeakerType.Narrator,
                dialogueText = "Pero todo cambio cuando aparecio The Syntax Error, un virus que ha infectado el mundo digital.",
                autoAdvanceDelay = 0f
            },
            new DialogueSequence.DialogueLine
            {
                speakerName = "SYSTEM",
                speakerType = DialogueSequence.SpeakerType.System,
                dialogueText = "Mis sistemas estan fallando.. Los virus estan por todas partes. Necesito a alguien que pueda limpiarlos.",
                autoAdvanceDelay = 0f
            },
            new DialogueSequence.DialogueLine
            {
                speakerName = "BYTE",
                speakerType = DialogueSequence.SpeakerType.Zeven,
                dialogueText = "Soy Byte. He entrenado toda mi vida para este momento. Usare mis habilidades para eliminar cada Virus.",
                autoAdvanceDelay = 0f
            },
            new DialogueSequence.DialogueLine
            {
                speakerName = "SYSTEM",
                speakerType = DialogueSequence.SpeakerType.System,
                dialogueText = "¡Preparate, Byte! Tu primer enemigo se acerca.",
                autoAdvanceDelay = 0f
            }
        };
        
        // Guardar el asset
        string path = "Assets/InitialNarrative.asset";
        AssetDatabase.CreateAsset(dialogue, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        
        // Seleccionar el asset creado
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = dialogue;
        
        Debug.Log($"DialogueSequence creado en: {path}");
    }
}
