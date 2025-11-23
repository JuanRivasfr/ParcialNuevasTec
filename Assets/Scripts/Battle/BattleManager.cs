using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private HealthBar playerHealthBar;
    [SerializeField] private HealthBar enemyHealthBar;
    [SerializeField] private QuestionSystem questionSystem;
    [SerializeField] private TurnSystem turnSystem;
    [SerializeField] private Image energyBar;
    [SerializeField] private TextMeshProUGUI energyText;

    [Header("Battle Settings")]
    [SerializeField] private float turnDelay = 1f;

    private bool battleActive = false;
    private int battleLevelID = 0;

    private void Start()
    {
        InitializeBattle();
    }

    public void InitializeBattle()
    {
        if (player == null) player = FindObjectOfType<Player>();
        if (enemy == null) enemy = FindObjectOfType<Enemy>();
        if (turnSystem == null) turnSystem = GetComponent<TurnSystem>();

        if (player != null && playerHealthBar != null)
        {
            playerHealthBar.Initialize(player.playerName, player.maxHealth);
        }

        if (enemy != null && enemyHealthBar != null)
        {
            enemyHealthBar.Initialize(enemy.enemyName, enemy.maxHealth);
        }

        battleActive = true;
        turnSystem?.StartPlayerTurn();
        LoadNextQuestion();
    }

    public void SetBattleLevel(int levelID)
    {
        battleLevelID = levelID;
    }

    private void LoadNextQuestion()
    {
        if (questionSystem == null || !battleActive) return;

        Question question = questionSystem.GetRandomQuestion();
        if (question != null)
        {
            questionSystem.LoadQuestion(question, OnAnswerSelected);
        }
    }

    private void OnAnswerSelected(int answerIndex)
    {
        if (!battleActive || questionSystem == null) return;

        Question currentQuestion = questionSystem.GetRandomQuestion(); // Get current question
        if (currentQuestion == null) return;

        bool isCorrect = answerIndex == currentQuestion.correctAnswerIndex;

        if (isCorrect)
        {
            // Correct answer - deal damage to enemy
            int damage = currentQuestion.damageOnCorrect;
            enemy?.TakeDamage(damage);
            
            // Show damage popup
            if (enemy != null)
            {
                DamagePopup.Create(enemy.transform.position, damage, true);
            }

            UpdateEnemyHealth();
        }
        else
        {
            // Wrong answer - lose energy
            int energyCost = currentQuestion.energyCostOnWrong;
            player?.UseEnergy(energyCost);
            UpdatePlayerEnergy();
        }

        // Check win/lose conditions
        StartCoroutine(CheckBattleState());
    }

    private IEnumerator CheckBattleState()
    {
        yield return new WaitForSeconds(turnDelay);

        if (enemy != null && !enemy.IsAlive())
        {
            // Player wins
            EndBattle(true);
            yield break;
        }

        if (player != null && !player.IsAlive())
        {
            // Player loses
            EndBattle(false);
            yield break;
        }

        // Continue battle
        LoadNextQuestion();
    }

    private void UpdatePlayerHealth()
    {
        if (player != null && playerHealthBar != null)
        {
            playerHealthBar.UpdateHealth(player.currentHealth);
        }
    }

    private void UpdateEnemyHealth()
    {
        if (enemy != null && enemyHealthBar != null)
        {
            enemyHealthBar.UpdateHealth(enemy.currentHealth);
        }
    }

    private void UpdatePlayerEnergy()
    {
        if (player == null) return;

        if (energyBar != null)
        {
            energyBar.fillAmount = (float)player.currentEnergy / player.maxEnergy;
        }

        if (energyText != null)
        {
            energyText.text = $"{player.currentEnergy}/{player.maxEnergy}";
        }
    }

    private void EndBattle(bool playerWon)
    {
        battleActive = false;
        turnSystem?.EndGame();

        // Store battle results
        BattleResult result = new BattleResult
        {
            playerWon = playerWon,
            levelID = battleLevelID,
            playerHealth = player != null ? player.currentHealth : 0,
            timeElapsed = Time.time
        };

        SceneRouter.Instance?.SetBattleResult(result);

        // Load appropriate screen
        if (playerWon)
        {
            SceneRouter.Instance?.LoadVictoryScreen();
        }
        else
        {
            SceneRouter.Instance?.LoadGameOverScreen();
        }
    }

    private void Update()
    {
        if (battleActive)
        {
            UpdatePlayerHealth();
            UpdatePlayerEnergy();
        }
    }
}

[System.Serializable]
public class BattleResult
{
    public bool playerWon;
    public int levelID;
    public int playerHealth;
    public float timeElapsed;
}
