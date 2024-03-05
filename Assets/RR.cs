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
    List<bool> n1;
    List<bool> n2;
    List<bool> res;

    struct SP_output
    {
        public bool s;
        public bool p;

        public SP_output(bool s_, bool p_)
        {
            s= s_;
            p= p_;
        }
    }

    void Start()
    {
        AS = gameObject.transform.GetComponent<AudioSource>();
        AS.Stop();
        res = new List<bool>();
    }

    public void Click()
    {
        //sum = a + b;
        //Perevod(a);
        //Perevod(b);
        if ((a + b >= 0 && a + b <= 127) || (a + b < 0 && a + b > -128))
        {
            n1 = DecToBin(a);
            n2 = DecToBin(b);

            for (int i = 7; i != -1; i--)
            {
                bool p = false;
                res.Add(Adder(n1[i], n2[i], p).s);
                Debug.Log(res[res.Count - 1]);
            }
            while (res.Count != 8)
            {
                res.Add(false);
            }
            res.Reverse();

            if (a + b < 0)
            {
                res[0] = true;
            }

            ChangeZnak();
            ChangeGO();
            if (!AS.isPlaying)
            {
                AS.time = 0.0f;
                AS.Play();
            }
        }
        else
        {
            //сделать табличку переполнение
        }
    }

    List<bool> DecToBin(int a)
    {
        List<bool> res = new List<bool>();
        int s = Math.Abs(a);
        while(s > 0)
        {
            if (s % 2 == 0)
                res.Add(false);
            else
                res.Add(true);
            s /= 2;
        }
        while(res.Count != 8)
        {
            res.Add(false);
        }
        res.Reverse();
        return res;
    }
    bool xor(bool a, bool b)
    {
        return (a || b) && (!(a && b));
    }
    SP_output Adder(bool ai, bool bi, bool pi_1)
    {
        bool pi = (ai && bi) || (ai && pi_1) || (bi && pi_1);
        bool si = (ai || bi || pi_1) && pi_1 || (ai && bi && pi_1);
        SP_output res = new SP_output(si, pi);
        return res;
    }

    /*SP_output half_adder(bool a, bool b)
    {
        bool s = xor(a, b);
        bool p = a && b;
        return new SP_output(s, p);
    }

    SP_output adder(bool a, bool b, bool pi)
    {
        SP_output ha1 = half_adder(a, b);
        SP_output ha2 = half_adder(pi, ha1[0]);
        bool s = ha2.s;
        bool p = ha1.p || ha2.p;
        return new SP_output(s, p);
    }*/

    List<bool> Perevod(int a)
    {
        int s = Math.Abs(a);
        int count = 0;
        List<bool> res = new List<bool>();
        while(s > 0)
        {
            if(s % 2 == 0)
                res[count] = false;
            else
                res[count] = true;
            count++;
            s /= 2;
        }
        res.Reverse();

        /*if(binarySum.Length < go.Count)
        {
            for(int i = binarySum.Length; i != go.Count; i++)
            {
                binarySum = binarySum.Insert(0, "0");
            }
        }*/

        /*if (sum >= 0)
        {
            binarySum = binarySum.Insert(0, "0");
        }
        else
        {
            binarySum = binarySum.Insert(0, "1");
        }*/
        Debug.Log(res);
        return res;
    }

    public void OnReadInput1()
    {
        int.TryParse(if1.text, out int result);
        int a = result;
    }

    public void OnReadInput2()
    {
        int.TryParse(if2.text, out int result);
        b = result;
    }

    void ChangeZnak()
    {
        if (res[0] == false)
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
            if (res[i+1] == false)
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
