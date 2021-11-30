using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymaker : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[21];
    private SpriteRenderer spriteRenderer;
    public int hp;
    public int att;
    int a = 1;
    int graphic_number;        
    bool stunTrue = false;
    void enemyMake()
    {
        Debug.Log("실행 되는중");
        int randomNumber= UnityEngine.Random.Range(1, 3);
        Debug.Log(randomNumber);
        if (Data.CurrentStage == 1)
        {
            if(Data.CurrentTile==27)//보스일 때로 다시 설정하기
            {
                Mimic enemy = new Mimic();
                Data.enemy_name = "Mimic";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 0;
            }
            else if (randomNumber == 1)
            {
                Rat enemy = new Rat();
                Data.enemy_name = "Rat";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 1;
            }
            else if (randomNumber == 2)
            {
                Slime enemy = new Slime();
                Data.enemy_name = "Slime";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 2;
            }
        }
        else if (Data.CurrentStage == 2)
        {
            if (Data.CurrentTile == 27)//보스일 때로 다시 설정하기
            {
                Ogre enemy = new Ogre();
                Data.enemy_name = "Ogre";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 3;
            }
            else if (randomNumber == 1)
            {
                Orc enemy = new Orc();
                Data.enemy_name = "Orc";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 4;
            }
            else if (randomNumber == 2)
            {
                Bat enemy = new Bat();
                Data.enemy_name = "Bat";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 5;
            }
        }
        else if (Data.CurrentStage == 3)
        {
            if (Data.CurrentTile == 27)//보스일 때로 다시 설정하기
            {
                Behemoth enemy = new Behemoth();
                Data.enemy_name = "Behemoth";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 6;
            }
            else if (randomNumber == 1)
            {
                Plant enemy = new Plant();
                Data.enemy_name = "Plant";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 7;
            }
            else if (randomNumber == 2)
            {
                Hornet enemy = new Hornet();
                Data.enemy_name = "Hornet";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 8;
            }
        }
        else if (Data.CurrentStage == 4)
        {
            if (Data.CurrentTile == 27)//보스일 때로 다시 설정하기
            {
                Werewolf enemy = new Werewolf();
                Data.enemy_name = "Werewolf";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 9;
            }
            else if (randomNumber == 1)
            {
                Lamia enemy = new Lamia();
                Data.enemy_name = "Lamia";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 10;
            }
            else if (randomNumber == 2)
            {
                Snake enemy = new Snake();
                Data.enemy_name = "Snake";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 11;
            }
        }
        else if (Data.CurrentStage == 5)
        {
            if (Data.CurrentTile == 27)//보스일 때로 다시 설정하기
            {
                Dragon enemy = new Dragon();
                Data.enemy_name = "Dragon";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 12;
            }
            else if (randomNumber == 1)
            {
                Gargoyle enemy = new Gargoyle();
                Data.enemy_name = "Gargoyle";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 13;
            }
            else if (randomNumber == 2)
            {
                Imp enemy = new Imp();
                Data.enemy_name = "Imp";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 14;
            }
        }
        else if (Data.CurrentStage == 6)
        {
            if (Data.CurrentTile == 27)//보스일 때로 다시 설정하기
            {
                Evilking enemy = new Evilking();
                Data.enemy_name = "Evilking";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 15;
            }
            else if (randomNumber == 1)
            {
                Zombie enemy = new Zombie();
                Data.enemy_name = "Zombie";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 16;
            }
            else if (randomNumber == 2)
            {
                Skeleton enemy = new Skeleton();
                Data.enemy_name = "Skeleton";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 17;
            }
        }
        else if (Data.CurrentStage == 7)
        {
            if (Data.CurrentTile == 27)//보스일 때로 다시 설정하기
            {
                Darklord enemy = new Darklord();
                Data.enemy_name = "Darklord";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 18;
            }
            else if (randomNumber == 1)
            {
                Kerberos enemy = new Kerberos();
                Data.enemy_name = "Kerberos";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 19;
            }
            else if (randomNumber == 2)
            {
                Demon enemy = new Demon();
                Data.enemy_name = "Demon";
                this.hp = enemy.hp;
                this.att = enemy.att;
                graphic_number = 20;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyMake();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyMake();
        spriteRenderer.sprite = sprites[graphic_number];
        Data.enemy_maxhp = hp;
        Data.enemy_hp = hp;
        Data.enemy_att=att;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
