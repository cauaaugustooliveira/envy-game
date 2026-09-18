using UnityEngine;

public class NPCWander : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 1.5f;

    [Tooltip("Tempo que o NPC fica andando")]
    [SerializeField] private float moveTime = 2f;

    [Tooltip("Tempo que o NPC fica parado")]
    [SerializeField] private float idleTime = 3f;

    [Header("Obstacle Detection")]
    [SerializeField] private float obstacleCheckDistance = 0.6f;
    [SerializeField] private LayerMask obstacleLayer;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    private Rigidbody2D rb;

    private Vector2 moveDirection;
    private Vector2 lastDirection = Vector2.down;

    private float timer;
    private bool isMoving;
    private bool movementBlocked;

    public Vector2 MoveDirection => moveDirection;
    public bool IsMoving => isMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        StartIdle();
    }

    private void Update()
    {
        if (movementBlocked)
            return;

        timer -= Time.deltaTime;

        UpdateAnimation();

        if (timer <= 0)
        {
            if (isMoving)
                StartIdle();
            else
                StartMoving();
        }
    }

    private void FixedUpdate()
    {
        if (movementBlocked || !isMoving)
            return;

        RaycastHit2D hit = Physics2D.Raycast(
            rb.position,
            moveDirection,
            obstacleCheckDistance,
            obstacleLayer
        );

        if (hit.collider != null)
        {
            ChooseDirection();
            return;
        }

        rb.MovePosition(
            rb.position +
            moveDirection * moveSpeed * Time.fixedDeltaTime
        );
    }

    private void StartMoving()
    {
        isMoving = true;
        timer = moveTime;

        ChooseDirection();
    }

    private void StartIdle()
    {
        isMoving = false;
        timer = idleTime;

        moveDirection = Vector2.zero;

        UpdateAnimation();
    }

    private void ChooseDirection()
    {
        int direction = Random.Range(0, 4);

        switch (direction)
        {
            case 0:
                moveDirection = Vector2.up;
                break;

            case 1:
                moveDirection = Vector2.down;
                break;

            case 2:
                moveDirection = Vector2.left;
                break;

            case 3:
                moveDirection = Vector2.right;
                break;
        }

        lastDirection = moveDirection;
    }

    private void UpdateAnimation()
    {
        if (animator == null)
            return;

        animator.SetBool("IsMoving", isMoving);

        if (isMoving)
        {
            animator.SetFloat("MoveX", moveDirection.x);
            animator.SetFloat("MoveY", moveDirection.y);
        }
        else
        {
            animator.SetFloat("MoveX", lastDirection.x);
            animator.SetFloat("MoveY", lastDirection.y);
        }
    }

    public void SetMovementBlocked(bool blocked)
    {
        movementBlocked = blocked;

        if (blocked)
        {
            isMoving = false;
            moveDirection = Vector2.zero;

            rb.linearVelocity = Vector2.zero;

            if (animator != null)
                animator.SetBool("IsMoving", false);
        }
        else
        {
            // Quando o player sair da área,
            // o NPC espera novamente antes de andar.
            StartIdle();
        }
    }
}