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
    public GameObject overflow;
    public Text binNum1;
    public Text binNum2;
    public Text decSum;
    public Image line;

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
        overflow.SetActive(false);
        AS = gameObject.transform.GetComponent<AudioSource>();
        AS.Stop();
        res = new List<bool>();
        line.enabled = false;
        znak.transform.GetChild(2).GetComponent<RawImage>().enabled = false;
        znak.transform.GetChild(3).GetComponent<RawImage>().enabled = false;
    }

    public void Click()
    {
        sum = (int)a + (int)b;
        decSum.GetComponent<Text>().text = sum.ToString();

        Debug.Log(sum);
        if ((sum <= 127) && (sum >= -128))
        {
            overflow.SetActive(false);
            n1 = CreateCode(a);
            n2 = CreateCode(b);
            OutputBinNum(n1, binNum1);
            OutputBinNum(n2, binNum2);

            line.enabled = true;

            bool p = false;
            for (int i = 7; i != -1; i--)
            {
                SP_output spo = Adder(n1[i], n2[i], p);
                res.Add(spo.s);
                p = spo.p;
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
            n1.Clear();
            n2.Clear();
            res.Clear();
        }
        else
        {
            overflow.SetActive(true);
        }
    }

    List<bool> CreateCode(int num)
    {
        List<bool> res = DecToBin(num); //ïğÿìîé êîä
        if(num < 0)
        {
            Invert(res); //îáğàòíûé êîä

            //äîïîëíèòåëüíûé êîä
            List<bool> one = DecToBin(1);
            bool p = false;
            for (int i = 7; i != -1; i--)
            {
                SP_output spo = Adder(res[i], one[i], p);
                res[i] = spo.s;
                p = spo.p;
            }
        }
        return res;
    }

    void Invert(List<bool> num)
    {
        for(int i = 0; i < num.Count; i++)
        {
            if (num[i])
                num[i] = false;
            else
                num[i] = true;
        }
    }

    List<bool> DecToBin(int a)
    {
        List<bool> res = new List<bool>();
        int s = Math.Abs(a);
        while(s > 0)
        {
            if (s % 2 == 0)
            {
                res.Add(false);
                Debug.Log("0");
            }
            else
            {
                res.Add(true);
                Debug.Log("1");
            }
            s /= 2;
        }
        while(res.Count != 8)
        {
            res.Add(false);
        }
        res.Reverse();

        Debug.Log("end");
        return res;
    }

    bool xor(bool a, bool b)
    {
        return (a || b) && (!(a && b));
    }
   
    SP_output Adder(bool ai, bool bi, bool pi)
    {
        bool si = (pi && ((!ai && !bi) || (ai && bi))) || (!pi && ((!ai && bi) || (ai && !bi))); // ÌÎß ÌÄÍÔ ËŞÁÈÌÀ ÎËÜÃÀ ÂÀÑÈËÜÅÂÍÀ ÏĞÈÂÅÒÈÊ ÍßÌÍßÌ
        pi = (ai && bi) || (ai && pi) || (bi && pi); // ÏÅĞÅÕÎÄ ËÓ×ØÅ ÄÅËÀÒÜ ÏÎÑËÅ ĞÀÑ×ÅÒÀ ÎÑÍÎÂÍÎÃÎ ×ÈÑËÀ. ÒÀÊ ÇÀÍÈÌÀÅØÜ ÌÅÍÜØÅ ÌÅÑÒÀ È ÌÅÍÜØÅ ËÅÂÛÕ ÏÅĞÅÌÅÍÍÛÕ, ÏÎÍßË ÄÀ?
        SP_output res = new SP_output(si, pi);
        return res;
    }

    void OutputBinNum(List<bool> num, Text title)
    {
        string s = "";
        for(int i = 0; i < num.Count; i++)
        {
            if (num[i] == false)
                s += '0';
            else
                s += '1';
        }
        title.text = s;
        title.enabled = true;
    }

    public void OnReadInput1()
    {
        int.TryParse(if1.text, out int result);
        a = result;
        Debug.Log(a);
    }

    public void OnReadInput2()
    {
        int.TryParse(if2.text, out int result);
        b = result;
        Debug.Log(b);
    }

    void ChangeZnak()
    {
        if (res[0] == false)
        {
            znak.transform.GetChild(2).GetComponent<RawImage>().enabled = true;
            znak.transform.GetChild(3).GetComponent<RawImage>().enabled = false;
        }
        else
        {
            znak.transform.GetChild(2).GetComponent<RawImage>().enabled = false;
            znak.transform.GetChild(3).GetComponent<RawImage>().enabled = true;
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
