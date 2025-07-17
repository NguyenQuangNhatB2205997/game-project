using UnityEngine;

public class WeaponProjectileBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData; // reference to the weapon data scriptable object

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
}
