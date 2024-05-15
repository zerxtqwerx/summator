using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ee : MonoBehaviour
{

    static bool isPlaying;
    void Start()
    {
        gameObject.transform.GetComponent<AudioSource>().enabled = false;
        isPlaying = false;
    }

    public void Click()
    {
        gameObject.transform.GetComponent<AudioSource>().enabled = true;
    
        /*if (!isPlaying)
        {
            gameObject.transform.GetComponent<AudioSource>().enabled = true;
        }*/
    }

    
}
