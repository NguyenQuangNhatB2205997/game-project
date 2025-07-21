using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public EnemyScriptableObject enemyData;

    // current stats
    float currentHealth;
    float currentDamage;
    float currentMoveSpeed;

    void Awake()
    {
        // Initialize current stats from enemyData
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
        currentMoveSpeed = enemyData.MoveSpeed;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle enemy death (e.g., play animation, destroy object)
        Destroy(gameObject);
    }

}
