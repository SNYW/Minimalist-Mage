public class MultiHitProjectile : Projectile
{
    public int continueMax;
    public Debuff debuff;

    protected override void OnHit(Enemy e)
    {
        if(continueMax > 0)
        {
            e.TakeDamage(damage);
            if(debuff != null)
            {
                e.debuffManager.AddDebuff(debuff, e.gameObject);
            }
            continueMax--;
        }

        if (continueMax <= 0) Destroy(gameObject);
    }
}
