using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffManager : MonoBehaviour
{
    public float tickTime;
    private float currentTickTime;
    public HashSet<Debuff> debuffs;
    public List<DebuffSlot> activeSlots;
    public GameObject slotObject;

    private void Start()
    {
        debuffs = new HashSet<Debuff>();
        activeSlots = new List<DebuffSlot>();
        currentTickTime = tickTime;
    }
    private void Update()
    {
        ManageTicks();
    }

    public void AddDebuff(Debuff g, GameObject target)
    {
        if (!debuffs.Contains(g))
        {
            debuffs.Add(g);
            var ds = Instantiate(slotObject, transform).GetComponent<DebuffSlot>();
            ds.SetDebuff(g, target, this);
            activeSlots.Add(ds);
        }
    }

    public bool HasDebuff(Debuff g)
    {
        return debuffs.Contains(g);
    }

    private void ManageTicks()
    {
        currentTickTime -= Time.deltaTime;
        {
            if(currentTickTime <= 0)
            {
                foreach(DebuffSlot ds in activeSlots)
                {
                    ds.Tick();
                }
                currentTickTime = tickTime;
            }
        }
    }
}
