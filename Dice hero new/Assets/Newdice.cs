using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newdice : MonoBehaviour


{
    //public static int dice_result = 1;
    //private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            //StartCoroutine(Diceroll());
        //}
        
        
    }
}

/*
    IEnumerator Diceroll()
    {
        int dice_time = 0;
        int dice_graphic = 0;
        int pre_dice_gra = 0;
        Debug.Log("주사위를 굴립니다.");
        spriteRenderer = GetComponent<SpriteRenderer>();
        dice_result = Random.Range(1, 7);
        while (dice_time < 6)
        {
            dice_graphic = Random.Range(0, 6);
            if (dice_graphic == pre_dice_gra)
            {
               while (dice_graphic != pre_dice_gra)
               {
                   dice_graphic = Random.Range(0, 6);
               }
            }
            pre_dice_gra = dice_graphic;
            spriteRenderer.sprite = sprites[dice_graphic];
            ++dice_time;
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log(dice_result.ToString());
        int dice_gra = dice_result - 1; 
        spriteRenderer.sprite = sprites[dice_gra];
    }


}

/*
            if (dice_result == 1)
            {
                spriteRenderer.sprite = sprites[0];
            }
            if (dice_result == 2)
            {
            spriteRenderer.sprite = sprites[1];           
            }
            if (dice_result == 3)
            {
                spriteRenderer.sprite = sprites[2];
            }
            if (dice_result == 4)
            {
                spriteRenderer.sprite = sprites[3];
            }
            if (dice_result == 5)
            {
                spriteRenderer.sprite = sprites[4];
            }
            if (dice_result == 6)
            {
                spriteRenderer.sprite = sprites[5];
            }
*/