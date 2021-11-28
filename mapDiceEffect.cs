using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapDiceEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (this.name == "priest")
            {
                if (Data.Health + Data.dice_result2 > Data.MaxHealth)
                {
                    Data.Health = Data.MaxHealth;
                }
                else
                {
                    Data.Health += Data.dice_result2;
                }
                Debug.Log("Ã¼·Â:" + Data.Health.ToString());
            }
            else if (this.name == "archor")
            {
                if (Data.dice_category[2] == this.name)
                {
                    Data.Critical = Data.dice_result3 * 5;
                }
                else if (Data.dice_category[3] == this.name)
                {
                    Data.Critical = Data.dice_result4 * 5;
                }
            }
            else if (this.name == "rogue")
            {
                if (Data.dice_category[2] == this.name)
                {
                    Data.Evasion = Data.dice_result3 * 5;
                }
                else if (Data.dice_category[3] == this.name)
                {
                    Data.Evasion = Data.dice_result4 * 5;
                }
            }
            else if (this.name == "paladin")
            {
                if (Data.dice_category[2] == this.name)
                {
                    Data.Evasion = Data.dice_result3 * 5;
                }
                else if (Data.dice_category[3] == this.name)
                {
                    Data.Evasion = Data.dice_result4 * 5;
                }
            }
            else if (this.name == "fighter")
            {
                if (Data.dice_category[2] == this.name)
                {
                    Data.Stun = Data.dice_result3 * 5;
                }
                else if (Data.dice_category[3] == this.name)
                {
                    Data.Stun = Data.dice_result4 * 5;
                }
            }



        }
    }
}
