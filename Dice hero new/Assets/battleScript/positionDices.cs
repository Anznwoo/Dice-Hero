using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionDices : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        positioning();
    }

    void positioning()
    {
        if (Data.dice_number == 2)
        {
            GameObject.Find(Data.dice_category[0]).transform.position=new Vector3(-7.88f,-0.14f,-3);
            GameObject.Find(Data.dice_category[1]).transform.position = new Vector3(-4.48f, -0.14f, -3);
        }
        else if (Data.dice_number == 3)
        {
            GameObject.Find(Data.dice_category[0]).transform.position = new Vector3(-8.58f, -0.14f, -3);
            GameObject.Find(Data.dice_category[1]).transform.position = new Vector3(-6.18f, -0.14f, -3);
            GameObject.Find(Data.dice_category[2]).transform.position = new Vector3(-3.78f, -0.14f, -3);
        }
        else if (Data.dice_number == 4)
        {
            GameObject.Find(Data.dice_category[0]).transform.position = new Vector3(-9.12f, -0.14f, -3);
            GameObject.Find(Data.dice_category[1]).transform.position = new Vector3(-7.16f, -0.14f, -3);
            GameObject.Find(Data.dice_category[2]).transform.position = new Vector3(-5.2f, -0.14f, -3);
            GameObject.Find(Data.dice_category[3]).transform.position = new Vector3(-3.24f, -0.14f, -3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
