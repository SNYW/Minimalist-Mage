using UnityEngine;

[CreateAssetMenu(fileName = "StackingDoT", menuName = "Debuffs/DoT")]
public class Burning : Debuff
{
    public override void Tick(GameObject target, int stacks)
    {
        var enemy = target.GetComponent<Enemy>();
        float damage = enemy.baseHp * 0.1f;
        if (damage < 1) damage = 1;
        enemy.TakeDamage((int)damage);
    }
}
