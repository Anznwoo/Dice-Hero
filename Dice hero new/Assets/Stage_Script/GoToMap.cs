using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToMap : MonoBehaviour
{
    public void GoToScene()
    {
        //Data.CurrentTile--;
        SceneManager.LoadScene("Mainmap"+Data.CurrentStage);
    }

    public void GoToTuto()
    {
        //Data.CurrentTile--;
        SceneManager.LoadScene("Tuto");
    }

    public void GoToMain()
    {
        //Data.CurrentTile--;
        Data.dice_result1 = 0;
        Data.dice_result2 = 0;
        Data.dice_result3 = 0;
        Data.dice_result4 = 0;
        Data.CurrentStage = 1; //현 스테이지
        Data.stage = 0; //저장용 스테이지
        Data.CurrentTile = 1; //현 타일
        Data.tileList = new List<int>(); //현 스테이지 타일 정보
        Data.Health = 10; // 현 체력
        Data.MaxHealth = 10; //최대 체력
        Data.Gold = 0; // 현 골드
        Data.Level = 1; // 현 레벨
        Data.enemy_name = ""; //적 이름
        Data.enemy_maxhp = 0; //적 최대 체력
        Data.enemy_hp = 0; //적 체력
        Data.enemy_att = 0; //적 공격력
        Data.combatTime = 0; // 전투 횟수
        Data.dice_number = 2; // 주사위 갯수
        Data.dice_category = new string[] { "hero", "priest", "0", "0" };// 갖고 있는 주사위 종류
        Data.AddAttack = 0; // 추가공격력
        Data.AddDefence = 0.0f; // 추가 방어력
        Data.Critical = 0.0f; //치명타
        Data.Evasion = 0.0f; // 회피율
        Data.Stun = 0.0f; // 스턴률
        Data.Equip = 0; // 착용한 아이템
        Data.Inventory = new List<int>(20); // 소지 아이템
        dicemove.StartWaypoint = 0;

        SceneManager.LoadScene("Mainmenu");
    }
}
