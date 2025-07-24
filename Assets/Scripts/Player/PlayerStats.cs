using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public CharacterScriptableObject characterData; // reference to the character data scriptable object
    public float currentHealth; // current health of the player

    public float currentMoveSpeed; // current movement speed of the player

    // public float currentAttack; // current attack of the player
    // public float currentDefense; // current defense of the player

    void Awake()
    {
        // Initialize player stats from the character data
        currentHealth = characterData.MaxHealth;
        currentMoveSpeed = characterData.MoveSpeed;
        // currentAttack = characterData.Attack;
        // currentDefense = characterData.Defense;
    }
}
