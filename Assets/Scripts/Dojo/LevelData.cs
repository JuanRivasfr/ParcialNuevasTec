using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Code Fighters/Level Data")]
public class LevelData : ScriptableObject
{
    public string levelName;
    public string levelDescription;
    public int levelID;
    public int requiredXP;
    public int rewardXP;
    public Sprite levelIcon;
    public string sceneToLoad;
}
