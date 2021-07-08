using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IcyRain", menuName = "Spells/IcyRain")]
public class IcyRain : Spell
{
    public Debuff debuff;
    public override void Cast()
    {
        var all = GameManager.gm.activeEnemies.ToArray();
        foreach (GameObject g in all)
        {
            if(g != null)
            {
                var enemy = g.GetComponent<Enemy>();
                enemy.debuffManager.AddDebuff(debuff,g.gameObject);
                enemy.TakeDamage(damage);
            }
        }
    }
}
