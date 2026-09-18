using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fadeCanvas;
    [SerializeField] private Transform destinyPosition;
    [SerializeField] private GameObject interactText;
    private bool isPlayerInRange = false;

    private Rigidbody2D rb;
    private Animator fadeAnimator;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        fadeAnimator = fadeCanvas.GetComponent<Animator>();

        if (interactText != null)
            interactText.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactText.activeSelf && isPlayerInRange)
        {
            EnterDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactText != null)
        {
            interactText.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactText != null)
        {
            interactText.SetActive(false);
            isPlayerInRange = false;
        }

    }

    public void EnterDoor()
    {
        StartCoroutine(TeleportPlayer());
    }


    private IEnumerator TeleportPlayer()
    {
        fadeAnimator.SetTrigger("FadeIn");

        yield return new WaitForSeconds(2f);

        Teleport(destinyPosition.position);

        fadeAnimator.SetTrigger("FadeOut");
    }

    private void Teleport(Vector2 position)
    {
        rb.position = position;
        rb.linearVelocity = Vector2.zero;
    }
}