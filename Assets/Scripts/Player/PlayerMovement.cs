using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;

    private Rigidbody2D rb;
    private Vector2 movement;

    public Vector2 Movement => movement;
    public Vector2 LastDirection { get; private set; } = Vector2.down;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        if (movement != Vector2.zero)
            LastDirection = movement;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }

    public void Teleport(Vector2 position)
    {
        rb.position = position;
        rb.linearVelocity = Vector2.zero;
    }
}