using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{

    public Text textbar;
    public Text character;
    int progress = 0;
    bool flag = false;

    //Start is called before the first frame update
    void Start()
    {
        character.text = "";
        textbar.text = "스페이스바를 눌러서 진행해주세요!";
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !flag)
        {
            flag = true;
            Debug.Log(progress.ToString());
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
