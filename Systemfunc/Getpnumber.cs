using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Getpnumber : MonoBehaviour
{
    List<int> numbers = new List<int>();
    public int ransu;
    int index;

    private void Start()
    {
        for (int i = 0; i <= PhotonNetwork.PlayerList.Length - 1; i++)
        {
            numbers.Add(i);
            Debug.Log("0");
        }
    }

    public void GetpnumberOn()
    {
        if (PhotonNetwork.PlayerList.Length == 0) return;
        RandomNumber();
        Debug.Log("1");
    }

    void RandomNumber()
    {
        Debug.Log("2");
        if (numbers.Count > 1)
        {
            index = Random.Range(0, numbers.Count);

            ransu = numbers[index];
            Debug.Log(ransu);

            numbers.RemoveAt(index);
            Debug.Log("3");
        }
        else if(numbers.Count == 1)
        {
            index = 0;
            ransu = numbers[index];
            Debug.Log(ransu);

            numbers.RemoveAt(index);
            Debug.Log("4");
        }

    }
}
