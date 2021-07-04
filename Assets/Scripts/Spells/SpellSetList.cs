using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellSetList", menuName = "Spells/SpellSetList")]
public class SpellSetList : ScriptableObject
{
    public SpellSet[] spellSets;
}
