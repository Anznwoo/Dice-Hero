using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{

    public Text textbar;
    public Text character;
    public Image facepic;
    public static GameObject face;
    private Sprite sprite;
    int progress = 0;
    bool flag = false;
    

    //Start is called before the first frame update
    void Start()
    {
        face = GameObject.Find("face");
        face.GetComponent<Image>().sprite = Resources.Load("hero0", typeof(Sprite)) as Sprite;
        character.text = "";
        textbar.text = "스페이스바를 눌러서 진행해주세요!";
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
                face.GetComponent<Image>().sprite = Resources.Load("darkdice", typeof(Sprite)) as Sprite;
                character.text = "마왕";
                textbar.text = "주사위로 살면서 핍박받은지도 어언 300년…\n드디어 금단의 마법을 익혔다!";
            }
            if (progress == 1)
            {
                character.text = "마왕";
                textbar.text = "나를 인간으로 만드는 대신, \n기존의 모든 인간들을 주사위로 만들어버리는 마법!";
            }
            if (progress == 2)
            {
                character.text = "마왕";
                textbar.text = "후후… 모두 주사위가 되는 고통을 느껴봐라!";
            }
            if (progress == 3)
            {
                face.GetComponent<Image>().sprite = Resources.Load("nona", typeof(Sprite)) as Sprite;
                character.text = "";
                textbar.text = "그 시각, 왕궁 수도";
            }
            if (progress == 4)
            {
                face.GetComponent<Image>().sprite = Resources.Load("herohuman", typeof(Sprite)) as Sprite;
                character.text = "용사";
                textbar.text = "엇, 뭔가 느낌이 좋지 않은데?";
            }
            if (progress == 5)
            {
                face.GetComponent<Image>().sprite = Resources.Load("prihuman", typeof(Sprite)) as Sprite;
                character.text = "사제";
                textbar.text = "뭐가?";
            }
            if (progress == 6)
            {
                face.GetComponent<Image>().sprite = Resources.Load("hero0", typeof(Sprite)) as Sprite;
                character.text = "용사";
                textbar.text = "뭔가... 굴러다녀야 할 것 같은 기분이...";
            }
            if (progress == 7)
            {
                face.GetComponent<Image>().sprite = Resources.Load("pri0", typeof(Sprite)) as Sprite;
                character.text = "사제";
                textbar.text = "엥? 너 주사위가 됐어! 앗! 나도 주사위다!";
            }
            if (progress == 8)
            {
                face.GetComponent<Image>().sprite = Resources.Load("hero0", typeof(Sprite)) as Sprite;
                character.text = "용사";
                textbar.text = "이런! 사악한 주사위 마왕이 저주를 건 것이 분명해!\n마왕을 잡으러 떠나자!";
            }
            if (progress == 9)
            {
                face.GetComponent<Image>().sprite = Resources.Load("pri0", typeof(Sprite)) as Sprite;
                character.text = "사제";
                textbar.text = "어떻게 그걸 바로 아는거야…?";
            }
            if (progress == 10)
            {
                face.GetComponent<Image>().sprite = Resources.Load("hero0", typeof(Sprite)) as Sprite;
                character.text = "용사";
                textbar.text = "이런 시시콜콜한 스토리에 스크립트 낭비하면 안돼!";
            }
            if (progress == 11)
            {
                SceneManager.LoadScene("Mainmap1");
            }




            progress++;
            flag = false;
            //StartCoroutine(sto());
            
            
        }
        
        
    }

    void stor()
    {
        if (progress == 0)
        {
            character.text = "마왕";
            textbar.text = "주사위로 살면서 핍박받은지도 어언 300년…\n드디어 금단의 마법을 익혔다!";
        }

        if (progress == 1)
        {
            character.text = "마왕";
            textbar.text = "나를 인간으로 만드는 대신, \n기존의 모든 인간들을 주사위로 만들어버리는 마법!";
        }
        
        
        
        return;
    }

    IEnumerator sto()
    {
        if (progress == 0)
        {
            character.text = "마왕";
            textbar.text = "주사위로 살면서 핍박받은지도 어언 300년…\n드디어 금단의 마법을 익혔다!";

        }
        if (progress == 1)
        {
            character.text = "마왕";
            textbar.text = "나를 인간으로 만드는 대신, \n기존의 모든 인간들을 주사위로 만들어버리는 마법!";
        }
        yield return new WaitForSeconds(2.1f);
        progress++;
        flag = false;
    }

   
    
}
