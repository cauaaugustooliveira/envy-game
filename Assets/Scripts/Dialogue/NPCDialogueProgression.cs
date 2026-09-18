using UnityEngine;

public class NPCDialogueProgression : MonoBehaviour
{
    [SerializeField] private GameObject[] talks;

    private int currentTalkIndex = 0;

    private void Start()
    {
        UpdateTalks();
    }

    public void CompleteCurrentTalk()
    {
        if (currentTalkIndex >= talks.Length - 1)
            return;

        currentTalkIndex++;

        UpdateTalks();
    }

    private void UpdateTalks()
    {
        for (int i = 0; i < talks.Length; i++)
        {
            talks[i].SetActive(i == currentTalkIndex);
        }
    }
}