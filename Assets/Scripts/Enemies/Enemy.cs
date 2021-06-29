using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public float range;
    public int damage;
    public float moveSpeed;
    private bool canAttack;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(hp <= 0)
        {
            Destroy(this);
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
}
