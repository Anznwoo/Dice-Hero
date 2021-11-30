using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//및에 6개 class는 영웅 사용할거 나중에 게임에서 용사(기사)hp 찾고 싶으면 knite.hp 이런식으로 호출
//자세한건 c# class 찾아보기

//밑에 functions class는 순서대로 퍼센트에 따라 true,false 뱉는함수, 공격할 때 쓰는 함수

public static class functions
{
    public static bool stunTrue = false;

    public static bool percentage(float percent)
    {
        float randomNumber = Random.Range(0f, 100f);
        if (randomNumber < percent)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    //싸우는 거에선 공격방식에 따라 '때리는 애 공격력'과 '맞는애 hp' 받아오는 코드 넣기
    public static int heroAtt(int heroAtt, int monsterHp)
    {
        int damage;
        if (percentage(Data.Critical)) //궁수 치명타 집어 넣기
        {
            //궁수의 효과로 적에게 치명타를 입힌다. 메세지박스
            damage = heroAtt * 2;//치명타뜨면 몇프로 올라갈지는 2와 교체
        }
        else
        {
            damage = heroAtt;
        }

        if (percentage(Data.Stun)) //격투가 스턴값 집어넣기
        {
            //격투가에 의해 적이 스턴당했다. 메세지박스
            stunTrue = true;
        }

        return attack(damage, monsterHp);
    }
    
    public static int monsterAtt(int heroHp, int monsterAtt)
    {
        if (stunTrue)
        {
            //스턴을 당해 움직이지 못한다. 메세지박스
            stunTrue = false;
            return heroHp;
        }
        if (percentage(Data.Evasion))
        {
            //성기사가 적의 공격을 막았다. 메세지박스
            return heroHp;
        }
        if (percentage(Data.Evasion))
        {
            //적의 공격을 회피했다. 메세지박스
            return heroHp;
        }

        return attack(monsterAtt, heroHp);



        //스턴 있으면 스턴풀고 리턴, 
        //방어주사위 정체를 알고 쓰기
    }

    public static int attack(int att, int hp)
    {

        if (hp < att)
        {
            hp = 0;
        }
        else
        {
            hp -= att;
        }
        return hp;

    }

}


/*전투때 신경써야 하는거
    1. 주사위 숫자 받기
    2. 특수능력들 반영하기
    3. 영웅hp/att, 몬스터hp/att 넣기
        1) 매개변수로 다 넣기
        2) 리턴후 밖에서 처리
    4. 장비 신경쓰기
    *가정: 영웅 몬스터 다 객체, 마우스로 영웅 집어서 몬스터에 놓기or영웅 선택 몬스터 선택
 */




/* 공격 코드 짜기
    1. 영웅이 때리는거(앞 코드에서 2~4개 주사위들이 다 굴러갔고, 추후 얻는 주사위 percent에 다 들어감)
        functions.heroAtt(때리는영웅att, 맞는몬스터hp)
    2. 몬스터가 때리는거(위 괄호와 동일)
        functions.heroAtt(맞는영웅hp, 때리는몬스터att)
 */