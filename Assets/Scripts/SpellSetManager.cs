using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSetManager : MonoBehaviour
{
    public SpellSlot[] spellSlots;
    public SpellSetList spellSetList;
    public SpellSet activeSpellSet;
    public GameObject spellBookSlot;
    public GameObject spellBookUI;
    public GameObject spellBookWindow;
    public List<Spell> spellBook;
    public int currentSetIndex;

    private void Awake()
    {
        spellBookWindow.SetActive(false);
        currentSetIndex = 0;
        SetActiveSpellSet(currentSetIndex);
        InitialiseSpellbook();
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
            spellSlots[i].SetSpell(sp);
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

    public void AddToSpellbook(Spell s)
    {
        if (!spellBook.Contains(s))
        {
            spellBook.Add(s);
            var sp = Instantiate(spellBookSlot, spellBookUI.transform);
            sp.GetComponent<SpellBookSlot>().SetSpell(s);
        }
    }

    public void RemoveFromSpellBook(Spell s)
    {
        foreach(SpellBookSlot g in spellBookUI.GetComponentsInChildren<SpellBookSlot>())
        {
            if(g.spell = s)
            {
                Destroy(g.gameObject);
                break;
            }
        }
        spellBook.Remove(s);
    }
    
    public void OpenSpellBook(SpellSlot s)
    {
        spellBookWindow.GetComponent<SpellBook>().activeSlot = s;
        spellBookWindow.SetActive(true);
    }
    
    public void CloseSpellBook()
    {
        spellBookWindow.GetComponent<SpellBook>().activeSlot = null;
        spellBookWindow.SetActive(false);
    }

    private void InitialiseSpellbook()
    {
        foreach (SpellSet ss in spellSetList.spellSets)
        {
            foreach (Spell sp in ss.spells)
            {
                AddToSpellbook(sp);
            }
        }
        
    }
}
