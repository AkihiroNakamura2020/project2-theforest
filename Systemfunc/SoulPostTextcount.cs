using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoulPostTextcount : MonoBehaviour
{
    int Postcount;
    string soultext;

    void Update()
    {
        soultext = Postcount.ToString();
        GetComponent<Text>().text = "現在差し出された魂は"+soultext+ "個です";
    }

        public void PostManage()
    {
        Postcount++;

        if (Postcount==3)
        {
            SceneManager.LoadScene("GoalScene");
            Postcount = 0;
        }
    }
}
