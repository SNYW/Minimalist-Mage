using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int level;
    public int killGems;
    public GameObject gem;
    public int baseHp;
    public int maxHp;
    public int hp;
    public float baseMoveSpeed;
    public float currentMoveSpeed;
    public float range;
    public int damage;

    //Level Scaling
    public float healthScaleFactor;
    public float moneyScaleFactor;

    //Management
    private bool canAttack;
    private Animator animator;
    public Image healthBar;
    public TMP_Text healthText;
    public TMP_Text levelText;
    public DebuffManager debuffManager;
    public GameObject combatTextObj;
    public Transform combatTextAnchor;
    public CombatTextManager ctm;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentMoveSpeed = baseMoveSpeed;
        hp = maxHp;
        healthBar.fillAmount = 1;
        levelText.text = level.ToString();
    }

    private void Update()
    {
        if (GameManager.gm.playing)
        {
            if (hp <= 0)
            {
                Die();
            }

            canAttack = CanAttack();
            animator.SetBool("attacking", canAttack);

            if (!canAttack)
            {
                transform.Translate((Vector3)Vector2.left * currentMoveSpeed * Time.deltaTime);
            }
        }
    }

    private bool CanAttack()
    {
        return Vector2.Distance(
            new Vector2(transform.position.x, Mage.mage.transform.position.y), 
            Mage.mage.transform.position) 
            <= range;
    }

    public void TakeDamage(int damage)
    {
        if(hp-damage <= 0)
        {
            Die();
        }
        else
        {
            hp -= damage;
        }
        healthBar.fillAmount = (float)hp / maxHp;
        healthText.text = hp + "/" + maxHp;
    }

    public virtual void Attack()
    {
        Mage.mage.TakeDamage(damage);
    }

    public void CreateCombatText(string text)
    {
        var textObj = Instantiate(combatTextObj, combatTextAnchor.position, Quaternion.identity).GetComponent<CombatText>();
        textObj.transform.parent = combatTextAnchor;
        textObj.CreateCombatTextRequest(text, 0.3f, true);
        ctm.AddTextRequest(textObj);
    }

    private void Die()
    {
        GameManager.gm.activeEnemies.Remove(gameObject);
        GameManager.gm.economy.AddMoney(killGems);

        for (int i = 0; i < killGems; i++)
        {
           var g =  Instantiate(gem, transform.position, Quaternion.identity);
            g.transform.eulerAngles = new Vector3(g.transform.eulerAngles.x,g.transform.eulerAngles.y , Random.Range(0, 360));
            var grb = g.GetComponent<Rigidbody2D>();
            grb.AddForce(g.transform.forward+Vector3.up*2 , ForceMode2D.Impulse);
            grb.AddTorque(Random.Range(0.1f,0.5f), ForceMode2D.Impulse);
        }
        Destroy(gameObject);
    }

    public void SetLevel(int i)
    {
        level = i;
        levelText.text = level.ToString();

        var healthBuff = baseHp + level * healthScaleFactor;
        maxHp += (int)healthBuff;
        hp = maxHp;
        healthText.text = hp + "/" + maxHp;


        var gemBuff = killGems + level * healthScaleFactor;
        killGems = (int)gemBuff;
    }
}
