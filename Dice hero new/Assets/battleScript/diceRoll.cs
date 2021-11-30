using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class diceRoll : MonoBehaviour
{
    public Text textbar;
    public Text exptext;
    public Text level;
    public GameObject prfexpBar;
    public GameObject canvas;
    Image nowexpbar;
    RectTransform expBar;
    public static int dice_result = 1;
    public Sprite[] sprites = new Sprite[dice_result];
    bool stunTrue;
    private SpriteRenderer spriteRenderer;
    int maxDice = 6;
    static bool alreadyDice = true;
    Ray ray;
    RaycastHit hit;
    int dice_time=1;
    playerHp playerhp = new playerHp();
    SpriteRenderer sr;
    SpriteRenderer herosr;
    SpriteRenderer priestsr;
    SpriteRenderer archorsr;
    SpriteRenderer roguesr;
    SpriteRenderer paladinsr;
    SpriteRenderer fightersr;
    private static GameObject sound;
    private static GameObject BGM;
    

    private void Start()
    {
        expBar = Instantiate(prfexpBar, canvas.transform).GetComponent<RectTransform>();
        nowexpbar = expBar.transform.GetChild(0).GetComponent<Image>();
        stunTrue = false;
        StartCoroutine(firstTextbar());
        sr = GameObject.Find("enemy").GetComponent<SpriteRenderer>();
        herosr = GameObject.Find("hero").GetComponent<SpriteRenderer>();
        priestsr = GameObject.Find("priest").GetComponent<SpriteRenderer>();
        archorsr = GameObject.Find("archor").GetComponent<SpriteRenderer>();
        roguesr = GameObject.Find("rogue").GetComponent<SpriteRenderer>();
        paladinsr = GameObject.Find("paladin").GetComponent<SpriteRenderer>();
        fightersr = GameObject.Find("fighter").GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        float nowexp = Data.xp;
        float maxexp = levelupArr[Data.Level-1];
        exptext.text = "("+nowexp+"/"+maxexp+")";
        level.text = "Level: " + Data.Level;
        nowexpbar.fillAmount =(float)nowexp / (float)maxexp;
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit)&&!alreadyDice)
            {
                if (hit.transform.gameObject.name ==this.name) {
                    sound = GameObject.Find("Effect");
                    BGM = GameObject.Find("BGM");
                    StartCoroutine(Diceroll());
                    
                }
            }   
        }
    }
    IEnumerator Diceroll()
    {
        alreadyDice = true;
        int dice_time = 0;
        int dice_graphic = 0;
        int pre_dice_gra = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        sound.GetComponent<CombatEffect>().EffectPlay("pick");
        int dice_result = UnityEngine.Random.Range(1, maxDice + 1);
        while (dice_time < maxDice)
        {
            dice_graphic = UnityEngine.Random.Range(0, maxDice);
            if (dice_graphic == pre_dice_gra)
            {
                while (dice_graphic != pre_dice_gra)
                {
                    dice_graphic = UnityEngine.Random.Range(0, maxDice);

                }
            }
            pre_dice_gra = dice_graphic;
            spriteRenderer.sprite = sprites[dice_graphic];
            ++dice_time;
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log(dice_result.ToString());
        int dice_gra = dice_result - 1;
        spriteRenderer.sprite = sprites[dice_gra];
        this.dice_time = dice_result;
        sound.GetComponent<CombatEffect>().EffectPlay(this.gameObject.name);
        int damage;//----------------------------------------------------------------------------------(우리팀 공격)
        Debug.Log("다이스 눈:"+this.dice_time.ToString());
        if (percentage(Data.Critical)) //궁수 치명타 집어 넣기
        {
            textbar.text = "궁수의 효과로 적에게 치명타를 입힌다!";
            yield return new WaitForSeconds(2f);
            sound.GetComponent<CombatEffect>().EffectPlay("damage");
            //궁수의 효과로 적에게 치명타를 입힌다. 메세지박스
            damage = (this.dice_time+Data.AddAttack) * 2;//치명타뜨면 몇프로 올라갈지는 2와 교체
        }
        else
        {
            damage = this.dice_time+Data.AddAttack;
            textbar.text = "아군의 턴";
            yield return new WaitForSeconds(1f);
            sound.GetComponent<CombatEffect>().EffectPlay("damage");
            //우리팀의 공격 메세지 박스
        }
        if (Data.enemy_hp - damage <= 0)
        {
            Data.enemy_hp = 0;
        }
        else
        {
            Data.enemy_hp -= damage;
            if (percentage(Data.Stun))
            {
                textbar.text = "격투가에 의해 적이 기절했다!";
                yield return new WaitForSeconds(2f);
                //격투가에 의해 적이 스턴당했다. 메세지박스
                stunTrue = true;
            }
        }//-----------------------------------------------------------------------------------------------
        if (Data.enemy_hp == 0)
        {
            Data.combatTime++;
            Debug.Log("함수 실행됨");
            BGM.GetComponent<CombatBGM>().BGMStop();
            sound.GetComponent<CombatEffect>().EffectPlay("damage");
            yield return new WaitForSeconds(0.6f);
            sound.GetComponent<CombatEffect>().EffectPlay("win");
            stunTrue = false;
            yield return new WaitForSeconds(1f);
            //승리했다.
            textbar.text = "전투에서 승리했다!";
            StartCoroutine(FadeCouroutine());
            int expe = exp();
            yield return new WaitForSeconds(2f);
            //몇 골드와 몇 경험치를 획득했다.
            textbar.text = "보상으로 10골드와"+expe.ToString() +"xp를 획득했다.";
            Data.Gold += 10;
            Data.xp += expe;
            yield return new WaitForSeconds(2f);
            if (levelupDis())
            {
                Data.xp -= levelupArr[Data.Level-1];
                Data.Level += 1;
                textbar.text = "레벨업!"+ System.Environment.NewLine + Data.Level.ToString() + "레벨이 되었다.";
                
                yield return new WaitForSeconds(2f);
                Data.AddAttack += 2;
                Data.MaxHealth += 2;
                Data.Health = Data.MaxHealth;
                textbar.text = "레벨업의 효과로 추가 공격력과 최대체력이 2씩 늘어난다.";
                yield return new WaitForSeconds(2f);
            }
            
            if (Data.combatTime == 6||Data.combatTime==12)
            {
                SceneManager.LoadScene("NewDiceSelect");
                yield break;
            }
            if (Data.CurrentTile==27)//마지막 타일로 바꾸기
            {
                if (Data.CurrentStage == 7)
                {
                    //게임 클리어 메세지
                }
                else
                {
                    Data.CurrentStage++;
                    Data.CurrentTile = 0;
                    dicemove.StartWaypoint = 0;
                    SceneManager.LoadScene("Mainmap" + Data.CurrentStage);
                    
                }
            }
            else
            {
                SceneManager.LoadScene("Mainmap" + Data.CurrentStage);
            }
            yield break;
        }
        yield return new WaitForSeconds(1f);
        if (stunTrue)
        {
            //스턴을 당해 움직이지 못한다. 메세지박스
            textbar.text = "적이 기절해서 움직이지 못했다!";
            yield return new WaitForSeconds(2f);
            stunTrue = false;
        }
        else if (percentage(Data.Evasion)&&(Data.dice_category[2]=="paladin"||Data.dice_category[3]=="paladin"))
        {
            textbar.text = "성기사가 적의 공격을 막았다!";
            yield return new WaitForSeconds(2f);
            //성기사가 적의 공격을 막았다. 메세지박스
        }
        else if (percentage(Data.Evasion) && (Data.dice_category[2] == "rogue" || Data.dice_category[3] == "rogue"))
        {
            textbar.text = "도적의 효과로 적의 공격을 회피했다!";
            yield return new WaitForSeconds(2f);
            //적의 공격을 회피했다. 메세지박스
        }
        else
        {
            textbar.text = "적의 턴";
            //적의 공격 메세지박스
            sound.GetComponent<CombatEffect>().EffectPlay("enemy");
            yield return new WaitForSeconds(1f);
            sound.GetComponent<CombatEffect>().EffectPlay("damage");
            if (Data.Health < Data.enemy_att)
            {
                Data.Health = 0;
            }
            else
            {
                Data.Health -= Data.enemy_att;
            }
            
        }
        if (Data.Health == 0)
        {
            alreadyDice = true;
            //패배했다...
            textbar.text = "전투에서 패배했다...";
            //게임오버 띄우기
            StartCoroutine(FadeCouroutine());
            
        }
        else
        {
            textbar.text = "어느 주사위로 공격할까?";
            spriteRenderer.sprite = sprites[6];
            alreadyDice = false;
        }
        
    }
    void ourHitting()
    {
        Data.enemy_hp = functions.heroAtt(dice_time, Data.enemy_hp);
    }
    void enemyHitting()
    {
        Data.Health = functions.monsterAtt(Data.Health, Data.enemy_att);
    }
    IEnumerator FadeCouroutine()
    {
        float fadeCount=0;
        if (Data.enemy_hp == 0)
        {
            while (fadeCount < 1.0f)
            {
                fadeCount += 0.01f;
                if (fadeCount > 1)
                {
                    fadeCount = 1;
                }
                yield return new WaitForSeconds(0.015f);
                sr.color = new Color(1, 1, 1, 1 - fadeCount);
            }
        }
        else if (Data.Health == 0)
        {
            while (fadeCount < 1.0f)
            {
                fadeCount += 0.01f;
                if (fadeCount > 1)
                {
                    fadeCount = 1;
                }
                yield return new WaitForSeconds(0.015f);
                herosr.color = new Color(1, 1, 1, 1 - fadeCount);
                priestsr.color = new Color(1, 1, 1, 1 - fadeCount);
                archorsr.color = new Color(1, 1, 1, 1 - fadeCount);
                roguesr.color = new Color(1, 1, 1, 1 - fadeCount);
                paladinsr.color = new Color(1, 1, 1, 1 - fadeCount);
                fightersr.color = new Color(1, 1, 1, 1 - fadeCount);
            }
            SceneManager.LoadScene("GameOver");
        }
    }
    IEnumerator firstTextbar()
    {
        yield return new WaitForSeconds(0.01f);
        textbar.text = Data.enemy_name + " 이(가) 나타났다!";
        yield return new WaitForSeconds(2f);
        textbar.text = "어느 주사위로 공격할까?";
        alreadyDice = false;
    }
    public bool percentage(float percent) //확률 함수
    {
        float randomNumber = Random.Range(0f, 100f);
        if (randomNumber < percent)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    int[] levelupArr = new int[] { 10, 25, 45, 125, 340, 950, 2000, 3500, 6000 };
    public bool levelupDis()
    {
        if (Data.Level == 1 && Data.xp >= 10)
        {
        }
        else if (Data.Level == 2 && Data.xp >= 25)
        {
        }
        else if (Data.Level == 3 && Data.xp >= 45)
        {
        }
        else if (Data.Level == 4 && Data.xp >= 125)
        {
        }
        else if (Data.Level == 5 && Data.xp >= 340)
        {
        }
        else if (Data.Level == 6 && Data.xp >= 950)
        {
        }
        else if (Data.Level == 7 && Data.xp >= 2000)
        {
        }
        else if (Data.Level == 8 && Data.xp >= 3500)
        {
        }
        else if (Data.Level == 9 && Data.xp >= 6000)
        {
        }
        else
        {
            return false;
        }
        return true;
    }
    public int exp()
    {
        int standard = pow(3, Data.CurrentStage+1)+5;
        if (Data.CurrentTile != 27)
        {
            int expValue = Random.Range(standard - (standard % 5), standard);
            return expValue;
        }
        else
        {
            int expValue = Random.Range(standard, standard+(standard%2));
            return expValue;
        }
    }
    public int pow(int x,int y)
    {
        if (y==1)
        {
            return x;
        }
        else if (y % 2 == 1)
        {
            return pow(x, y - 1)*x;
        }
        else if (y % 2 == 0)
        {
            return pow(x, y / 2) * pow(x, y / 2);
        }
        else
        {
            return 1;
        }
        
    }
}
