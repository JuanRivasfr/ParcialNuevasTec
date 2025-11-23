using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VictoryScreen : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI correctAnswersText;
    [SerializeField] private TextMeshProUGUI xpGainedText;
    [SerializeField] private TextMeshProUGUI levelReachedText;
    [SerializeField] private Button backToDojoButton;
    [SerializeField] private Button repeatBattleButton;
    [SerializeField] private Button continueStoryButton;

    private BattleResult battleResult;

    private void Start()
    {
        InitializeButtons();
        LoadBattleResult();
        DisplayStats();
    }

    private void InitializeButtons()
    {
        if (backToDojoButton != null)
        {
            backToDojoButton.onClick.AddListener(OnBackToDojo);
        }

        if (repeatBattleButton != null)
        {
            repeatBattleButton.onClick.AddListener(OnRepeatBattle);
        }

        if (continueStoryButton != null)
        {
            continueStoryButton.onClick.AddListener(OnContinueStory);
        }
    }

    private void LoadBattleResult()
    {
        battleResult = SceneRouter.Instance?.GetBattleResult();
        
        if (battleResult == null)
        {
            // Default values for testing
            battleResult = new BattleResult
            {
                playerWon = true,
                levelID = 0,
                playerHealth = 100,
                timeElapsed = 60f
            };
        }
    }

    private void DisplayStats()
    {
        if (titleText != null)
        {
            titleText.text = "¡VICTORIA!";
        }

        if (timeText != null && battleResult != null)
        {
            int minutes = Mathf.FloorToInt(battleResult.timeElapsed / 60f);
            int seconds = Mathf.FloorToInt(battleResult.timeElapsed % 60f);
            timeText.text = $"Tiempo: {minutes:00}:{seconds:00}";
        }

        // Calculate XP gained (example: based on level and time)
        int xpGained = CalculateXPGained();
        if (xpGainedText != null)
        {
            xpGainedText.text = $"XP Ganada: +{xpGained}";
        }

        if (levelReachedText != null)
        {
            levelReachedText.text = $"Nivel: {battleResult.levelID + 1}";
        }

        // Correct answers would need to be tracked in BattleManager
        if (correctAnswersText != null)
        {
            correctAnswersText.text = "Respuestas Correctas: N/A"; // TODO: Track this
        }
    }

    private int CalculateXPGained()
    {
        // Base XP calculation
        int baseXP = 100 + (battleResult.levelID * 50);
        return baseXP;
    }

    private void OnBackToDojo()
    {
        SceneRouter.Instance?.LoadCiberDojo();
    }

    private void OnRepeatBattle()
    {
        if (battleResult != null)
        {
            SceneRouter.Instance?.LoadBattleScene(battleResult.levelID);
        }
    }

    private void OnContinueStory()
    {
        // Load next narrative or continue to next level
        SceneRouter.Instance?.LoadIntroNarrativa();
    }
}
