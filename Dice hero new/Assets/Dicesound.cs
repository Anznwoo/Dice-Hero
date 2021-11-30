using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dicesound : MonoBehaviour
{

    private AudioSource audio;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource> ();
        this.audio.clip = this.sound;
        this.audio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.audio.Play();
        }
    }
}
