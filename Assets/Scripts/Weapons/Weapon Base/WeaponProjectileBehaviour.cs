using UnityEngine;

public class WeaponProjectileBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData; // reference to the weapon data scriptable object

    protected Vector3 direction; // direction of the projectile
    public float destroyAfterSeconds; // time after which the projectile will be destroyed

    // current stats
    protected float currentDamage; // current damage of the projectile
    protected float currentSpeed; // current speed of the projectile
    protected float currentCooldownDuration; // current cooldown duration of the projectile
    protected int currentPierce; // current pierce of the projectile

    void Awake()
    {
        // Initialize current stats from weaponData
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds); // destroy the projectile after a certain time
    }

    // will be used later
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;


        // direction components
        float dirX = direction.x;
        float dirY = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (dirX < 0 && dirY == 0) //left
        {
            scale.x *= -1; 
            scale.y *= -1; 
        }
        else if (dirX > 0 && dirY == 0) //right
        {
        }
        else if (dirX == 0 && dirY < 0) //down
        {
            scale.y *= -1; 
        }
        else if (dirX == 0 && dirY > 0) //up
        {
            scale.x *= -1; 
        }
        else if (dirX > 0 && dirY > 0) //right up
        {
            rotation.z = 0f;
        }
        else if (dirX > 0 && dirY < 0) //right down
        {
            rotation.z = -90f;
        }
        else if (dirX < 0 && dirY > 0) //left up
        {
            scale.x *= -1;
            scale.y *= -1; 
            rotation.z = -90f;
        }
        else if (dirX < 0 && dirY < 0) //left down
        {
            scale.x *= -1;
            scale.y *= -1; 
            rotation.z = 0f;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation); // cannot convert Vector3 to Quaternion directly, so we use Euler angles
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
        // Check if the projectile collides with an enemy
        EnemyStats enemy = collision.GetComponent<EnemyStats>();

        // make sure to use currentDamage instead of weaponData.Damage in case any damage multipliers in the future
        enemy.TakeDamage(currentDamage); 
        ReducePierce(); // reduce the pierce of the projectile
        }
    }

    void ReducePierce()
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            Destroy(gameObject); // destroy the projectile if it has no pierce left
        }
    }

}
