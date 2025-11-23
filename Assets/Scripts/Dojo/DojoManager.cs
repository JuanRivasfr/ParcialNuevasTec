using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public enum LevelState
{
    LOCKED,
    AVAILABLE,
    COMPLETED
}

public class DojoManager : MonoBehaviour
{
    [Header("Level Data")]
    [SerializeField] private LevelData[] allLevels;

    [Header("UI References")]
    [SerializeField] private Transform levelNodesContainer;
    [SerializeField] private GameObject levelNodePrefab;
    [SerializeField] private Button backToMenuButton;
    [SerializeField] private Button tutorialButton;
    [SerializeField] private TextMeshProUGUI missionsCompletedText;
    [SerializeField] private TextMeshProUGUI totalXPText;

    private Dictionary<int, LevelState> levelStates = new Dictionary<int, LevelState>();
    private int totalXP = 0;
    private int completedMissions = 0;

    private void Start()
    {
        LoadLevelStates();
        InitializeUI();
        CreateLevelNodes();
        UpdateUI();
    }

    private void InitializeUI()
    {
        if (backToMenuButton != null)
        {
            backToMenuButton.onClick.AddListener(OnBackToMenu);
        }

        if (tutorialButton != null)
        {
            tutorialButton.onClick.AddListener(OnTutorialClicked);
        }
    }

    private void LoadLevelStates()
    {
        // Load from PlayerPrefs
        totalXP = PlayerPrefs.GetInt("TotalXP", 0);
        completedMissions = PlayerPrefs.GetInt("CompletedMissions", 0);

        if (allLevels == null) return;

        foreach (LevelData level in allLevels)
        {
            string key = $"Level_{level.levelID}_State";
            int stateInt = PlayerPrefs.GetInt(key, 0);
            LevelState state = (LevelState)stateInt;

            // First level is always available
            if (level.levelID == 0)
            {
                state = LevelState.AVAILABLE;
            }
            // Check if level is available based on XP
            else if (state == LevelState.LOCKED && totalXP >= level.requiredXP)
            {
                state = LevelState.AVAILABLE;
            }

            levelStates[level.levelID] = state;
        }
    }

    private void CreateLevelNodes()
    {
        if (levelNodesContainer == null || levelNodePrefab == null || allLevels == null) return;

        // Clear existing nodes
        foreach (Transform child in levelNodesContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (LevelData level in allLevels)
        {
            GameObject nodeObj = Instantiate(levelNodePrefab, levelNodesContainer);
            LevelNodeUI nodeUI = nodeObj.GetComponent<LevelNodeUI>();
            
            if (nodeUI != null)
            {
                LevelState state = levelStates.ContainsKey(level.levelID) 
                    ? levelStates[level.levelID] 
                    : LevelState.LOCKED;
                
                nodeUI.Initialize(level, state, this);
            }
        }
    }

    public void OnLevelSelected(LevelData level)
    {
        if (level == null) return;

        LevelState state = levelStates.ContainsKey(level.levelID) 
            ? levelStates[level.levelID] 
            : LevelState.LOCKED;

        if (state == LevelState.LOCKED)
        {
            Debug.Log($"Level {level.levelName} is locked!");
            return;
        }

        // Load battle scene
        SceneRouter.Instance?.LoadBattleScene(level.levelID);
    }

    public void CompleteLevel(int levelID)
    {
        if (!levelStates.ContainsKey(levelID)) return;

        levelStates[levelID] = LevelState.COMPLETED;
        PlayerPrefs.SetInt($"Level_{levelID}_State", (int)LevelState.COMPLETED);

        // Update XP and missions
        LevelData level = System.Array.Find(allLevels, l => l.levelID == levelID);
        if (level != null)
        {
            totalXP += level.rewardXP;
            completedMissions++;
            PlayerPrefs.SetInt("TotalXP", totalXP);
            PlayerPrefs.SetInt("CompletedMissions", completedMissions);
        }

        // Unlock next level
        UnlockNextLevel(levelID);

        UpdateUI();
        CreateLevelNodes(); // Refresh nodes
    }

    private void UnlockNextLevel(int completedLevelID)
    {
        int nextLevelID = completedLevelID + 1;
        if (levelStates.ContainsKey(nextLevelID) && levelStates[nextLevelID] == LevelState.LOCKED)
        {
            LevelData nextLevel = System.Array.Find(allLevels, l => l.levelID == nextLevelID);
            if (nextLevel != null && totalXP >= nextLevel.requiredXP)
            {
                levelStates[nextLevelID] = LevelState.AVAILABLE;
                PlayerPrefs.SetInt($"Level_{nextLevelID}_State", (int)LevelState.AVAILABLE);
            }
        }
    }

    private void UpdateUI()
    {
        if (missionsCompletedText != null)
        {
            missionsCompletedText.text = $"Misiones Completadas: {completedMissions}/{allLevels?.Length ?? 0}";
        }

        if (totalXPText != null)
        {
            totalXPText.text = $"XP Total: {totalXP}";
        }
    }

    private void OnBackToMenu()
    {
        SceneRouter.Instance?.LoadMainMenu();
    }

    private void OnTutorialClicked()
    {
        SceneRouter.Instance?.LoadTrainingProtocol();
    }
}
