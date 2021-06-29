using UnityEngine;
using UnityEngine.UI;

public class TimelineManager : MonoBehaviour
{
    public GameObject[] timeline;

    public float incrementDelay;
    private float currentIncrementDelay;

    public int timelineIndex;

    private void Awake()
    {
        timelineIndex = 0;
        currentIncrementDelay = incrementDelay;
    }

    public void IncrementTimeline()
    {
        for (int i = 0; i < timeline.Length; i++)
        {
            timeline[i].GetComponent<Image>().enabled = false;
        }

        if (timelineIndex < timeline.Length - 1)
        {
            timelineIndex++;
        }
        else
        {
            timelineIndex = 0;
        }

        timeline[timelineIndex].GetComponent<Image>().enabled = true;
    }

    public void ManageTimeline()
    {
        currentIncrementDelay -= Time.deltaTime;
        if (currentIncrementDelay <= 0)
        {
            GameManager.gm.activeSpell.Cast();
            Mage.mage.PlayAttackAnim();
            IncrementTimeline();
            currentIncrementDelay = incrementDelay;
        }
    }
}
