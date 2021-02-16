using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Portion : MonoBehaviour
{
    [SerializeField]
    HPScript hPScript;

    [SerializeField]
    Button button;

    public void UsePortion()
    {
        hPScript.hp += 1;

        button.interactable = false;

        //this.gameObject.GetComponent<Image>().color = Color.grey;

        GetComponent<Image>().color = Color.grey;
        //mycolor = Color.grey;
        //Debug.Log(mycolor);
        
    }
}
