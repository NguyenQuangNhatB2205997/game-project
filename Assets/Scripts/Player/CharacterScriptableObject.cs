using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "Scriptable Objects/Character")]
public class CharacterScriptableObject : ScriptableObject
{

    [SerializeField]
    float maxHealth; // maximum health of the character
    public float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    [SerializeField]
    float moveSpeed; // movement speed of the character
    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
