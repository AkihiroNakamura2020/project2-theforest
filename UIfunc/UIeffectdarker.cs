using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIeffectdarker : MonoBehaviour
{
    [SerializeField]
    GameObject UIdark;

    [SerializeField]
    Darkeffect darkeffect;

    private void Start()
    {
        UIdark.SetActive(true);
    }
    /*
    public void UIDarkOn()
    {
        UIdark.SetActive(true);
    }
    */

    public void UIDarkOff()
    {
        darkeffect.alfa = 0.7f;
        UIdark.SetActive(false);
    }

}
