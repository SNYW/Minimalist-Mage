using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSetManager : MonoBehaviour
{
    public SpellSlot[] spellSlots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Spell GetSpell(int i)
    {
        return spellSlots[i].spell;
    }
    public SpellSlot GetSpellSlot(int i)
    {
        return spellSlots[i];
    }
}
