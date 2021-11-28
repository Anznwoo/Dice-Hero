using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBGM : MonoBehaviour
{

    private AudioSource audio;

    public AudioClip stage1;
    public AudioClip stage2;
    public AudioClip stage3;
    public AudioClip stage4;
    public AudioClip stage5;
    public AudioClip stage6;
    public AudioClip stage7;
    public AudioClip stageboss;

    // Start is called before the first frame update
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource> ();
        if (Data.CurrentTile == 27)
        {
            this.audio.clip = this.stageboss;
        }
        else
        {
            if (Data.CurrentStage == 1)
            {
                this.audio.clip = this.stage1;
            }
            if (Data.CurrentStage == 2)
            {
                this.audio.clip = this.stage2;
            }
            if (Data.CurrentStage == 3)
            {
                this.audio.clip = this.stage3;
            }
            if (Data.CurrentStage == 4)
            {
                this.audio.clip = this.stage4;
            }
            if (Data.CurrentStage == 5)
            {
                this.audio.clip = this.stage5;
            }
            if (Data.CurrentStage == 6)
            {
                this.audio.clip = this.stage6;
            }
            if (Data.CurrentStage == 7)
            {
                this.audio.clip = this.stage7;
            }
        }
        this.audio.loop = true;
        this.audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BGMStop()
    {
        if (audio.isPlaying)
        {
            audio.Stop();
        }

    }

}
