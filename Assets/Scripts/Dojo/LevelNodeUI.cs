using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelNodeUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Image nodeIcon;
    [SerializeField] private Image lockIcon;
    [SerializeField] private Image checkmarkIcon;
    [SerializeField] private Button nodeButton;
    [SerializeField] private TextMeshProUGUI levelNameText;

    private LevelData levelData;
    private LevelState currentState;
    private DojoManager dojoManager;

    public void Initialize(LevelData level, LevelState state, DojoManager manager)
    {
        levelData = level;
        currentState = state;
        dojoManager = manager;

        UpdateVisuals();

        if (nodeButton != null)
        {
            nodeButton.onClick.RemoveAllListeners();
            nodeButton.onClick.AddListener(OnNodeClicked);
        }
    }

    private void UpdateVisuals()
    {
        if (levelData == null) return;

        // Set level name
        if (levelNameText != null)
        {
            levelNameText.text = levelData.levelName;
        }

        // Set icon
        if (nodeIcon != null && levelData.levelIcon != null)
        {
            nodeIcon.sprite = levelData.levelIcon;
        }

        // Update state visuals
        bool isLocked = currentState == LevelState.LOCKED;
        bool isCompleted = currentState == LevelState.COMPLETED;

        if (lockIcon != null)
        {
            lockIcon.gameObject.SetActive(isLocked);
        }

        if (checkmarkIcon != null)
        {
            checkmarkIcon.gameObject.SetActive(isCompleted);
        }

        if (nodeButton != null)
        {
            nodeButton.interactable = !isLocked;
        }

        // Change color based on state
        if (nodeIcon != null)
        {
            Color iconColor = isLocked ? Color.gray : (isCompleted ? Color.green : Color.white);
            nodeIcon.color = iconColor;
        }
    }

    private void OnNodeClicked()
    {
        if (dojoManager != null && levelData != null)
        {
            dojoManager.OnLevelSelected(levelData);
        }
    }
}
