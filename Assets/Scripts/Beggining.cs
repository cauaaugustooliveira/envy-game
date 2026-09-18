using System.Collections;
using UnityEngine;

public class Beggining : MonoBehaviour
{
    public MonologueTrigger trigger;
    public GameObject canvas;

    private void Awake()
    {
        canvas.SetActive(true);
    }

    private void Start()
    {
        trigger.PlayMonologue();
        
    }

    private IEnumerator StartMonologueWithDelay()
    {
        yield return new WaitForSeconds(1f);

        trigger.PlayMonologue();
    }
}