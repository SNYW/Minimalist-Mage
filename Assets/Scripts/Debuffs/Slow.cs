using UnityEngine;

[CreateAssetMenu(fileName = "TimedSlow", menuName = "Debuffs/Timed Slow")]
public class Slow : Debuff
{
    public float slowFactor;

    public override void OnApply(GameObject target)
    {
        var enemy = target.GetComponent<Enemy>();
        enemy.currentMoveSpeed = enemy.currentMoveSpeed*slowFactor;
    }

    public override void OnExpire(GameObject target)
    {
        var enemy = target.GetComponent<Enemy>();
        enemy.currentMoveSpeed = enemy.baseMoveSpeed;
    }

}
