using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DebuffSpell", menuName = "Spells/DebuffSpell")]
public class DebuffSpell : Spell
{
    public Debuff debuff;
    public int maxTargets;

    public override void Cast()
    {
        var targets = GameManager.gm.GetAllEnemies();

        if(maxTargets > targets.Count)
        {
            foreach(GameObject g in targets)
            {
                var target = g.GetComponent<Enemy>();
                DealDamage(target);
            }
        }
        else
        {
            for (int i = 0; i < maxTargets; i++)
            {
                var target = targets[i].GetComponent<Enemy>();
                DealDamage(target);
            }
        }
    }

    public void DealDamage(Enemy target)
    {
        target.TakeDamage(damage);
        target.debuffManager.AddDebuff(debuff, target.gameObject);
        target.CreateCombatText(damage.ToString());
    }
}
