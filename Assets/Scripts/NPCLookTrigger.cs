using UnityEngine;

public class NPCLookTrigger : MonoBehaviour
{
    private Animator animator;
    private Transform npc;
    private Transform player;

    private NPCWander npcWander;

    private void Awake()
    {
        npc = transform.parent;

        animator = GetComponentInParent<Animator>();
        npcWander = GetComponentInParent<NPCWander>();
    }

    private void Update()
    {
        if (player == null)
            return;

        Vector2 direction = player.position - npc.position;

        animator.SetBool("IsMoving", false);

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            animator.SetFloat("MoveX", direction.x > 0 ? 1 : -1);
            animator.SetFloat("MoveY", 0);
        }
        else
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction.y > 0 ? 1 : -1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;

            npcWander.SetMovementBlocked(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;

            npcWander.SetMovementBlocked(false);
        }
    }
}