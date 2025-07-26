using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public CharacterScriptableObject characterData; // reference to the character data scriptable object
    float currentHealth; // current health of the player

    float currentMoveSpeed; // current movement speed of the player

    // float currentAttack; // current attack of the player
    // float currentDefense; // current defense of the player

    // create i-frames to prevent instant death
    [Header("Invincibility Frames")]
    public float iFrameDuration; // Duration of invincibility frames
    float iFrameTimer;
    bool isInvincible;

    void Awake()
    {
        // Initialize player stats from the character data
        currentHealth = characterData.MaxHealth;
        currentMoveSpeed = characterData.MoveSpeed;
        // currentAttack = characterData.Attack;
        // currentDefense = characterData.Defense;
    }

    void Update()
    {
        // Update invincibility frame timer
        if (iFrameTimer > 0)
        {
            iFrameTimer -= Time.deltaTime;
        }
        // if iframe timer is out, reset invincibility state
        else if (isInvincible)
        {
            isInvincible = false; // Reset invincibility state when timer runs out
        }
    }

    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;

            iFrameTimer = iFrameDuration; // Reset iFrame timer
            isInvincible = true;

            if (currentHealth <= 0)
            {
                KillPlayer(); // Call KillPlayer if health drops to zero or below
            }
        }

    }
    public void KillPlayer()
    {
        Debug.Log("Player is dead.");
    }
}
