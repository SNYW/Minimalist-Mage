using UnityEngine;

[CreateAssetMenu(fileName ="SpellSet", menuName = "Spells/SpellSet")]
public class SpellSet : ScriptableObject
{
    public Spell[] spells;
}
