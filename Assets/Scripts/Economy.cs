using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Economy : MonoBehaviour
{
    public static int Money;
    public int beginMoney = 250;
    public static int Lives;
    public int beginLives = 2;

    void Awake()
    {
        Money = beginMoney;
        Lives = beginLives;
    }


}
