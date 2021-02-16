using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRoleRandom : MonoBehaviour
{
    int min = 0;
    int Max = 2;
    int yourNum;

    [SerializeField]
    GameObject group1;

    [SerializeField]
    GameObject group2;


    List<int> numbers = new List<int>();

    void Start()
    {
        for (int i = min; i <= Max-1; i++)
        {
            numbers.Add(i);
        }

        int index = Random.Range(0, numbers.Count);

        yourNum = numbers[index];//indexとyourNumは同じ数字
        Debug.Log(yourNum);
        Debug.Log(index);

        if (yourNum==0)
        {
            group2.SetActive(true);
        }
        else
        {
            group1.SetActive(true);
        }

        numbers.RemoveAt(index);//重複選択を避けるため
        
    }
}
