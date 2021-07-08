using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Spell currentBuySpell;
    public List<Spell> availableSpells;
    public List<ShopSpell> shopSpellSlots;
    public TMP_Text rollCostText;

    public GameObject buyPanel;
    public TMP_Text buySpellName;
    public TMP_Text buySpellDesc;

    public int rerollCost;

    private void Start()
    {
        currentBuySpell = null;
        buyPanel.SetActive(false);
        InitialRoll();
    }

    public void RerollSpells()
    {
        if(GameManager.gm.economy.Spend(rerollCost))
        {
            foreach (ShopSpell s in shopSpellSlots)
            {
                s.SetSpell(availableSpells[Random.Range(0, availableSpells.Count)]);
            }

            if (rerollCost < 201) rerollCost++;
        }
        rollCostText.text = "-" + rerollCost.ToString();
    }

    private void InitialRoll()
    {
        GameManager.gm.economy.currentMoney -= rerollCost;
        foreach (ShopSpell s in shopSpellSlots)
        {
            s.SetSpell(availableSpells[Random.Range(0, availableSpells.Count)]);
        }

        rollCostText.text = "-" + rerollCost.ToString();
    }

    public void OpenBuyPanel(Spell s)
    {
        if (GameManager.gm.economy.CanSpend(s.cost))
        {
            buyPanel.SetActive(true);
            buySpellName.text = s.name;
            buySpellDesc.text = s.description;
            currentBuySpell = s;
        }
    }

    public void CloseBuyPanel()
    {
        buyPanel.SetActive(false);
        currentBuySpell = null;
    }

    public void BuySpell(Spell s)
    {
        if(currentBuySpell != null 
            && GameManager.gm.spellset.spellBook.Count <= 47
            && GameManager.gm.economy.Spend(s.cost))
        {
            GameManager.gm.spellset.AddToSpellbook(currentBuySpell);
            CloseBuyPanel();
        }
    }
}
