using UnityEngine; // old input system namespace
using UnityEngine.InputSystem; // Import the new Input System namespace

public class NewMonoBehaviourScript : MonoBehaviour
{

    // movement variables
    public float moveSpeed;
    Rigidbody2D rb;
    [HideInInspector]
    public Vector2 movement;

    public float lastHorizontalVector;
    public float lastVerticalVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame, and it's frame rate dependent
    void Update()
    {
        InputManagement();
    }

    // FixedUpdate is frame rate independent
    void FixedUpdate()
    {
        Move();
    }

    // Handles player input and sets the movement vector, tell which buttons are pressed
    // if =0 means not pressed, =1 means pressed   
    void InputManagement()
    {
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");
        // movement = new Vector2(movement.x, movement.y).normalized;
        // this is old input system code

        movement = Vector2.zero;
        if (Keyboard.current.wKey.isPressed) movement.y += 1;
        if (Keyboard.current.sKey.isPressed) movement.y -= 1;
        if (Keyboard.current.aKey.isPressed) movement.x -= 1;
        if (Keyboard.current.dKey.isPressed) movement.x += 1;
        movement = movement.normalized;

        if (movement.x != 0)
        {
            // If there is horizontal movement, update the last horizontal vector
            lastHorizontalVector = movement.x;
        }
        else if (movement.y != 0)
        {
            // If there is vertical movement, update the last vertical vector
            lastVerticalVector = movement.y;
        }
        else if (movement.x != 0 && movement.y != 0)
        {
            // If there is both horizontal and vertical movement, update both vectors
            lastHorizontalVector = movement.x;
            lastVerticalVector = movement.y;
        }
        else
        {
            // If no movement, reset the last vectors
            lastHorizontalVector = 0;
            lastVerticalVector = 0;
        }
    }

    // Moves the player based on the movement vector and speed
    void Move()
    {
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }
}
