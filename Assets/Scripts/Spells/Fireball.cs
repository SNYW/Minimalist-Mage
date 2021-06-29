using UnityEngine;

[CreateAssetMenu]
public class Fireball : Spell
{
    public override void Cast()
    {
        Debug.Log("Cast: " + name+" for "+damage+" damage");
        GameManager.gm.GetClosestEnemy().hp -= damage;
    }
}
