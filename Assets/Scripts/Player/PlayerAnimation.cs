using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement movement;

    private Vector2 lastDirection = Vector2.down;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        Vector2 direction = movement.Movement;

        bool isMoving = direction != Vector2.zero;

        animator.SetBool("IsMoving", isMoving);

        if (!isMoving)
        {
            animator.SetFloat("MoveX", lastDirection.x);
            animator.SetFloat("MoveY", lastDirection.y);
            return;
        }

        // Como temos apenas 4 direções,
        // escolhemos o eixo predominante.
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            lastDirection = direction.x > 0
                ? Vector2.right
                : Vector2.left;
        }
        else
        {
            lastDirection = direction.y > 0
                ? Vector2.up
                : Vector2.down;
        }

        animator.SetFloat("MoveX", lastDirection.x);
        animator.SetFloat("MoveY", lastDirection.y);
    }
}