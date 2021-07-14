using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffProjectile : Projectile
{
    public Debuff debuff;

    protected override void OnHit(Enemy e)
    {
        
        if (!e.debuffManager.debuffs.Contains(debuff))
        {
            e.TakeDamage(damage);
            e.debuffManager.AddDebuff(debuff, e.gameObject);
            Destroy(gameObject);
        }
        else
        {
            e.TakeDamage(damage);
            damage -= damage / 2;
        }
        Destroy(gameObject, 3);
    }
}
