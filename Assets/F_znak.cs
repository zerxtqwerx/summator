using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class F_znak : MonoBehaviour
{
    public bool flag;
    
    void Start()
    {
        gameObject.transform.GetChild(0).GetComponent<Image>().enabled = false;
        gameObject.transform.GetChild(1).GetComponent<Image>().enabled = false;
    }
}
