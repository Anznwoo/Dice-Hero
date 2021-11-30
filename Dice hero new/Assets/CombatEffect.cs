using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEffect : MonoBehaviour
{

    private AudioSource audio;

    public AudioClip hero;
    public AudioClip pri;
    public AudioClip arc;
    public AudioClip fig;
    public AudioClip pal;
    public AudioClip rou;
    public AudioClip enemy;
    public AudioClip damage;
    public AudioClip win;
    public AudioClip dice;

    // Start is called before the first frame update
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource> ();
        this.audio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EffectPlay(string situation)
    {
        if (situation == "pick")
        {
            this.audio.clip = this.dice;
        }
        if (situation == "win")
        {
            this.audio.clip = this.win;
        }
        if (situation == "enemy")
        {
            this.audio.clip = this.enemy;
        }
        if (situation == "damage")
        {
            this.audio.clip = this.damage;
        }
        if (situation == "hero")
        {
            this.audio.clip = this.hero;
        }
        if (situation == "priest")
        {
            this.audio.clip = this.pri;
        }
        if (situation == "archor")
        {
            this.audio.clip = this.arc;
        }
        if (situation == "rogue")
        {
            this.audio.clip = this.rou;
        }
        if (situation == "paladin")
        {
            this.audio.clip = this.pal;
        }
        if (situation == "fighter")
        {
            this.audio.clip = this.fig;
        }


        this.audio.Play();
    }
}
