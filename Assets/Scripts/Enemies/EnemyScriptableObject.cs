using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "Scriptable Objects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    // base stats for the enemies
    public float maxHealth;
    public float damage;
    public float moveSpeed;



}
