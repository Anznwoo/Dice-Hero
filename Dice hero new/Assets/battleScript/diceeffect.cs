using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//주사위 공격
public static class fight
{
    
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
