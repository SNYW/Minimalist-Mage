using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public bool playing;
    public float attackX;
    [HideInInspector]
    public Spell activeSpell;
    [HideInInspector]
    public List<GameObject> activeEnemies;
    public int gameLevel;
    public float levelSpeed;
    private float gameLevelIncrement;

    //UI
    public CombatText combatText;
    public Animator fadeInPanel;
    public TMP_Text levelText;
    public GameObject DeathPanel;

    //Managers
    [HideInInspector]
    public TimelineManager timelineManager;
    [HideInInspector]
    public SpellSetManager spellset;
    [HideInInspector]
    public SpawnManager spawnManager;
    [HideInInspector]
    public EconomyManager economy;
    [HideInInspector]
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
        if (playing)
        {
            gameLevelIncrement += Time.deltaTime * levelSpeed;
            gameLevel = (int)gameLevelIncrement;

            if (GetClosestEnemy() != null)
            {
                timelineManager.ManageTimeline();
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

    public void EndGame()
    {
        DeathPanel.SetActive(true);
        playing = false;
        levelText.text = gameLevel.ToString();
        Time.timeScale = 0;
    }

    public void ResetGame()
    {
        gameLevel = 0;
        foreach(GameObject g in activeEnemies) { Destroy(g); }
        activeEnemies = new List<GameObject>();
        economy.currentMoney = 0;
        spellset.ResetSpellbook();
        Mage.mage.ResetMage();
        DeathPanel.SetActive(false);
        playing = true;
        Time.timeScale = 1;
        fadeInPanel.Play("MainMenuFadeIn");
    }
}
