using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillCardUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Image skillIcon;
    [SerializeField] private TextMeshProUGUI skillNameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI powerLevelText;
    [SerializeField] private Button viewDetailsButton;

    private SkillDefinition skillData;

    public void Initialize(SkillDefinition skill)
    {
        skillData = skill;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (skillData == null) return;

        if (skillNameText != null)
        {
            skillNameText.text = skillData.skillName;
        }

        if (descriptionText != null)
        {
            descriptionText.text = skillData.description;
        }

        if (powerLevelText != null)
        {
            powerLevelText.text = $"Nivel de Poder: {skillData.powerLevel}";
        }

        if (skillIcon != null && skillData.skillIcon != null)
        {
            skillIcon.sprite = skillData.skillIcon;
        }

        if (viewDetailsButton != null)
        {
            viewDetailsButton.onClick.RemoveAllListeners();
            viewDetailsButton.onClick.AddListener(OnViewDetails);
        }
    }

    private void OnViewDetails()
    {
        // Show detailed skill information
        Debug.Log($"Viewing details for: {skillData.skillName}");
    }
}
