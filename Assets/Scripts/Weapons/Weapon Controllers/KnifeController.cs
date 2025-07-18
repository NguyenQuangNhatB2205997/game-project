using UnityEngine;

public class KnifeController : WeaponController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start(); // Call the base class Start method
    }

    protected override void Attack()
    {
        base.Attack(); // Call the base class Attack method
        
        // spawn knives at the player's position
        GameObject spawnKnife = Instantiate(weaponData.WeaponPrefab);
        spawnKnife.transform.position = transform.position; // set the knife's position to the player's position
        spawnKnife.GetComponent<KnifeBehaviour>().DirectionChecker(playerMovement.lastMovedVector); // set the knife's direction
    }
}
