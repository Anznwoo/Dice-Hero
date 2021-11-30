using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diceRoll1 : MonoBehaviour
{
    bool RTrue1 = true;
    public Sprite[] sprites = new Sprite[Data.dice_result1];
    private SpriteRenderer spriteRenderer;
    int maxDice = 6;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Diceroll());
        sr = GetComponent<SpriteRenderer>();
    }
    Newdice newdice = new Newdice();
    Ray ray;
    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (RTrue1)
        {
            sr.color = new Color(1, 1, 1, 1);
        }
        else
        {
            sr.color = Color.gray;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name == Data.dice_category[0])
                {
                    RTrue1 = !RTrue1;
                }

            }

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!RTrue1)
            {
                return;
            }
            StartCoroutine(Diceroll());
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprites[0];
            maxDice = 6;
            if (!RTrue1)
            {
                RTrue1 = !RTrue1;
            }
        }
    }
    IEnumerator Diceroll()
    {
        int pre_dice_gra = 0;
        int dice_graphic = 0;
        int dice_time = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        while (dice_time < maxDice)
        {
            dice_graphic = UnityEngine.Random.Range(1, maxDice + 1);
            if (dice_graphic == pre_dice_gra)
            {
                while (dice_graphic != pre_dice_gra)
                {
                    dice_graphic = UnityEngine.Random.Range(1, maxDice + 1);

                }
            }
            pre_dice_gra = dice_graphic;
            spriteRenderer.sprite = sprites[dice_graphic];
            ++dice_time;
            yield return new WaitForSeconds(0.1f);
        }
        Data.dice_result1 = UnityEngine.Random.Range(1, maxDice + 1);
        Debug.Log(Data.dice_result1.ToString());
        spriteRenderer.sprite = sprites[Data.dice_result1];
        maxDice--;
    }
}
