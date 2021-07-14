using UnityEngine;

public class DebuffProjectile : Projectile
{
    public bool applyOnHit;
    public Debuff debuff;
    public bool continueIfApplied;

    protected override void OnHit(Enemy e)
    {
        if (!e.debuffManager.debuffs.Contains(debuff))
        {
            e.TakeDamage(damage);
            if (applyOnHit)
            {
                e.debuffManager.AddDebuff(debuff, e.gameObject);
            }
            Destroy(gameObject);
        }
        else
        {
            e.TakeDamage(damage);
            if (!continueIfApplied)
            {
                Destroy(gameObject);
            }
            
        }
        Destroy(gameObject, 3);
    }
}
