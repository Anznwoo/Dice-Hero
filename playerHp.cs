using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHp : MonoBehaviour
{
    public GameObject prfHpBar;
    public GameObject canvas;
    public Text ScriptTxt;
    Image nowHpbar;
    RectTransform hpBar;



    private void Start()
    {
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();
        
        nowHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();
    }

    private void Update()
    {
        float nowHp = Data.Health;
        float maxHp = Data.MaxHealth;

        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
        ScriptTxt.text = "("+nowHp.ToString()+"/"+maxHp.ToString()+")";
    }
}
