using UnityEngine;

public class KnifeBehaviour : WeaponProjectileBehaviour
{

    // no longer need this val
    // KnifeController knifeController; // reference to the KnifeController


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        // knifeController = FindFirstObjectByType<KnifeController>(); // find the KnifeController in the scene
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * weaponData.Speed * Time.deltaTime; // move the knife in the specified direction
    }
}
