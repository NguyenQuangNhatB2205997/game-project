using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "Scriptable Objects/Weapon")]

public class WeaponScriptableObject : ScriptableObject
{

    [SerializeField]
    GameObject weaponPrefab; // store the weapon prefab
    public GameObject WeaponPrefab
    {
        get => weaponPrefab;
        private set => weaponPrefab = value;
    }

    //base stats for the weapon
    [SerializeField]
    float damage; // damage dealt by the weapon
    public float Damage
    {
        get => damage;
        private set => damage = value;
    }

    [SerializeField]
    float speed; // speed of the weapon projectile
    public float Speed
    {
        get => speed;
        private set => speed = value;
    }

    [SerializeField]
    float cooldownDuration; // cooldown duration between shots
    public float CooldownDuration
    {
        get => cooldownDuration;
        private set => cooldownDuration = value;
    }

    [SerializeField]
    int pierce; // number of enemies the projectile can pierce through
    public int Pierce
    {
        get => pierce;
        private set => pierce = value;
    }

}
