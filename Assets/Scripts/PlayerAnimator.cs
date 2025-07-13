using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // references
    Animator animator;

    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.movement.x != 0 || playerMovement.movement.y != 0)
        {
            animator.SetBool("Move", true);
            SpriteDirectionChecker();
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    void SpriteDirectionChecker()
    {
        // if x < 0, flip to right, if x > 0, flip to left
        if (playerMovement.lastHorizontalVector > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (playerMovement.lastHorizontalVector < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

}
