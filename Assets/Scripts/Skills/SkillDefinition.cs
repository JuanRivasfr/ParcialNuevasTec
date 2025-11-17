using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Code Fighters/Skill Definition")]
public class SkillDefinition : ScriptableObject
{
    public string skillName;
    public string description;
    public int powerLevel;
    public int energyCost;
    public Sprite skillIcon;
    public SkillType skillType;

    public enum SkillType
    {
        PrintAttack,
        LoopKick,
        FilterCutter,
        ElseCounter
    }
}
