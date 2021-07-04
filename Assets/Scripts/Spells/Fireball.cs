using UnityEngine;

[CreateAssetMenu(fileName = "Fireball", menuName = "Spells/Fireball")]
public class Fireball : Spell
{
    public override void Cast()
    {
        GameManager.gm.GetClosestEnemy().TakeDamage(damage);
    }
}
