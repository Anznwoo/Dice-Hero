using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{

    public static int dice_result1 = 0;
    public static int dice_result2 = 0;
    public static int dice_result3 = 0;
    public static int dice_result4 = 0;
    public static int CurrentStage = 1; //현 스테이지
    public static int stage = 0; //저장용 스테이지
    public static int CurrentTile = 1; //현 타일
    public static List<int> tileList = new List<int>(); //현 스테이지 타일 정보
    public static int Health = 10; // 현 체력
    public static int MaxHealth = 10; //최대 체력
    public static int Gold = 0; // 현 골드
    public static int xp = 0; //현 경험치
    public static int Level = 1; // 현 레벨
    public static string enemy_name = ""; //적 이름
    public static int enemy_maxhp = 0; //적 최대 체력
    public static int enemy_hp = 0; //적 체력
    public static int enemy_att = 0; //적 공격력
    public static int combatTime = 0; // 전투 횟수
    public static bool diceStop = true; //여관에서 주사위 멈추게 하는거
    public static int dice_number = 2; // 주사위 갯수
    public static string[] dice_category = new string[] { "hero", "priest", "0", "0" };// 갖고 있는 주사위 종류
    public static int AddAttack = 0; // 추가공격력
    public static float AddDefence = 0.0f; // 추가 방어력
    public static float Critical = 0.0f; //치명타
    public static float Evasion = 0.0f; // 회피율
    public static float Stun = 0.0f; // 스턴률
    public static int Equip = 0; // 착용한 아이템
    public static List<int> Inventory = new List<int>(20); // 소지 아이템

    /*
    주사위 눈 - dice_result(4개주사위를 다 담게 변경) - 4개 주사위를 다 따로따로 해놓음
    현 스테이지 - CurrentStage
    현 타일 - CurrentTile
    체력 - Health
    최대체력 - MaxHealth
    골드 - Gold
    레벨 - Level
    주사위 갯수 - dice_number
    주사위 종류 - dice_category
    추가공격력 - AddAttack
    추가방어력 - AddDefence
    회피율 - Evasion
    기절률 - Stun
    착용중인 아이템 - Equip
    인벤토리 (소지중 아이템) - Inventory
    */


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void GameRestart()
    {
        int dice_result1 = 0;
        int dice_result2 = 0;
        int dice_result3 = 0;
        int dice_result4 = 0;
        int CurrentStage = 1; //현 스테이지
        int stage = 0; //저장용 스테이지
        int CurrentTile = 1; //현 타일
        List<int> tileList = new List<int>(); //현 스테이지 타일 정보
        int Health = 10; // 현 체력
        int MaxHealth = 10; //최대 체력
        int Gold = 0; // 현 골드
        int Level = 1; // 현 레벨
        string enemy_name = ""; //적 이름
        int enemy_maxhp = 0; //적 최대 체력
        int enemy_hp = 0; //적 체력
        int enemy_att = 0; //적 공격력
        int combatTime = 0; // 전투 횟수
        int dice_number = 2; // 주사위 갯수
        string[] dice_category = new string[] { "hero", "priest", "0", "0" };// 갖고 있는 주사위 종류
        float AddAttack = 0.0f; // 추가공격력
        float AddDefence = 0.0f; // 추가 방어력
        float Critical = 0.0f; //치명타
        float Evasion = 0.0f; // 회피율
        float Stun = 0.0f; // 스턴률
        int Equip = 0; // 착용한 아이템
        List<int> Inventory = new List<int>(20); // 소지 아이템

    }
}
