using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayex : MonoBehaviour
{
 
    void Update()
    {
        //カメラ上で画面をタップした場所の位置情報と方向をrayに格納
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        float maxDistance = 10;


        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Rayが当たったオブジェクトの名前をログに表示する
            Debug.Log(hit.collider.gameObject.name);
        }

        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red, 5, false);

    }
}