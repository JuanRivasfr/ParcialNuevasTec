using UnityEngine;
using UnityEditor;

public class CreateLevelData : EditorWindow
{
    [MenuItem("Tools/Create Level Data Assets")]
    public static void CreateLevels()
    {
        // Crear carpeta si no existe
        if (!AssetDatabase.IsValidFolder("Assets/Code Fighters/Levels"))
        {
            AssetDatabase.CreateFolder("Assets/Code Fighters", "Levels");
        }

        // Crear 5 niveles
        for (int i = 0; i < 5; i++)
        {
            LevelData level = ScriptableObject.CreateInstance<LevelData>();
            level.levelName = $"Nivel {i + 1}";
            level.levelDescription = $"Descripción del nivel {i + 1}";
            level.levelID = i;
            level.requiredXP = i * 100; // Nivel 0: 0 XP, Nivel 1: 100 XP, etc.
            level.rewardXP = 100 + (i * 50); // Recompensa base + bonus
            level.sceneToLoad = "BattleScene";

            string path = $"Assets/Code Fighters/Levels/Level{i + 1}.asset";
            AssetDatabase.CreateAsset(level, path);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("LevelData assets creados en Assets/Code Fighters/Levels/");
    }
}
