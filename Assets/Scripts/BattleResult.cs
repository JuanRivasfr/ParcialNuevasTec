using UnityEngine;

[System.Serializable]
public class BattleResult
{
    public bool playerWon;
    public int levelID;
    public int playerHealth;
    public float timeElapsed;
    
    // Constructor opcional
    public BattleResult()
    {
        playerWon = false;
        levelID = 0;
        playerHealth = 0;
        timeElapsed = 0f;
    }
    
    public BattleResult(bool won, int level, int health, float time)
    {
        playerWon = won;
        levelID = level;
        playerHealth = health;
        timeElapsed = time;
    }
}

