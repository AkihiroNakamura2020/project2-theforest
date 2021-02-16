using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject mainCamera;//メインカメラ格納用

    [SerializeField]
     GameObject subCamera;

    [SerializeField]
     GameObject subCamera2;

    [SerializeField]
    GameObject drone;

    [SerializeField]
    GameObject drone2;

    public bool onsubc=false;
    public bool onsubc2 = false;


    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        
        //サブカメラ非アクティブ
        subCamera.SetActive(false);
        subCamera2.SetActive(false);

        drone.SetActive(false);
        drone2.SetActive(false);

    }

    public void ChangeCamera()
    {
        if (onsubc2 == false)
        {
            drone.SetActive(true);

            mainCamera.SetActive(!mainCamera.activeSelf);
            subCamera.SetActive(!subCamera.activeSelf);
            onsubc = !onsubc;

        }
            
    }
    public void ChangeCamera2()
    {
        if (onsubc == false)
        {
            drone2.SetActive(true);

            mainCamera.SetActive(!mainCamera.activeSelf);
            subCamera2.SetActive(!subCamera2.activeSelf);
            onsubc2 = !onsubc2;
        }
    }

}
