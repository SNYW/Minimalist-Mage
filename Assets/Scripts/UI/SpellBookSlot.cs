using UnityEngine;
using UnityEngine.UI;

public class SpellBookSlot : MonoBehaviour
{
    public Image sprite;
    public Spell spell;

    public void SetSpell(Spell s)
    {
        sprite.sprite = s.uiSprite;
        spell = s;
    }

    public void SelectInSpellbook()
    {
        GameManager.gm.spellset.spellBookWindow.GetComponent<SpellBook>().SelectSpell(spell);
    }
}
