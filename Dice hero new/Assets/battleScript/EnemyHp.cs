using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    public GameObject prfHpBar;
    public GameObject canvas;
    public Text ScriptTxt;
    Image nowHpbar;
    RectTransform hpBar;
    public Text attack;
    public Text enemyName;


    private void Start()
    {
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();

        nowHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();

        
    }

    private void Update()
    {
        float nowHp = Data.enemy_hp; 
        float maxHp = Data.enemy_maxhp; //�� �ִ�ü�� �޾ƿͼ� �ֱ�
        float att = Data.enemy_att;
        attack.text = "ATT: "+ att.ToString();//�� ���ݷ� �޾ƿͼ� �ֱ�
        enemyName.text = Data.enemy_name;

        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
        ScriptTxt.text = "(" + nowHp.ToString() + "/" + maxHp.ToString() + ")";
    }
}