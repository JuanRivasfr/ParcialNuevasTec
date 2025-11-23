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
                dialogueText = "En el año 2099, la humanidad vive dentro del Ciberdojo, un sistema virtual controlado por código puro.",
                autoAdvanceDelay = 0f
            },
            new DialogueSequence.DialogueLine
            {
                speakerName = "NARRATOR",
                speakerType = DialogueSequence.SpeakerType.Narrator,
                dialogueText = "Pero todo cambió cuando apareció The Syntax Error, un virus que ha infectado el mundo digital.",
                autoAdvanceDelay = 0f
            },
            new DialogueSequence.DialogueLine
            {
                speakerName = "SYSTEM",
                speakerType = DialogueSequence.SpeakerType.System,
                dialogueText = "Mis sistemas están fallando.. Los Bugs están por todas partes. Necesito a alguien que pueda escribir código perfecto.",
                autoAdvanceDelay = 0f
            },
            new DialogueSequence.DialogueLine
            {
                speakerName = "ZEVEN",
                speakerType = DialogueSequence.SpeakerType.Zeven,
                dialogueText = "Soy Zeven. He entrenado toda mi vida para este momento. Usaré mis habilidades de programación para eliminar cada Bug.",
                autoAdvanceDelay = 0f
            },
            new DialogueSequence.DialogueLine
            {
                speakerName = "SYSTEM",
                speakerType = DialogueSequence.SpeakerType.System,
                dialogueText = "¡Prepárate, Zeven! Tu primer enemigo se acerca. Recuerda: cada línea de código cuenta.",
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
