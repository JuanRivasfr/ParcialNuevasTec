using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrainingProtocolManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Transform skillCardsContainer;
    [SerializeField] private GameObject skillCardPrefab;
    [SerializeField] private Button startBattleButton;
    [SerializeField] private Button backButton;

    [Header("Skills")]
    [SerializeField] private SkillDefinition[] availableSkills;

    private void Start()
    {
        InitializeUI();
        CreateSkillCards();
    }

    private void InitializeUI()
    {
        if (startBattleButton != null)
        {
            startBattleButton.onClick.AddListener(OnStartBattle);
        }

        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBack);
        }
    }

    private void CreateSkillCards()
    {
        if (skillCardsContainer == null || skillCardPrefab == null || availableSkills == null) return;

        // Clear existing cards
        foreach (Transform child in skillCardsContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (SkillDefinition skill in availableSkills)
        {
            GameObject cardObj = Instantiate(skillCardPrefab, skillCardsContainer);
            SkillCardUI cardUI = cardObj.GetComponent<SkillCardUI>();
            
            if (cardUI != null)
            {
                cardUI.Initialize(skill);
            }
        }
    }

    private void OnStartBattle()
    {
        // Load first level for training
        SceneRouter.Instance?.LoadBattleScene(0);
    }

    private void OnBack()
    {
        SceneRouter.Instance?.LoadCiberDojo();
    }
}
