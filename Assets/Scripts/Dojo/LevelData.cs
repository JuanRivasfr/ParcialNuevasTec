using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Code Fighters/Level Data", order = 1)]
public class LevelData : ScriptableObject
{
    [Header("Level Info")]
    public string levelName = "Nivel 1";
    [TextArea(3, 5)]
    public string levelDescription = "Descripción del nivel";
    
    [Header("Level Configuration")]
    public int levelID = 0;
    public int requiredXP = 0; // XP necesaria para desbloquear
    public int rewardXP = 100; // XP que da al completar
    
    [Header("Visuals")]
    public Sprite levelIcon;
    
    [Header("Scene Settings")]
    public string sceneToLoad = "BattleScene";
    
    // Método helper para verificar si el nivel está desbloqueado
    public bool IsUnlocked(int playerXP)
    {
        return playerXP >= requiredXP;
    }
}

