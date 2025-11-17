using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public string enemyName = "Bug";
    public int maxHealth = 100;
    public int currentHealth;
    public int difficulty = 1;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }
}
