using UnityEngine;
using System.Collections.Generic;

public class RandomNumber : MonoBehaviour
{

    int start = 1;
    int end = 3;

    List<int> numbers = new List<int>();

    void Start()
    {

        for (int i = start; i <= end; i++)
        {
            numbers.Add(i);
        }

        while (numbers.Count > 0)
        {

            int index = Random.Range(0, numbers.Count);

            int ransu = numbers[index];
            Debug.Log(ransu);

            numbers.RemoveAt(index);
        }
    }
}