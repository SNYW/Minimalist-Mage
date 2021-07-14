using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSpell", menuName = "Spells/ProjectileSpell")]
public class ProjectileSpell : Spell
{

    public GameObject projectile;

    public override void Cast()
    {
        Instantiate(projectile, Mage.mage.projectileCastAnchor.position, Quaternion.identity);
        //Setup projectile needed? perhaps the projectile just handles all its own behavior and the spell only 
        //cares about spawning it
    }
}
