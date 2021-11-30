using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickshow : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
    }

    // Update is called once per frame
    void OnMouseUp()
    {
        image.enabled = !image.enabled;
    }
}
