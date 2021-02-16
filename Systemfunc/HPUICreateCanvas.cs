using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUICreateCanvas : MonoBehaviour
{
    public GameObject myCanvas;

    void Start()
    {
        //GameObject canvas = Instantiate(myCanvas) as GameObject;
        myCanvas.GetComponent<Canvas>().worldCamera = Camera.main;
    }
}
