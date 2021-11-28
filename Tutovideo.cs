using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Tutovideo : MonoBehaviour
{
    public VideoPlayer video;
    int doaq = 0;
    // Start is called before the first frame update
    void Start()
    {
        video.Play();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(sto());
    }

    IEnumerator sto()
    {
        yield return new WaitForSeconds(2.1f);
        if (!video.isPlaying)
        {
            SceneManager.LoadScene("Mainmenu");
        }
        //doaq++;
    }
}
