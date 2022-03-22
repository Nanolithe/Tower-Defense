using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Economy : MonoBehaviour
{
    public static int Money;
    public int beginMoney = 250;

    void Start()
    {
        Money = beginMoney;
    }


}
