using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyUI : MonoBehaviour
{
    public Text beginMoneyText;
    // Update is called once per frame
    void Update()
    {
        beginMoneyText.text = "$" + Economy.Money.ToString();
    }
}
