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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();

            //use currentDamage instead of weaponData.Damage in case of damage multipliers in the future 
            player.TakeDamage(currentDamage);
        }
    }


}
