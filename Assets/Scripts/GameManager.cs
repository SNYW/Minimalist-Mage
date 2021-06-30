using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    private SpellSlot activeSpellSlot;
    public float attackX;
    public Spell activeSpell;
    public List<GameObject> activeEnemies;

    //Managers
    public TimelineManager timelineManager;
    public SpellSetManager spellset;
    public SpawnManager spawnManager;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(this);
        }

        timelineManager = GetComponent<TimelineManager>();
        spellset = GetComponent<SpellSetManager>();
        spawnManager = GetComponent<SpawnManager>();
        activeEnemies = new List<GameObject>();
    }

    private void Update()
    {
        spawnManager.ManageSpawn();

        if(GetClosestEnemy() != null)
        {
            timelineManager.ManageTimeline();
            activeSpellSlot = spellset.GetSpellSlot(timelineManager.timelineIndex);
            activeSpell = spellset.GetSpell(timelineManager.timelineIndex);
        }
    }
    public Enemy GetClosestEnemy()
    {
        if (activeEnemies.Count > 0)
        {
            if(CalcClosestEnemy().transform.position.x < attackX)
            {
                return CalcClosestEnemy();
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    private Enemy CalcClosestEnemy()
    {
        GameObject obj = activeEnemies[0];
        foreach(GameObject g in activeEnemies)
        {
            if(g.transform.position.x < obj.transform.position.x)
            {
                obj = g;
            }
        }
        return obj.GetComponent<Enemy>();
    }
}
