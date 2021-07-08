using UnityEngine;

[CreateAssetMenu(fileName = "Slow", menuName = "Debuffs/Cold")]
public class Slow : Debuff
{
    float slowFactor;

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
