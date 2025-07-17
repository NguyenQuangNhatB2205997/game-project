using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "Scriptable Objects/Weapon")]

public class WeaponScriptableObject : ScriptableObject
{

    public GameObject weaponPrefab; // store the weapon prefab
    //base stats for the weapon
    public int damage; // damage dealt by the weapon
    public float speed; // attack speed
    public float cooldownDuration; // cooldown duration after an attack
    public int pierce; // maximum amount of times the weapon can hit enemies




}
