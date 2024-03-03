using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RR : MonoBehaviour
{
    public GameObject znak;
    public List<GameObject> go;
    public InputField if1;
    public InputField if2;
    static AudioSource AS;

    int a = 0;
    int b = 0;
    int sum;
    string binarySum = "000000000";

    void Start()
    {
        AS = gameObject.transform.GetComponent<AudioSource>();
        AS.Stop();
    }

    public void Click()
    {
        sum = a + b;
        Perevod();
        ChangeZnak();
        ChangeGO();
        if (!AS.isPlaying)
        {
            AS.time = 0.0f;
            AS.Play();
        }
        

    }

    void Perevod()
    {
        int s = Math.Abs(sum);
        binarySum = "";
        while(s > 0)
        {
            binarySum = (s % 2) + binarySum;
            s /= 2;
        }

        if(binarySum.Length < go.Count)
        {
            for(int i = binarySum.Length; i != go.Count; i++)
            {
                binarySum = binarySum.Insert(0, "0");
            }
        }

        if (sum >= 0)
        {
            binarySum = binarySum.Insert(0, "0");
        }
        else
        {
            binarySum = binarySum.Insert(0, "1");
        }
        Debug.Log(binarySum);
    }

    public void OnReadInput1()
    {
        int.TryParse(if1.text, out int result);
        a = result;
    }

    public void OnReadInput2()
    {
        int.TryParse(if2.text, out int result);
        b = result;
    }

    void ChangeZnak()
    {
        if (binarySum[0] == '0')
        {
            znak.transform.GetChild(0).GetComponent<Image>().enabled = true;
            znak.transform.GetChild(1).GetComponent<Image>().enabled = false;
        }
        else
        {
            znak.transform.GetChild(1).GetComponent<Image>().enabled = true;
            znak.transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }

    void ChangeGO()
    {
        for(int i = 0; i < go.Count; i++)
        {
            if (binarySum[i+1] == '0')
            {
                go[i].transform.GetChild(2).GetComponent<RawImage>().enabled = true;
                go[i].transform.GetChild(3).GetComponent<RawImage>().enabled = false;
            }
            else
            {
                go[i].transform.GetChild(2).GetComponent<RawImage>().enabled = false;
                go[i].transform.GetChild(3).GetComponent<RawImage>().enabled = true;
            }
        }
    }
}
