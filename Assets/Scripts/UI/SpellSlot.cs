using UnityEngine;
using UnityEngine.UI;

public class SpellSlot : MonoBehaviour
{
    public Spell spell;
    public Image spellIcon;

    private void Awake()
    {
        spellIcon.sprite = spell.uiSprite;
    }

    public void OpenSpellBook()
    {
        GameManager.gm.spellset.OpenSpellBook(this);
    }

    public void SetSpell(Spell s)
    {
        spell = s;
        spellIcon.sprite = s.uiSprite;
    }
}
