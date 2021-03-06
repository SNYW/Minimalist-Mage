using UnityEngine;
using UnityEngine.UI;

public class SpellSlot : MonoBehaviour
{
    public Spell spell;
    public Image spellIcon;

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
