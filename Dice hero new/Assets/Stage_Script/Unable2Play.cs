using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unable2Play : MonoBehaviour
{
    public Text notice;

    public void UnableToPlay()
    {
        notice.text = "해당 캐릭터를 고르실 수 없습니다";
        StartCoroutine(returntext());
    }

    IEnumerator returntext()
    {
        yield return (new WaitForSeconds(2));
        notice.text = "함께할 생존자를 3명 고르세요";
    }
}
