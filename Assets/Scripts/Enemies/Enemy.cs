using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int level;
    public int killGems;
    public GameObject gem;
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
                transform.Translate((Vector3)Vector2.left * moveSpeed * Time.deltaTime);
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
}
