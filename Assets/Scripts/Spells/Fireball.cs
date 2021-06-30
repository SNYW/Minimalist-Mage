using UnityEngine;

[CreateAssetMenu]
public class Fireball : Spell
{
    public override void Cast()
    {
        GameManager.gm.GetClosestEnemy().TakeDamage(damage);
    }
}
