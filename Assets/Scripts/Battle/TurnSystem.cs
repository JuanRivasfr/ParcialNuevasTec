using UnityEngine;

public enum TurnState
{
    PlayerTurn,
    EnemyTurn,
    GameOver
}

public class TurnSystem : MonoBehaviour
{
    private TurnState currentTurn = TurnState.PlayerTurn;

    public TurnState CurrentTurn => currentTurn;

    public void StartPlayerTurn()
    {
        currentTurn = TurnState.PlayerTurn;
    }

    public void StartEnemyTurn()
    {
        currentTurn = TurnState.EnemyTurn;
    }

    public void EndGame()
    {
        currentTurn = TurnState.GameOver;
    }

    public bool IsPlayerTurn()
    {
        return currentTurn == TurnState.PlayerTurn;
    }

    public bool IsEnemyTurn()
    {
        return currentTurn == TurnState.EnemyTurn;
    }
}
