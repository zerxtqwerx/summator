using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class F : MonoBehaviour
{
    public bool flag = false;

    void Start()
    {
        gameObject.transform.GetChild(2).GetComponent<RawImage>().enabled = false;
        gameObject.transform.GetChild(3).GetComponent<RawImage>().enabled = false;
    }
}
