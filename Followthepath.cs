using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Followthepath : MonoBehaviour
{
    public Transform[] waypoints;
    public Sprite[] sprites = new Sprite[0];
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    
    public bool moveAllowed = false;



    // Start is called before the first frame update
    void Start()
    {
        if(Data.CurrentTile == 0)
        {
            transform.position = waypoints[0].transform.position;
        }
        else
        {
            transform.position = waypoints[Data.CurrentTile - 1].transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAllowed)
        {
            Move();
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprites[Data.dice_result1];
        }

        
    }

    private void Move()
    {
        if (Data.CurrentTile <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[Data.CurrentTile].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[Data.CurrentTile].transform.position)
            {
                Data.CurrentTile += 1;
            }
        }
        if (Data.CurrentTile == Data.dice_result1 + dicemove.StartWaypoint + 1)
        {
            Data.dice_result1 = 0;
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprites[Data.dice_result1];
            if (Data.tileList[Data.CurrentTile - 2] == 0)
            {
                //전투씬으로 연결
                Debug.Log("전투씬으로 연결됩니다.");
                SceneManager.LoadScene("fighting");
                return;
            }
            else if (Data.tileList[Data.CurrentTile - 2] == 1)
            {
                //상점씬으로 연결
                Debug.Log("상점씬으로 연결됩니다.");
                SceneManager.LoadScene("Store");
                return;
            }
            else if (Data.tileList[Data.CurrentTile - 2] == 2)
            {
                //여관으로 연결
                Debug.Log("여관으로 연결됩니다.");
                Data.diceStop = false;
                GameObject.Find("Canvas").transform.Find("bg_hpbar").gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("bg_hpbar(Clone)").gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("shelter").gameObject.SetActive(true);
                return;
            }
        }
        
    }
    
}
