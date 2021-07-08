using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebuffSlot : MonoBehaviour
{
    public Debuff debuff;
    public Image icon;
    public TMP_Text amountText;
    private int remainingDuration;
    private int stacks;
    public GameObject target;
    private DebuffManager dm;

    public void SetDebuff(Debuff d, GameObject t, DebuffManager dm)
    {
        debuff = d;
        icon.sprite = d.icon;
        target = t;
        debuff.OnApply(t);
        this.dm = dm;
        if (d.stackable)
        {
            stacks++;
            amountText.text = stacks.ToString();
        }
        else
        {
            remainingDuration = d.duration;
            amountText.text = remainingDuration.ToString();
        }
    }

    public void Tick()
    {
        if (debuff.stackable)
        {
            stacks--;
            if (stacks <= 0)
            {
                Remove();
            }
            amountText.text = stacks.ToString();
        }
        else
        {
            remainingDuration -= 1;
            if (remainingDuration <= 0)
            {
                Remove();
            }
            amountText.text = remainingDuration.ToString();
        }

        debuff.Tick(target, stacks);
    }

    private void Remove()
    {
        dm.activeSlots.Remove(this);
        dm.debuffs.Remove(debuff);
        debuff.OnExpire(target);
        Destroy(gameObject);
    }

    public void AddStacks(int i)
    {
        stacks += i;
    }

    public void Refresh()
    {
        remainingDuration = debuff.duration;
        amountText.text = remainingDuration.ToString();
    }
}
