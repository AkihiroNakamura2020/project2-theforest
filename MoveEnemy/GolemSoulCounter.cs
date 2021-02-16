using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolemSoulCounter : MonoBehaviour
{
    int count=0;
    string soultext;

    void Update()
    {
        soultext = count.ToString();
        GetComponent<Text>().text = soultext;
    }

    
    public void SoulCounterplus()
    {
        count++;
    }

    public void SoulCounterminus()
    {
        count--;
    }

}
