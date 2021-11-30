using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioList : MonoBehaviour
{
    public AudioClip[] Sources;
    AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayByList());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayByList()
    {
        for(int i = 0; i < Sources.Length; i++)
        {
            Audio.clip = Sources[i];
            Audio.Play();
            while (Audio.isPlaying)
                yield return null;
        }
    }
}
