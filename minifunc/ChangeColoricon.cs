using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeColoricon : MonoBehaviour
{
    [SerializeField]
    GameObject icon;

    Image image;
    Color basecolor;

    void Start()
    {
        image = icon.GetComponent<Image>();
        //basecolor = new Color(255.0f, 255.0f, 255.0f, 255.0f);
        Debug.Log("aa");
    }

    public void ChangeColor()
    {
        Debug.Log("aaa");
        Debug.Log(image);
        image.color = Color.red;
    }

    public void BackColor()
    {
        basecolor = new Color(255.0f, 255.0f, 255.0f, 255.0f);
        image.color = basecolor;
    }
}
