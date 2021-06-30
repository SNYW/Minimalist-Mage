using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHp;
    public int hp;
    public float range;
    public int damage;
    public float moveSpeed;
    private bool canAttack;
    private Animator animator;
    public Image healthBar;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        hp = maxHp;
        healthBar.fillAmount = 1;
    }

    private void Update()
    {
        if(hp <= 0)
        {
            Die();
        }

        canAttack = CanAttack();
        animator.SetBool("attacking", canAttack);

        if (!canAttack)
        {
            transform.Translate((Vector3)Vector2.left*moveSpeed*Time.deltaTime);
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
    }

    private void Die()
    {
        GameManager.gm.activeEnemies.Remove(gameObject);
        Destroy(gameObject);
    }
}
