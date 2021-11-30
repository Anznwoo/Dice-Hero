using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{

    // Start is called before the first frame update

    SpriteRenderer sr;
    //SpriteRenderer busr;
    void Start()
    {
        sr = GameObject.Find("GAMEOVER").GetComponent<SpriteRenderer>();
        //busr = GameObject.Find("ToMain").GetComponent<SpriteRenderer>();
        StartCoroutine(FadeCouroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator FadeCouroutine()
    {
        float fadeCount=0;
        //float fade1Count=0;

        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            if (fadeCount > 1)
            {
                fadeCount = 1;
            }
            yield return new WaitForSeconds(0.015f);
            sr.color = new Color(fadeCount, fadeCount, fadeCount, 1);
        }
    }
}

/*
        while (fade1Count < 1.0f)
        {
            fade1Count += 0.01f;
            if (fade1Count > 1)
            {
                fade1Count = 1;
            }
            yield return new WaitForSeconds(0.015f);
            sr.color = new Color(1, 1, 1, fade1Count);
        }

    }

} */
