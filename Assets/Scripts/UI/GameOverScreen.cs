using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI errorTypeText;
    [SerializeField] private TextMeshProUGUI errorLineText;
    [SerializeField] private TextMeshProUGUI errorMessageText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button goToDojoButton;

    private BattleResult battleResult;

    private void Start()
    {
        InitializeButtons();
        LoadBattleResult();
        DisplayErrorInfo();
    }

    private void InitializeButtons()
    {
        if (retryButton != null)
        {
            retryButton.onClick.AddListener(OnRetry);
        }

        if (goToDojoButton != null)
        {
            goToDojoButton.onClick.AddListener(OnGoToDojo);
        }
    }

    private void LoadBattleResult()
    {
        battleResult = SceneRouter.Instance?.GetBattleResult();
        
        if (battleResult == null)
        {
            battleResult = new BattleResult
            {
                playerWon = false,
                levelID = 0,
                playerHealth = 0,
                timeElapsed = 30f
            };
        }
    }

    private void DisplayErrorInfo()
    {
        if (titleText != null)
        {
            titleText.text = "YOU WERE DEBUGGED!";
        }

        // Generate random error info for demonstration
        string[] errorTypes = { "SyntaxError", "TypeError", "LogicError", "RuntimeError" };
        string[] errorMessages = { 
            "Indentación incorrecta", 
            "Variable no definida", 
            "Lógica de código incorrecta",
            "División por cero"
        };

        string errorType = errorTypes[Random.Range(0, errorTypes.Length)];
        string errorMessage = errorMessages[Random.Range(0, errorMessages.Length)];
        int errorLine = Random.Range(1, 20);

        if (errorTypeText != null)
        {
            errorTypeText.text = $"Tipo de error: {errorType}";
        }

        if (errorLineText != null)
        {
            errorLineText.text = $"Línea: {errorLine}";
        }

        if (errorMessageText != null)
        {
            errorMessageText.text = $"Mensaje: {errorMessage}";
        }

        if (finalScoreText != null)
        {
            finalScoreText.text = "Puntuación final: 0";
        }
    }

    private void OnRetry()
    {
        if (battleResult != null)
        {
            SceneRouter.Instance?.LoadBattleScene(battleResult.levelID);
        }
    }

    private void OnGoToDojo()
    {
        SceneRouter.Instance?.LoadCiberDojo();
    }
}
