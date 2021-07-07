using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    public SpellSlot activeSlot;
    public Spell spellbookSelection;

    public TMP_Text spellName;
    public TMP_Text spellDesc;
    public GameObject equipButton;

    private void Awake()
    {
        SelectSpell(null);
    }

    public void OpenSpellBook(SpellSlot sp)
    {
        activeSlot = sp;
    }

    public void ApplySelection()
    {
        if(activeSlot != null && spellbookSelection != null)
        {
            activeSlot.SetSpell(spellbookSelection);
        }
        SelectSpell(null);
        gameObject.SetActive(false);
    }

    public void SelectSpell(Spell s)
    {
        if(s != null)
        {
            spellbookSelection = s;
            spellName.text = s.name;
            spellDesc.text = s.description;
            equipButton.SetActive(true);
        }
        else
        {
            spellbookSelection = null;
            spellName.text = "Select a spell";
            spellDesc.text = "for it's description";
            equipButton.SetActive(false);
        }
    }

}
