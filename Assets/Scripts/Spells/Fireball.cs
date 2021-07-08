using UnityEngine;

[CreateAssetMenu(fileName = "Fireball", menuName = "Spells/Fireball")]
public class Fireball : Spell
{
    public Debuff debuff;

    public override void Cast()
    {
        var target = GameManager.gm.GetClosestEnemy();
        target.TakeDamage(damage);
        target.debuffManager.AddDebuff(debuff, target.gameObject);
    }
}
