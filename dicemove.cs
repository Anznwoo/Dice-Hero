using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dicemove : MonoBehaviour
{
    

    private static GameObject Hero;

    public static int StartWaypoint = 0;

    // Start is called before the first frame update
    private void Start()
    {
        Hero = GameObject.Find("Hero");

        Hero.GetComponent<Followthepath>().moveAllowed = false;

    }

    // Update is called once per frame
    private void Update()
    {
        if(Data.CurrentTile > StartWaypoint + Data.dice_result1)
        {
            Hero.GetComponent<Followthepath>().moveAllowed = false;
            StartWaypoint = Data.CurrentTile - 1;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Hero.GetComponent<Followthepath>().moveAllowed = true;
            Debug.Log(Data.CurrentTile.ToString());
        }

        if(Data.CurrentTile == Hero.GetComponent<Followthepath>().waypoints.Length)
        {
            Hero.GetComponent<Followthepath>().moveAllowed = false;
            Debug.Log("보스전투씬으로 연결됩니다.");
            SceneManager.LoadScene("fighting");
            return;
        }

    }

}
