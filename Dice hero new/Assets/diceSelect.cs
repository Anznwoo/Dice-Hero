using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class diceSelect : MonoBehaviour
{
    string choice;
    bool choiceTrue = false;
    public Text text;
    Ray ray;
    RaycastHit hit;
    SpriteRenderer archorsr;
    SpriteRenderer roguesr;
    SpriteRenderer paladinsr;
    SpriteRenderer fightersr;
    void Start()
    {
        archorsr = GameObject.Find("archorselect").GetComponent<SpriteRenderer>();
        roguesr = GameObject.Find("rogueselect").GetComponent<SpriteRenderer>();
        paladinsr = GameObject.Find("paladinselect").GetComponent<SpriteRenderer>();
        fightersr = GameObject.Find("fighterselect").GetComponent<SpriteRenderer>();
        string[] undices = new string[] { "archor", "rogue", "paladin", "fighter" };
        if (Data.dice_number == 2)
        {
            GameObject.Find("archor").transform.position = new Vector3(-6, -1, -1);
            GameObject.Find("rogue").transform.position = new Vector3(-2, -1, -1);
            GameObject.Find("paladin").transform.position = new Vector3(2, -1, -1);
            GameObject.Find("fighter").transform.position = new Vector3(6, -1, -1);
        }
        else if (Data.dice_number == 3)
        {
            int num = Array.IndexOf(undices, Data.dice_category[2]);
            if (num == 1 || num == 2)
            {
                undices[1] = "0";
                undices[2] = "0";

            }
            undices[num] = "0";
            for(int i = 0; i < 4; i++)
            {
                string str = undices[i];
                if (str != "0")
                {
                    GameObject.Find(str).transform.position = new Vector3(-6+4*i, -1, -1);
                }
            }
        }
        archorsr.color = new Color(0, 0, 0, 0);
        roguesr.color = new Color(0, 0, 0, 0);
        paladinsr.color = new Color(0, 0, 0, 0);
        fightersr.color = new Color(0, 0, 0, 0);
    }
    bool onClick1=false;
    bool onClick2 = false;
    bool onClick3 = false;
    bool onClick4 = false;

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.name == "SelectButton")
                {
                    Debug.Log(choice);
                    Data.dice_category[Data.dice_number] = choice;
                    Data.dice_number += 1;
                    SceneManager.LoadScene("Mainmap" + Data.CurrentStage);
                }

                if (hit.transform.gameObject.name != "background"&& hit.transform.gameObject.name!= "SelectButton")
                {
                    choice = hit.transform.gameObject.name;
                    choiceTrue = true;

                    if (hit.transform.gameObject.name == GameObject.Find("archor").name)
                    {
                        archorsr.color = new Color(0, 68, 183, 255);
                        text.text = "archor(궁수주사위)로 선택하시겠습니까?" + System.Environment.NewLine+ System.Environment.NewLine + "전투에서 적에게 치명타를 날릴 수 있다." + System.Environment.NewLine+ System.Environment.NewLine + "(맵에서 굴린 궁수주사위의 눈*5= 치명타가 뜰 확률)";
                    }
                    else
                    {
                        archorsr.color = new Color(0, 68, 183, 0);
                    }
                    if (hit.transform.gameObject.name == GameObject.Find("rogue").name)
                    {
                        roguesr.color = new Color(0, 68, 183, 255);
                        text.text="rogue(도적주사위)로 선택하시겠습니까?"+ System.Environment.NewLine+ System.Environment.NewLine + "전투에서 적의 공격을 회피할 수 있다.(성기사 주사위와 같이 있을 수 없다)"+ System.Environment.NewLine+ System.Environment.NewLine+"(맵에서 굴린 도적주사위의 눈*5=회피할 확률)";
                    }
                    else
                    {
                        roguesr.color = new Color(0, 68, 183, 0);
                    }
                    if (hit.transform.gameObject.name == GameObject.Find("paladin").name)
                    {
                        paladinsr.color = new Color(0, 68, 183, 255);
                        text.text = "paladin(성기사주사위)로 선택하시겠습니까?" + System.Environment.NewLine+ System.Environment.NewLine + "전투에서 적의 공격을 막을 수 있다.(도적 주사위와 같이 있을 수 없다)" + System.Environment.NewLine+ System.Environment.NewLine + "(맵에서 굴린 성기사주사위의 눈*5=막을 확률)";
                    }
                    else
                    {
                        paladinsr.color = new Color(0, 68, 183, 0);
                    }
                    if (hit.transform.gameObject.name == GameObject.Find("fighter").name)
                    {
                        fightersr.color = new Color(0, 68, 183, 255);
                        text.text = "fighter(격투가주사위)로 선택하시겠습니까?" + System.Environment.NewLine+ System.Environment.NewLine + "전투에서 적에게 스턴을 먹일 수 있습니다." + System.Environment.NewLine+ System.Environment.NewLine + "(맵에서 굴린 격투가주사위의 눈*5=스턴을 먹일 확률)";
                    }
                    else
                    {
                        fightersr.color = new Color(0, 68, 183, 0);
                    }
                }        
                if (choiceTrue)
                {
                    GameObject.Find("SelectButton").transform.position = new Vector3(7, -4, -1);
                }
            }
        }
    }
}
