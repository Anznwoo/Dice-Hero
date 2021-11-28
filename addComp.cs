using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addComp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Data.dice_category[2] == gameObject.name)
        {
            gameObject.GetComponent<diceRoll3>().enabled = true;
            gameObject.GetComponent<mapDiceEffect>().enabled = true;

        }
        else if (Data.dice_category[3] == gameObject.name)
        {
            gameObject.GetComponent<diceRoll4>().enabled = true;
            gameObject.GetComponent<mapDiceEffect>().enabled = true;
        }
    }
}
