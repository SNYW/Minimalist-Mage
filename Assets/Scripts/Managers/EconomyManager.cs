using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyManager : MonoBehaviour
{
    public int startMoney;
    public int currentMoney;

    public TMP_Text moneyText;

    void Start()
    {
        currentMoney = startMoney;
        moneyText.text = currentMoney.ToString();
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        moneyText.text = currentMoney.ToString();
    }

    public bool Spend(int amount)
    {
        if(currentMoney - amount >= 0)
        {
            currentMoney -= amount;
            moneyText.text = currentMoney.ToString();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CanSpend(int amount)
    {
        return currentMoney - amount >= 0;
    }

}
