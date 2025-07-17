using UnityEngine;

public class WeaponProjectileBehaviour : MonoBehaviour
{

    protected Vector3 direction; // direction of the projectile
    public float destroyAfterSeconds; // time after which the projectile will be destroyed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds); // destroy the projectile after a certain time
    }

    // will be used later
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
    }
}
