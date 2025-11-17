using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRouter : MonoBehaviour
{
    public static SceneRouter Instance { get; private set; }

    [Header("Scene Names")]
    [SerializeField] private string mainMenuScene = "MainMenu";
    [SerializeField] private string introNarrativaScene = "IntroNarrativa";
    [SerializeField] private string ciberDojoScene = "CiberDojo";
    [SerializeField] private string trainingProtocolScene = "TrainingProtocol";
    [SerializeField] private string battleScene = "BattleScene";
    [SerializeField] private string victoryScreenScene = "VictoryScreen";
    [SerializeField] private string gameOverScreenScene = "GameOverScreen";
    [SerializeField] private string settingsScene = "Settings";

    private BattleResult currentBattleResult;
    private int currentLevelID = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Main Menu Navigation
    public void LoadMainMenu()
    {
        LoadScene(mainMenuScene);
    }

    // Intro Narrative
    public void LoadIntroNarrativa()
    {
        LoadScene(introNarrativaScene);
    }

    // CiberDojo
    public void LoadCiberDojo()
    {
        LoadScene(ciberDojoScene);
    }

    // Training Protocol
    public void LoadTrainingProtocol()
    {
        LoadScene(trainingProtocolScene);
    }

    // Battle Scene
    public void LoadBattleScene(int levelID)
    {
        currentLevelID = levelID;
        LoadScene(battleScene);
    }

    // Victory Screen
    public void LoadVictoryScreen()
    {
        LoadScene(victoryScreenScene);
    }

    // Game Over Screen
    public void LoadGameOverScreen()
    {
        LoadScene(gameOverScreenScene);
    }

    // Settings
    public void LoadSettings()
    {
        LoadScene(settingsScene);
    }

    // Battle Result Management
    public void SetBattleResult(BattleResult result)
    {
        currentBattleResult = result;
    }

    public BattleResult GetBattleResult()
    {
        return currentBattleResult;
    }

    public int GetCurrentLevelID()
    {
        return currentLevelID;
    }

    // Generic scene loading
    private void LoadScene(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("Scene name is null or empty!");
            return;
        }

        SceneManager.LoadScene(sceneName);
    }

    // Game Loop: MainMenu → IntroNarrativa → CiberDojo → TrainingProtocol → BattleScene → VictoryScreen/GameOverScreen → CiberDojo
    public void StartNewGame()
    {
        LoadIntroNarrativa();
    }

    public void ContinueFromNarrative()
    {
        LoadCiberDojo();
    }

    public void ReturnToDojoAfterBattle()
    {
        LoadCiberDojo();
    }
}
