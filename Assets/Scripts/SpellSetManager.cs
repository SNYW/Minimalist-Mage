using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSetManager : MonoBehaviour
{
    public SpellSlot[] spellSlots;
    public SpellSetList spellSetList;
    public SpellSet activeSpellSet;

    private void Awake()
    {
        SetActiveSpellSet(spellSetList.spellSets[0]);
    }

    public Spell GetSpell(int i)
    {
        return spellSlots[i].spell;
    }
    public SpellSlot GetSpellSlot(int i)
    {
        return spellSlots[i];
    }
    public void SetActiveSpellSet(SpellSet s)
    {
        activeSpellSet.spells = new Spell[5];
        var i = 0;
        foreach (Spell sp in s.spells)
        {
            activeSpellSet.spells[i] = sp;
            spellSlots[i].spell = sp;
            spellSlots[i].spellIcon.sprite = sp.uiSprite;
            i++;
        }
    }

}
