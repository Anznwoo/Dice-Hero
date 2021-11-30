using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shelter : MonoBehaviour
{
    public GameObject menuSet;
    public Text text;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void yes()
    {
        if (Data.Gold >= 30)
        {
            Data.Health = Data.MaxHealth;
            Data.Gold -= 30;
            GameObject.Find("Canvas").transform.Find("bg_hpbar").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("bg_hpbar(Clone)").gameObject.SetActive(true);
            Data.diceStop = true;
            menuSet.SetActive(false);
        }
        else
        {
            text.text = "소지금이 부족합니다";
        }
    }
    public void no()
    {
        GameObject.Find("Canvas").transform.Find("bg_hpbar").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("bg_hpbar(Clone)").gameObject.SetActive(true);
        Data.diceStop = true;
        menuSet.SetActive(false);
        
    }
}
