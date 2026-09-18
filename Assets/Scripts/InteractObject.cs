using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;

    private void Start()
    {
        if (objectToActivate != null)
            objectToActivate.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && objectToActivate != null)
        {
            objectToActivate.SetActive(false);
        }

    }

}
