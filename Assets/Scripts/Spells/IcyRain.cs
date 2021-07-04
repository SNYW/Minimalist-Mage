using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IcyRain", menuName = "Spells/IcyRain")]
public class IcyRain : Spell
{
    public override void Cast()
    {
        var all = GameManager.gm.activeEnemies.ToArray();
        foreach (GameObject g in all)
        {
            if(g != null)
            {
                g.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }
}
