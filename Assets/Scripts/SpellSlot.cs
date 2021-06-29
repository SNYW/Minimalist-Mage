using System.Collections;
using System.Collections.Generic;
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
}
