using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightingBackgroundSelect : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[7];
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Data.CurrentStage-1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
