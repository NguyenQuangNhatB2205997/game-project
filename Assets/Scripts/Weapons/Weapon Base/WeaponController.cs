using UnityEngine;

// Base class for weapon controllers

public class WeaponController : MonoBehaviour
{

    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData; // reference to the weapon data scriptable object

    // public GameObject weaponPrefab; // store the weapon prefab
    // public int damage; // damage dealt by the weapon
    // public float speed; // attack speed
    // public float cooldownDuration; // cooldown duration after an attack
    // public int pierce; // maximum amount of times the weapon can hit enemies

    float currentCooldown; // current cooldown time

    protected PlayerMovement playerMovement; // reference to the PlayerMovement script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>(); // find the PlayerMovement script in the scene

        // if the player has a weapon, he can't attack right away
        currentCooldown = weaponData.CooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime; // decrease the cooldown time
        if (currentCooldown <= 0)
        {
            Attack(); // if the cooldown is over, allow the player to attack
        }
    }

    // Implement attack logic here
    protected virtual void Attack()
    {
        currentCooldown = weaponData.CooldownDuration; // reset cooldown after attack
    }
}
