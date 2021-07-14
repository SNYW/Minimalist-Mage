using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mage : MonoBehaviour
{
    public static Mage mage;

    //Stats
    public int maxHp;
    public int hp;
    public int maxShield;
    public int shield;
    public int damage;
    public float moveSpeed;
    private bool canAttack;

    //UI
    public Image healthBar;
    public Image shieldBar;
    public TMP_Text healthText;
    public TMP_Text shieldText;
    public GameObject combatTextObj;
    public Transform combatTextAnchor;

    //Managers
    private Animator animator;
    private CombatTextManager combatText;

    //Spell Casting
    public Transform projectileCastAnchor;


    private void Awake()
    {
        if(mage == null)
        {
            mage = this;
        }
        else
        {
            Destroy(this);
        }
        combatText = GetComponent<CombatTextManager>();
        animator = GetComponent<Animator>();
        hp = maxHp;
        shield = maxShield;
        UpdateBars();
    }

    private void Update()
    {
        shieldBar.enabled = shield > 0;
        shieldText.enabled = shield > 0;
    }

    public void PlayAttackAnim()
    {
        animator.Play("MageAttack");
    }

    public void TakeDamage(int damage)
    {
        if (hp - damage <= 0 && shield <= 0)
        {
            hp = 0;
            UpdateBars();
            Die();
        }
        else
        {
            if (shield - damage <= 0)
            {
                var hpdamage = damage-shield;
                shield = 0;
                hp -= hpdamage;
            }
            else
            {
                shield -= damage;
            }
        }
        CreateCombatText(damage.ToString());
        UpdateBars();
    }

    private void UpdateBars()
    {
        healthBar.fillAmount = (float)hp / maxHp;
        healthText.text = hp + "/" + maxHp;
        shieldBar.fillAmount = (float)shield / maxShield;
        shieldText.text = shield + "/" + maxShield;
    }

    public void CreateCombatText(string text)
    {
        var textObj = Instantiate(combatTextObj, combatTextAnchor.position, Quaternion.identity).GetComponent<CombatText>();
        textObj.transform.parent = combatTextAnchor;
        textObj.CreateCombatTextRequest(text, 0.5f, true);
        combatText.AddTextRequest(textObj);
    }

    public void ResetMage()
    {
        hp = maxHp;
        shield = maxShield;
        UpdateBars();
    }

    private void Die()
    {
        GameManager.gm.EndGame();
    }
}
