using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    public string playerName = "Zeven";
    public int maxHealth = 100;
    public int currentHealth;
    public int maxEnergy = 100;
    public int currentEnergy;

    [Header("Skills")]
    public SkillDefinition[] availableSkills;

    private void Start()
    {
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
    }

    public void UseEnergy(int amount)
    {
        currentEnergy = Mathf.Max(0, currentEnergy - amount);
    }

    public void RestoreEnergy(int amount)
    {
        currentEnergy = Mathf.Min(maxEnergy, currentEnergy + amount);
    }

    public bool CanUseSkill(SkillDefinition skill)
    {
        return currentEnergy >= skill.energyCost;
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }
}
