using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Darkeffect : MonoBehaviour
{
    [SerializeField]
    UIeffectdarker effectdarker;

    public float speed = 0.1f;  //透明化の速さ
    public float alfa;    //A値を操作するための変数

    float timer;

    void Start()
    {
        alfa = 0.7f;
    }

    void Update()
    {
        GetComponent<Image>().color = new Color(0, 0, 0, alfa);

        timer += Time.deltaTime;

        if (timer > 1)
        {
            alfa += speed;
            timer = 0;
        }
        
        Debug.Log(alfa);

        if (alfa >= 1)
        {
            effectdarker.UIDarkOff();
            Debug.Log("a");
        }
    }
}
