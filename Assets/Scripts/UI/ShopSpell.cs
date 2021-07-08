using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSpell : MonoBehaviour
{
    public TMP_Text costText;
    public Image icon;
    public Spell currentSpell;

    public void SetSpell(Spell s)
    {
        currentSpell = s;
        costText.text = s.cost.ToString();
        icon.sprite = s.uiSprite;
    }

    public void OpenShopPanel()
    {
        GameManager.gm.shop.OpenBuyPanel(currentSpell);
    }
}
