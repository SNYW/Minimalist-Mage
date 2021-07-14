using UnityEngine;
using UnityEngine.UI;

public class Spell : ScriptableObject
{
    public new string name;
    public string description;
    public int damage;
    public Sprite uiSprite;
    public int cost;

    public virtual void Cast() { }


}
