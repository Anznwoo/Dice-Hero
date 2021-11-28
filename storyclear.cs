using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class storyclear : MonoBehaviour
{

    public Text textbar1;
    public Text character1;
    public Image facepic1;
    public static GameObject face1;
    private Sprite sprite;
    int progress = 0;
    bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        face1 = GameObject.Find("face");
        face1.GetComponent<Image>().sprite = Resources.Load("darkdice", typeof(Sprite)) as Sprite;
        character1.text = "마왕";
        textbar1.text = "분하다... 결국 또 나만 주사위라니...";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !flag)
        {
            flag = true;
            Debug.Log(progress.ToString());
            if (progress == 0)
            {
                face1.GetComponent<Image>().sprite = Resources.Load("herohuman", typeof(Sprite)) as Sprite;
                character1.text = "용사";
                textbar1.text = "하하! 난 이제 집까지 걸어갈테니\n잘 굴러다니도록 해라!";
            }
            if (progress == 1)
            {
                face1.GetComponent<Image>().sprite = Resources.Load("prihuman", typeof(Sprite)) as Sprite;
                character1.text = "사제";
                textbar1.text = "이겼다! 게임 끝!";
            }
            if (progress == 2)
            {
                face1.GetComponent<Image>().sprite = Resources.Load("nona", typeof(Sprite)) as Sprite;
                character1.text = "";
                textbar1.text = "마왕을 처리한 용사 일행 덕분에,\n주사위가 된 인간들은 다시 인간으로 돌아갔다.";
            }
            if (progress == 3)
            {
                face1.GetComponent<Image>().sprite = Resources.Load("nona", typeof(Sprite)) as Sprite;
                character1.text = "";
                textbar1.text = "그들의 용맹한 일대기는 \n후세에 길이길이 전해졌고...";
            }
            if (progress == 4)
            {
                face1.GetComponent<Image>().sprite = Resources.Load("nona", typeof(Sprite)) as Sprite;
                character1.text = "";
                textbar1.text = "그로부터 한 달 뒤 세계는\n분노한 주사위 마왕에 의해 멸망했다.";
            }
            if (progress == 5)
            {
                face1.GetComponent<Image>().sprite = Resources.Load("herohuman", typeof(Sprite)) as Sprite;
                character1.text = "용사";
                textbar1.text = "?";
            }
            if (progress == 6)
            {
                face1.GetComponent<Image>().sprite = Resources.Load("prihuman", typeof(Sprite)) as Sprite;
                character1.text = "사제";
                textbar1.text = "?????";
            }
            if (progress == 7)
            {
                face1.GetComponent<Image>().sprite = Resources.Load("nona", typeof(Sprite)) as Sprite;
                character1.text = "";
                textbar1.text = "게임을 플레이해주셔서 감사합니다!";
            }
            if (progress == 8)
            {
                face1.GetComponent<Image>().sprite = Resources.Load("nona", typeof(Sprite)) as Sprite;
                character1.text = "";
                textbar1.text = "제작자 : 황선우, 강민창, 임건우, 이건";
            }

            
            if (progress == 9)
            {
                SceneManager.LoadScene("Mainmenu");
            }




            progress++;
            flag = false;
        }
    }
}
