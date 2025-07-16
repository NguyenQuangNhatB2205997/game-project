using UnityEngine;

public class KnifeBehaviour : WeaponProjectileBehaviour
{

    KnifeController knifeController; // reference to the KnifeController


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        knifeController = FindObjectOfType<KnifeController>(); // find the KnifeController in the scene
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * knifeController.speed * Time.deltaTime; // move the knife in the specified direction
    }
}
