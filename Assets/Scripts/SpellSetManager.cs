using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSetManager : MonoBehaviour
{
    public SpellSlot[] spellSlots;
    public SpellSetList spellSetList;
    public SpellSet activeSpellSet;
    public int currentSetIndex;

    private void Awake()
    {
        currentSetIndex = 0;
        SetActiveSpellSet(currentSetIndex);
    }

    public Spell GetSpell(int i)
    {
        return spellSlots[i].spell;
    }
    public SpellSlot GetSpellSlot(int i)
    {
        return spellSlots[i];
    }
    public void SetActiveSpellSet(int index)
    {
        activeSpellSet.spells = new Spell[5];
        var i = 0;
        foreach (Spell sp in spellSetList.spellSets[index].spells)
        {
            activeSpellSet.spells[i] = sp;
            spellSlots[i].spell = sp;
            spellSlots[i].spellIcon.sprite = sp.uiSprite;
            i++;
        }
    }

    public void IncrementSpellSlot()
    {
        if(currentSetIndex == spellSetList.spellSets.Length-1)
        {
            currentSetIndex = 0;
            SetActiveSpellSet(0);
        }
        else
        {
            currentSetIndex++;
            SetActiveSpellSet(currentSetIndex);
        }
    }
    public void DecrementSpellSlot()
    {
        if (currentSetIndex == 0)
        {
            currentSetIndex = spellSetList.spellSets.Length-1;
            SetActiveSpellSet(currentSetIndex);
        }
        else
        {
            currentSetIndex--;
            SetActiveSpellSet(currentSetIndex);
        }
    }

}
