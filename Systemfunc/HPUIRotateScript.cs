using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUIRotateScript : MonoBehaviour
{
    void LateUpdate()
    {
        if (Camera.main)
        {
            //　カメラと同じ向きに設定
            transform.rotation = Camera.main.transform.rotation;
        }
        
    }
}
