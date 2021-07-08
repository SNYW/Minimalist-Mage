using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    private SpellSlot activeSpellSlot;
    public bool playing;
    public float attackX;
    public Spell activeSpell;
    public List<GameObject> activeEnemies;
    public Animator fadeInPanel;
    public CombatText combatText;
    public int gameLevel;
    public float levelSpeed;
    private float gameLevelIncrement;

    //Managers
    public TimelineManager timelineManager;
    public SpellSetManager spellset;
    public SpawnManager spawnManager;
    public EconomyManager economy;
    public ShopManager shop;

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
        playing = false;
        fadeInPanel.Play("MainMenuFadeIn");
        timelineManager = GetComponent<TimelineManager>();
        spellset = GetComponent<SpellSetManager>();
        spawnManager = GetComponent<SpawnManager>();
        economy = GetComponent<EconomyManager>();
        activeEnemies = new List<GameObject>();
        shop = GetComponent<ShopManager>();
    }

    private void Update()
    {
        gameLevelIncrement += Time.deltaTime * levelSpeed;
        gameLevel = (int)gameLevelIncrement;

        if (playing)
        {
            if (GetClosestEnemy() != null)
            {
                timelineManager.ManageTimeline();
                activeSpellSlot = spellset.GetSpellSlot(timelineManager.timelineIndex);
                activeSpell = spellset.GetSpell(timelineManager.timelineIndex);
            }
            spawnManager.ManageSpawn();
        }
    }

    public List<GameObject> GetAllEnemies()
    {
        if (activeEnemies.Count > 0)
        {
            return activeEnemies.OrderBy(x => x.transform.position.x).ToList();
        }
        else
        {
            return null;
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

    public void StartRun()
    {
        playing = true;
    }
}
