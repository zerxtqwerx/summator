using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;

public class sum : MonoBehaviour
{
    int a = 10;
    int b = 10;
    int s;

    int Sum()
    {
        return a + b;
    }

    void Start()
    {
        //Debug.Log(perevod(Sum()));
    }

   /* //�������� �������� ������ ��������� ����� �� ����������
    private int perevod(int temp)
    {
        int temp1 = 0;
        List<int> s = new List<int>();
        while (temp > 0)
        {
            temp1 = temp % 2;
            temp = temp / 2;
            s.Add(temp1);
        }
        return obrat(s);
    }
    //�������������� ����� � ���������� ������ ������ ��������� �����.
    private int obrat(List<int> norm)
    {
        int[] s = new int[norm.Count];
        for (int i = norm.Count - 1; i >= 0; i--)
        {
            s[norm.Count - 1 - i] = norm[i];
        }
        return Convert.ToInt32(string.Join<int>("", s));
    }

    public string ConvertTo2(string num, int round = 5)
    {
        string result = ""; //���������
        int left = 0; //����� �����
        int right = 0; //������� �����
        string[] temp1 = num.Split(new char[] { '.', ',' }); //����� ��� ���������� ����� � ������� ������
        left = Convert.ToInt32(temp1[0]);
        //��������� ������� �� � ��� ������� �����
        if (temp1.Count() > 1)
        {
            right = Convert.ToInt32(num.Split(new char[] { '.', ',' })[1]); //������� �����
        }
        //�������� �������� ����� ����� � �������� �������
        while (true)
        {
            result += left % 2; //� ����� �������� ������� �� �������. � ����� ��������� �� ��������� ������, ��� ��� � �������� ������� ������������ �������
            left = left / 2; //��� ��� Left ����� �����, �� ��� ������� �������� ����� 2359 �� 2, �� ������� �� 1179,5 � 1179
            if (left == 0)
                break;
        }
        result = new string(result.ToCharArray().Reverse().ToArray()); //�������������� ������
        *//*�� ���������� � ��������, �� ����� ��� ������� �������� ������ ������� ����, � ���� �� �� �� �����!
        �� ���� ���� �� ������������� � ���� ����� *//*
        while (true)
        {
            int i = 0;
            if (result[i] == '0')
                result = result.Remove(i, 1);
            else break;
        }
        //��������� ���� �� � ��� ������� �����, ����� ���� �� ��������� � ��� if(temp1.count()>1)
        if (right == 0)
            return result;

        //��������� ��������� ����� ����� �� �������
        result += '.';

        int count = right.ToString().Count(); // ��� ����� ����� ���-�� ����, ��� ���������� �������� ������������ ��������

        for (int i = 0; i < round; i++)
        {
            *//*�������� ����� �� 2 � ���������, ����� �� ��� ������ �� ���������� ����, ���� ��,
            �� � ��������� ��� "1" � ������ ����� � right ��������� *//*
            right = right * 2;
            if (right.ToString().Count() > count)
            {
                string buf = right.ToString();
                buf = buf.Remove(0, 1);
                right = Convert.ToInt32(buf);

                result += '1';
            }
            else
            {
                result += '0';
            }
        }
        return result;
    }
*/
}
