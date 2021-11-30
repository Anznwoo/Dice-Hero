using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSet : MonoBehaviour
{

    public Transform[] tiles;
    public GameObject[] signPrefab;

    int[] preTile1 = new int[] { 0, 0, 0, 1, 2 };
    int[] preTile2 = new int[] { 0, 0, 0, 2, 1 };
    int[] preTile3 = new int[] { 0, 0, 1, 0, 2 };
    int[] preTile4 = new int[] { 0, 0, 1, 2, 0 };
    int[] preTile5 = new int[] { 0, 0, 2, 0, 1 };
    int[] preTile6 = new int[] { 0, 0, 2, 1, 0 };
    int[] preTile7 = new int[] { 0, 1, 0, 0, 2 };
    int[] preTile8 = new int[] { 0, 1, 0, 2, 0 };
    int[] preTile9 = new int[] { 0, 1, 2, 0, 0 };
    int[] preTile10 = new int[] { 0, 2, 0, 0, 1 };
    int[] preTile11 = new int[] { 0, 2, 0, 1, 0 };
    int[] preTile12 = new int[] { 0, 2, 1, 0, 0 };
    

    // Start is called before the first frame update
    void Start()
    {
        if (Data.stage + 1 == Data.CurrentStage)
        {
            Data.CurrentTile = 0;
            Data.stage = Data.CurrentStage;
            SettingStart();
        }
        else
        {
            Set();
        }
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SettingStart()
    {
        Data.tileList.Clear();
        for(int i = 0; i < 6; i++)
        {
            int random = UnityEngine.Random.Range(1, 12);
            if (random == 1)
            {
                Data.tileList.AddRange(preTile1);
            }
            if (random == 2)
            {
                Data.tileList.AddRange(preTile2);
            }
            if (random == 3)
            {
                Data.tileList.AddRange(preTile3);
            }
            if (random == 4)
            {
                Data.tileList.AddRange(preTile4);
            }
            if (random == 5)
            {
                Data.tileList.AddRange(preTile5);
            }
            if (random == 6)
            {
                Data.tileList.AddRange(preTile6);
            }
            if (random == 7)
            {
                Data.tileList.AddRange(preTile7);
            }
            if (random == 8)
            {
                Data.tileList.AddRange(preTile8);
            }
            if (random == 9)
            {
                Data.tileList.AddRange(preTile9);
            }
            if (random == 10)
            {
                Data.tileList.AddRange(preTile10);
            }
            if (random == 11)
            {
                Data.tileList.AddRange(preTile11);
            }
            if (random == 12)
            {
                Data.tileList.AddRange(preTile12);
            }
        }
        Set();
        
    }

    private void Set()
    {
        for(int tileNumber = 0; tileNumber < 25; tileNumber++)
            Instantiate(signPrefab[Data.tileList[tileNumber]], tiles[tileNumber].transform.position, signPrefab[Data.tileList[tileNumber]].transform.rotation);      
    }
}

/* 

int[] pretile1 = new int[] { 0, 0, 0, 1, 2 };
int[] pretile2 = new int[] { 0, 0, 0, 2, 1 };
int[] pretile3 = new int[] { 0, 0, 1, 0, 2 };
int[] pretile4 = new int[] { 0, 0, 1, 2, 0 };
int[] pretile5 = new int[] { 0, 0, 2, 0, 1 };
int[] pretile6 = new int[] { 0, 0, 2, 1, 0 };
int[] pretile7 = new int[] { 0, 1, 0, 0, 2 };
int[] pretile8 = new int[] { 0, 1, 0, 2, 0 };
int[] pretile9 = new int[] { 0, 1, 2, 0, 0 };
int[] pretile10 = new int[] { 0, 2, 0, 0, 1 };
int[] pretile11 = new int[] { 0, 2, 0, 1, 0 };
int[] pretile12 = new int[] { 0, 2, 1, 0, 0 };

int tileUnion1 = 
int tileUnion2 = Random.Range(0, 11)
int tileUnion3 = Random.Range(0, 11)
int tileUnion4 = Random.Range(0, 11)
int tileUnion5 = Random.Range(0, 11)

int[] tileIndex = new int[] { 0, 0, 0, 1, 2 };

int random = UnityEngine.Random.Range(1, 12)
if random == 1

int[] tileIndex =


//transform.position = tiles[0].transform.position;

int tileNumber = 0
//tileIndex[tileNumber]
Instantiate(signPrefab[tileIndex[tileNumber]], tiles[0].transform.position, original.transform.rotation)

25칸을 5칸씩 나눔
왼쪽 끝은 몹으로 두고, 4!/2! = 12개 경우의 수
몹몹상여몹
몹상몹여몹 등등
12개의 경우 중 하나를 그 나눈 5칸에 할당함
그거에 따라 사인 배치


*/