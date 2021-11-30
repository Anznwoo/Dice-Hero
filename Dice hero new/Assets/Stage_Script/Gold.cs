using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Data;

public class Gold : MonoBehaviour
{
    public static Gold gold;
    Text GoldCount;

    private void Start()
    {
        gold = this;
        GoldCount = GetComponent<Text>();
        //GoldCount.text = DataManager.MyStateList[0].money.ToString();
    }

    public void RefreshMoney()
    {
        //GoldCount.text = DataManager.MyStateList[0].money.ToString();
    }

    public void Earn(int money)
    {
        /*int temp_money = DataManager.MyStateList[0].money;
        temp_money+= money;
        DataManager.MyStateList[0].money = temp_money;*/
    }
}
