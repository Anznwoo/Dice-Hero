using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{

    public static int[] dice_result =new int[] {0,0,0,0}; //주사위 눈
    public static int CurrentStage = 1; //현 스테이지
    public static int CurrentTile = 0; //현 타일
    public static int Health = 6; // 현 체력
    public static int MaxHealth = 10; //최대 체력
    public static int Gold = 0; // 현 골드
    public static int Level = 1; // 현 레벨
    public static int dice_number = 2; // 주사위 갯수
    public static string[] dice_category=new string[] {"hero", "priest", "0", "0"};// 갖고 있는 주사위 종류
    public static float AddAttack = 0.0f; // 추가공격력
    public static float AddDefence = 0.0f; // 추가 방어력
    public static float Evasion = 0.0f; // 회피율
    public static float Stun = 0.0f; // 스턴률
    public static int Equip = 0; // 착용한 아이템
    public static int Inventory = 0; // 소지 아이템

    /*
    주사위 눈 - dice_result(4개주사위를 다 담게 변경)
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
}
