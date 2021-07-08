using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : ScriptableObject
{
    public new string name;
    public bool stackable;
    public int duration;
    public Sprite icon;

    public virtual void Tick(GameObject target, int stacks)
    {

    }

    public virtual void OnApply(GameObject target)
    {

    }

    public virtual void OnExpire(GameObject target)
    {

    }
}
