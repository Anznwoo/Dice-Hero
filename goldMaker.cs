using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goldMaker : MonoBehaviour
{
    public Text gold;

    private void Update()
    {
        gold.text = ": " + Data.Gold.ToString();
    }
}
