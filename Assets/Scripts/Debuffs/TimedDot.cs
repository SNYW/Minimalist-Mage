using UnityEngine;

[CreateAssetMenu(fileName = "TimedDoT", menuName = "Debuffs/Timed DoT")]
public class TimedDot : Debuff
{
    public bool percentDamage;
    public float damage;

    public override void Tick(GameObject target, int stacks)
    {
        var enemy = target.GetComponent<Enemy>();

        if (percentDamage)
        {
            float dam = enemy.maxHp * damage;
            if (dam < 1) dam = 1;
            enemy.TakeDamage((int)dam);
            enemy.CreateCombatText("burn! " + (int)dam);
        }
        else
        {
            enemy.TakeDamage((int)damage);
            enemy.CreateCombatText("burn! " + (int)damage);
        }
        
    }
}
