using UnityEngine;
using UnityEngine.UI;

public class Spell : ScriptableObject
{
    public new string name;
    public int damage;
    public Sprite uiSprite;

    public virtual void Cast() { }
}
