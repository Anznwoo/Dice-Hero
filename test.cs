using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�׿� 6�� class�� ���� ����Ұ� ���߿� ���ӿ��� ���(���)hp ã�� ������ knite.hp �̷������� ȣ��
//�ڼ��Ѱ� c# class ã�ƺ���
public static class knite
{
    public static int hp=50;
    public static int maxHp = 50;
    public static int att=15;
    public static void ability(int dice)
    {
        //�̵��ϴ� �Լ� ä���
    }
    
}

public static class healer
{
    public static int hp = 50;
    public static int maxHp = 50;
    public static int att = 15;
    public static void ability(int dice)
    {
        //���� ������ �Է¹ޱ�
        
    }
}

public static class archor
{
    public static int hp = 50;
    public static int maxHp = 50;
    public static int att = 15;
    public static int percent;
    public static void ability(int dice)
    {
        //ġ��Ÿ Ȯ�� 
    }
}

public static class paladin
{
    public static int hp = 50;
    public static int maxHp = 50;
    public static int att = 15;
    public static int percent;
    public static void ability(int dice)
    {
        Debug.Log(dice);
    }
}

public static class thief
{
    public static int hp = 50;
    public static int maxHp = 50;
    public static int att = 15;
    public static int percent;
    public static void ability(int dice)
    {
        Debug.Log(dice);
    }
}

public static class fighter
{
    public static int hp = 50;
    public static int maxHp = 50;
    public static int att = 15;
    public static int percent;
    public static void ability(int dice)
    {
        Debug.Log(dice);
    }
}

//�ؿ� functions class�� ������� �ۼ�Ʈ�� ���� true,false ����Լ�, ������ �� ���� �Լ�

public static class functions
{
    public static bool stunTrue = false;

    public static bool percentage(int percent)
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
    //�ο�� �ſ��� ���ݹ�Ŀ� ���� '������ �� ���ݷ�'�� '�´¾� hp' �޾ƿ��� �ڵ� �ֱ�
    public static void heroAtt(int heroAtt, int monsterHp)
    {
        int damage;
        if (percentage(archor.percent)) //�ü� ġ��Ÿ
        {
            damage = heroAtt * 2;//ġ��Ÿ�߸� ������ �ö����� 2�� ��ü
        }
        else
        {
            damage = heroAtt;
        }

        if (percentage(fighter.percent)) //������ ����
        {
            stunTrue = true;
        }

        monsterHp=fight.heroAttack(damage, monsterHp);
    }
    
    public static void monsterAtt(int heroHp, int monsterHp)
    {
        //���� ������ ����Ǯ�� ����, 
        //����ֻ��� ��ü�� �˰� ����
    }


}


/*������ �Ű��� �ϴ°�
    1. �ֻ��� ���� �ޱ�
    2. Ư���ɷµ� �ݿ��ϱ�
    3. ����hp/att, ����hp/att �ֱ�
        1) �Ű������� �� �ֱ�
        2) ������ �ۿ��� ó��
    4. ��� �Ű澲��
    *����: ���� ���� �� ��ü, ���콺�� ���� ��� ���Ϳ� ����or���� ���� ���� ����
 */


public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/* ���� �ڵ� ¥��
    1. ������ �����°�(�� �ڵ忡�� 2~4�� �ֻ������� �� ��������, ���� ��� �ֻ��� percent�� �� ��)
        functions.heroAtt(�����¿���att, �´¸���hp)
    2. ���Ͱ� �����°�(�� ��ȣ�� ����)
        functions.heroAtt(�´¿���hp, �����¸���att)
 */