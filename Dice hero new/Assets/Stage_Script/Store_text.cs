using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DuloGames.UI
{
    public class Store_text : MonoBehaviour
    {
        /*string[] Scripts_entrance;
        string[] Scripts_buy;
        string[] Scripts_bought;
        public GameObject Store_TextBox;
        public Text Storetext;
        public Situation situation;
        public static Store_text ST;

        public void Start()
        {
            Scripts_entrance = new string[3] { "어서오세요!","안녕하세요!","좋은 날이네요"};
            Scripts_buy = new string[3] { "아주 훌륭한 제안이라구요","거저에요 거저","총칼로 안뺏기는게 어디에요"};
            Scripts_bought = new string[3] { "고마워요~", "잘 샀어요", "만족하실겁니다" };
            ST = this;
        }
        public void OpenTextBox(Situation situation)
        {
            int ran = Random.Range(1, 3);
            Store_TextBox.SetActive(true);
            if (situation == Situation.entrance)
            {
                Storetext.text = Scripts_entrance[ran];
            }
            else if (situation == Situation.buy)
            {
                Storetext.text = Scripts_buy[ran];
            }
            else if (situation == Situation.bought)
            {
                Storetext.text = Scripts_bought[ran];
            }
            StartCoroutine(WaitForIt());
            
        }
        IEnumerator WaitForIt()
        {
            yield return new WaitForSeconds(2.0f);
            Store_TextBox.SetActive(false);
        }*/
    }

    /*public enum Situation
    {
        entrance,
        buy,
        bought
    }*/
}
