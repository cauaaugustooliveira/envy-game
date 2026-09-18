using UnityEngine;

using System.Collections;
using UnityEngine;

public class BeakoTrapTrigger : MonoBehaviour
{
    public MonologueTrigger trigger;
    public NPCDialogue npcDialogue;
    public GameObject light;
    public GameObject trap;
    

    [SerializeField] private float timeToTrigger = 3f;

    private bool hasTriggered = false;
    private Coroutine triggerCoroutine;


    private void Start()
    {
        light.SetActive(false);
    }

    private void Update()
    {
        if (npcDialogue != null && npcDialogue.dialogueFinished && trap.activeSelf)
        {
            trap.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            triggerCoroutine = StartCoroutine(WaitToTrigger());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            if (triggerCoroutine != null)
            {
                StopCoroutine(triggerCoroutine);
                triggerCoroutine = null;
            }
        }
    }

    private IEnumerator WaitToTrigger()
    {
        yield return new WaitForSeconds(timeToTrigger);

        trigger.PlayMonologue();
        light.SetActive(true);

        hasTriggered = true;
        triggerCoroutine = null;
    }
}
