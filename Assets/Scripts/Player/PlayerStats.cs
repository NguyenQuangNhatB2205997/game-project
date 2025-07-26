using UnityEngine;
using UnityEngine.UI;

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

    [Header("UI Elements")]
    public Image healthBar; // Reference to the health bar UI element

    void Awake()
    {
        // Initialize player stats from the character data
        currentHealth = characterData.MaxHealth;
        currentMoveSpeed = characterData.MoveSpeed;
        // currentAttack = characterData.Attack;
        // currentDefense = characterData.Defense;
    }

    void Start()
    {
        // Initialize health bar UI
        UpdateHealthBar();
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
            UpdateHealthBar(); // Update the health bar UI after taking damage
        }
    }

    void UpdateHealthBar()
    {
        // update the health bar UI
        healthBar.fillAmount = currentHealth / characterData.MaxHealth; // Update health bar fill amount
    }

    public void KillPlayer()
    {
        if (!GameManager.instance.isGameOver)
        {
            GameManager.instance.GameOver();
            Debug.Log("Player has been defeated!");
        }
    }
}
