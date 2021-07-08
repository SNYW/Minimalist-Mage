using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public void BuySpell()
    {
        ShopManager shop = GameManager.gm.shop;
        if (shop.currentBuySpell != null)
        {
            shop.BuySpell(GameManager.gm.shop.currentBuySpell);
        }
    }
}
